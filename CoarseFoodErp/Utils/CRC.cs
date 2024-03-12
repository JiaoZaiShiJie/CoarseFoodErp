using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoarseFoodErp.Utils
{
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
