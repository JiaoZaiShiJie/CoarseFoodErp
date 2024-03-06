using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using DevExpress.XtraEditors;
using JBaseCommon.JBaseForm;
using TouchSocket.Core;

namespace CoarseFoodErp.CoarseFoodForm.SysSeting
{
    public partial class SysSetingForm : BaseEditForm
    {
        public SysSetingForm()
        {
            InitializeComponent();
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            byte[] data= Encoding.ASCII.GetBytes("22.56KG");

            //byte[] data = new byte[22];
            //data[0] = 0x55;
            //data[1] = 0x55;
            //data[2] = 0xAA;
            //data[3] = 0xAA;
            //data[4] = 0x00;
            //data[5] = 0x00;
            //data[6] = 0x00;
            //data[7] = 0x01;
            //data[8] = 0x00;
            //data[9] = 0x01;
            //data[10] = 0x00;
            //data[11] = 0x02;
            //data[12] = 0x01;
            //data[13] = 0x02;

            ////882340E7
            //data[14] = 0x88;
            //data[15] = 0x23;
            //data[16] = 0x40;
            //data[17] = 0xE7;

            //data[18] = 0xBB;

            //data[19] = 0xBB;
            //data[20] = 0x66;
            //data[21] = 0x66;

            //55 55 AA AA 00 00 00 01 00 01 00 02 01 02 

            uint result = Crc32Calculator.CalculateCrc32(data);
           Crc32Calculator.ParseAndVerifyCrc32(data);


        }




    }
    public class Crc32Calculator
    {
        private static readonly UInt32[] crcTable = CreateCRCTable();

        // 创建预计算的CRC32查找表
        private static UInt32[] CreateCRCTable()
        {
            UInt32[] table = new UInt32[256];
            for (int i = 0; i < 256; ++i)
            {
                UInt32 c = (UInt32)i;
                for (int j = 0; j < 8; ++j)
                {
                    if ((c & 1) == 1)
                        c = (c >> 1) ^ 0xEDB88320; // IEEE 802.3 polynomial
                    else
                        c >>= 1;
                }
                table[i] = c;
            }
            return table;
        }

        // 计算给定数据的CRC32校验码
        public static UInt32 CalculateCrc32(byte[] data)
        {
            UInt32 crc = 0xFFFFFFFF; // 初始值为全1
            foreach (byte b in data)
            {
                crc = (crc >> 8) ^ crcTable[(crc & 0xFF) ^ b];
            }
            return ~crc; // 返回结果需要取反
        }

        // 如果需要按照帧头到数据部分（不包括帧尾）计算CRC32
        public static UInt32 CalculateCrc32ForFrame(byte[] frameHeaderAndData)
        {
            // 假设帧头长度已知，例如帧头长度为2字节
            int headerLength = 2;
            byte[] dataPortion = new byte[frameHeaderAndData.Length - headerLength];
            Buffer.BlockCopy(frameHeaderAndData, headerLength, dataPortion, 0, dataPortion.Length);
            return CalculateCrc32(dataPortion);
        }

        // 示例：解析并计算给定数据的CRC32校验码
        public static void ParseAndVerifyCrc32(byte[] fullPacket)
        {
            // 假设帧头长度和数据长度已知，先提取数据部分
            int headerLength = 2;
            int dataLength = fullPacket.Length - headerLength - sizeof(UInt32); // 假设帧尾是4个字节的CRC32
            byte[] dataPortion = new byte[dataLength];
            Buffer.BlockCopy(fullPacket, headerLength, dataPortion, 0, dataLength);

            // 计算数据部分的CRC32
            UInt32 computedCrc32 = CalculateCrc32(dataPortion);

            // 提取并验证接收到的CRC32校验码
            UInt32 receivedCrc32 = BitConverter.ToUInt32(fullPacket, fullPacket.Length - sizeof(UInt32));

            bool isValid = computedCrc32 == receivedCrc32;
            Console.WriteLine($"CRC32校验结果：{(isValid ? "有效" : "无效")}");
        }
    }

}