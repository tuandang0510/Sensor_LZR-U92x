using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Common.ConvertDigital
{
    public static class Utility
    {
        public static byte[] CorrectEndian(this byte[] bytes)
        {
            return BitConverter.IsLittleEndian
                ? bytes
                : bytes.Reverse().ToArray();
        }

        public static byte[] ToBytes(this string input)
        {
            return Encoding.ASCII.GetBytes(input).CorrectEndian();
        }

        public static byte[] ToBytes(this string input, int length)
        {
            byte[] bytes = new byte[length];
            if (string.IsNullOrEmpty(input))
            {
                return bytes;
            }

            byte[] inputBytes = input.ToBytes();
            Array.Copy(inputBytes, bytes, inputBytes.Length > length ? length : inputBytes.Length);
            return bytes.CorrectEndian();
        }

        public static byte[] ToBytes(this int input)
        {
            return BitConverter.GetBytes(input).CorrectEndian();
        }

        public static byte[] ToBytes(this short input)
        {
            return BitConverter.GetBytes(input).CorrectEndian();
        }

        public static int ToInt32(this byte[] bytes, int start)
        {
            return BitConverter.ToInt32(bytes.Skip(start).Take(4).ToArray().CorrectEndian(), 0);
        }

        public static uint ToUInt32(this byte[] bytes, int start)
        {
            return BitConverter.ToUInt32(bytes.Skip(start).Take(4).ToArray().CorrectEndian(), 0);
        }

        public static short ToInt16(this byte[] bytes, int start)
        {
            return BitConverter.ToInt16(bytes.Skip(start).Take(2).ToArray().CorrectEndian(), 0);
        }

        public static ushort ToUInt16(this byte[] bytes, int start)
        {
            return BitConverter.ToUInt16(bytes.Skip(start).Take(2).ToArray().CorrectEndian(), 0);
        }

        public static long ToInt64(this byte[] bytes, int start)
        {
            return BitConverter.ToInt64(bytes.Skip(start).Take(8).ToArray().CorrectEndian(), 0);
        }

        public static string ToString(byte[] bytes, int start, int lenght)
        {
            byte[] byteTemp = bytes.Skip(start).Take(lenght).ToArray();
            //int lastIndex = Array.FindLastIndex(byteTemp, b => b != 0);
            //Array.Resize(ref byteTemp, lastIndex + 1);
            //Array.Reverse(byteTemp, 0, byteTemp.Length);
            return Encoding.UTF8.GetString(byteTemp);
        }

        public static string ToString(byte[] tmpbytes, bool spaceInBetween)
        {
            string tmpStr = string.Empty;

            if (tmpbytes == null)
            {
                return "";
            }

            for (int i = 0; i < tmpbytes.Length; i++)
            {
                tmpStr += string.Format("{0:X2}", tmpbytes[i]);

                if (spaceInBetween)
                {
                    tmpStr += " ";
                }
            }

            return tmpStr;
        }

        
        public static string ToString(byte[] tmpbytes, int offset, int count, bool spaceInBetween)
        {
            string tmpStr = string.Empty;

            if (tmpbytes == null)
            {
                return "";
            }
            int length = offset + count;
            for (int i = offset; i < length; i++)
            {
                tmpStr += string.Format("{0:X2}", tmpbytes[i]);

                if (spaceInBetween)
                {
                    tmpStr += " ";
                }
            }

            return tmpStr;
        }

        /// <summary>
        /// Convert hex string to byte array
        /// </summary>
        /// <param name="hex">Input hex string</param>
        /// <returns></returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

     

    }
}