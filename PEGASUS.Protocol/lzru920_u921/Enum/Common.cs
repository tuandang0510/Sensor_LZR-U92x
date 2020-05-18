using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921.Enum
{
    public class Common
    {
        /// <summary>
        /// khai báo giá trị Sync
        /// </summary>
        public static readonly byte[] Sync = new byte[] { 0xFC, 0xFD, 0xFE, 0xFF };

        public static readonly string Sync_String = "FC-FD-FE-FF";

        public static int baudrate = 460800;

        public static byte calculaChecksum(byte[] Cmd, byte[] Data)
        {

            Byte chkSumByte = 0x00;
            for (int i = 0; i < Cmd.Length; i++)
                chkSumByte += Cmd[i];
            for (int i = 0; i < Data.Length; i++)
                chkSumByte += Data[i];
            return chkSumByte;
        }

        public static byte[] addByteToArray(byte bytevalue)
        {
            byte[] newArray = new byte[2];
            newArray[0] = bytevalue;
            newArray[1] = 0x01;
            return newArray;
        }
    }
}
