using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jot.Storage;

namespace JCommon.Jot
{
    internal class JsonDataStore : IStore
    {
        #region custom serialization (for object type handling)

        private class IPAddressConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(IPAddress);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var value = reader.Value;
                if (value != null)
                    return IPAddress.Parse((string)reader.Value);
                else
                    return null;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteValue(value.ToString());
            }
        }

        private class StoreItem
        {
            [JsonProperty(Order = 2)]
            public string Name { get; set; }

            [JsonProperty(Order = 1)]
            public Type Type { get; set; }

            [JsonProperty(Order = 3)]
            public object Value { get; set; }
        }

        private class StoreItemConverter : JsonConverter
        {
            public override bool CanRead
            {
                get { return true; }
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(StoreItem);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                reader.Read();//read "Type" attribute name
                reader.Read();//read "Type" attribute value
                Type t = serializer.Deserialize<Type>(reader);

                var x = reader.Read();//read "Name" attribute name
                var name = reader.ReadAsString();//read "Name" attribute value

                reader.Read();//read "Value" attribute name
                reader.Read();//read "value" attribute value
                var res = serializer.Deserialize(reader, t);

                reader.Read();//position to next item

                return new StoreItem() { Name = name, Type = t, Value = res };
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                //nothing fancy, standard serialization
                var converters = serializer.Converters.ToArray();
                var jObject = JObject.FromObject(value);
                jObject.WriteTo(writer, converters);
            }
        }

        #endregion custom serialization (for object type handling)

        /// <summary>
        /// Creates a JsonFileStore that will store files in a per-user folder (%appdata%\[companyname]\[productname]).
        /// </summary>
        /// <remarks>CompanyName and ProductName are read from the entry assembly's attributes.</remarks>
        public JsonDataStore()
            : this(true)
        {
        }

        /// <summary>
        /// Creates a JsonFileStore that will store files in a per-user or per-machine folder.
        /// (%appdata% or %allusersprofile% + \[companyname]\[productname]).
        /// </summary>
        /// <param name="perUser">
        /// Specified if a per-user or per-machine folder will be used for storing the data.
        /// </param>
        /// <remarks>CompanyName and ProductName are read from the entry assembly's attributes.</remarks>
        public JsonDataStore(bool perUser)
            : this(ConstructPath(perUser ? Environment.SpecialFolder.ApplicationData : Environment.SpecialFolder.CommonApplicationData))
        {
        }

        /// <summary>
        /// Creates a JsonFileStore that will store files in the specified folder.
        /// </summary>
        /// <param name="folder">
        /// The folder inside which the json files for tracked objects will be stored.
        /// </param>
        public JsonDataStore(Environment.SpecialFolder folder)
            : this(ConstructPath(folder))
        {
        }

        /// <summary>
        /// Creates a JsonFileStore that will store files in the specified folder.
        /// </summary>
        /// <param name="storeFolderPath">
        /// The folder inside which the json files for tracked objects will be stored.
        /// </param>
        public JsonDataStore(string storeFolderPath)
        {
            FolderPath = storeFolderPath;
        }

        /// <summary>
        /// The folder in which the store files will be located.
        /// </summary>
        public string FolderPath { get; set; }

        private static string ConstructPath(Environment.SpecialFolder baseFolder)
        {
            string companyPart = string.Empty;
            string appNamePart = string.Empty;

            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)//for unit tests entryAssembly == null
            {
                AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyCompanyAttribute));
                if (!string.IsNullOrEmpty(companyAttribute.Company))
                    companyPart = string.Format("{0}\\", companyAttribute.Company);
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(entryAssembly, typeof(AssemblyTitleAttribute));
                if (!string.IsNullOrEmpty(titleAttribute.Title))
                    appNamePart = string.Format("{0}\\", titleAttribute.Title);
            }

            return Path.Combine(Environment.GetFolderPath(baseFolder), string.Format(@"{0}{1}", companyPart, appNamePart));
        }

        private string GetfilePath(string id)
        {
            return Path.Combine(FolderPath, string.Format("{0}.data", id));
        }

        public void ClearAll()
        {
            foreach (var id in ListIds())
                ClearData(id);
        }

        public void ClearData(string id)
        {
            string filePath = GetfilePath(id);
            if (File.Exists(filePath))
            {
                File.Delete(GetfilePath(id));
            }
        }

        /// <summary>
        /// Loads values from the json file into a dictionary.
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> GetData(string id)
        {
            string filePath = GetfilePath(id);
            List<StoreItem> storeItems = null;
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                fileContents = DESEncrypt.Decrypt(fileContents);
                storeItems = JsonConvert.DeserializeObject<List<StoreItem>>(fileContents, new StoreItemConverter(), new IPAddressConverter());
            }

            if (storeItems == null)
                storeItems = new List<StoreItem>();

            return storeItems.ToDictionary(item => item.Name, item => item.Value);
        }

        public IEnumerable<string> ListIds()
        {
            return Directory.GetFiles(FolderPath, "*.data").Select(Path.GetFileNameWithoutExtension);
        }

        /// <summary>
        /// Stores the values as a json file.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="values"></param>
        public void SetData(string id, IDictionary<string, object> values)
        {
            if (values != null && values.Count > 0)
            {
                string filePath = GetfilePath(id);
                var list = values.Select(kvp => new StoreItem() { Name = kvp.Key, Value = kvp.Value, Type = kvp.Value != null ? kvp.Value.GetType() : null });
                string serialized = JsonConvert.SerializeObject(list, new JsonSerializerSettings() { Formatting = Newtonsoft.Json.Formatting.Indented, TypeNameHandling = TypeNameHandling.None, Converters = new JsonConverter[] { new IPAddressConverter() } });

                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                serialized = DESEncrypt.Encrypt(serialized);
                File.WriteAllText(filePath, serialized);
            }
        }
    }
}
