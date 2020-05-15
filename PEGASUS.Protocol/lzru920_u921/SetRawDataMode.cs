using PEGASUS.Protocol.lzru920_u921.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921
{
    public class SetRawDataMode : CommandBase
    {
        public SetRawDataMode(int mode)//1 => measure: 2 => configuration
        {
            Sync = Enum.Common.Sync;
            Cmd =  BitConverter.GetBytes(CommandId.SETRAWDATAMODE);
            //Data = new byte[] { 0x01 };
            Data = BitConverter.GetBytes(mode);
            ushort len = (ushort)( Cmd.Length + Data.Length);
            Size = BitConverter.GetBytes(len);

            Byte checksum = calculaChecksum();
            Chk = addByteToArray(checksum);
        }

        //private ushort calculaChecksum()
        //{
        //    int value = 0;
        //    for(int i =0; i<Cmd.Length; i++)
        //    {
        //        value = value ^ Cmd[i];
        //    }
        //    for(int i = 0; i < Data.Length; i++)
        //    {
        //        value = value ^ Data[i];
        //    }
        //    return (ushort)value;
        //}
        private byte calculaChecksum()
        {

            Byte chkSumByte = 0x00;
            for (int i = 0; i < Cmd.Length; i++)
                chkSumByte += Cmd[i];
            for (int i = 0; i < Data.Length; i++)
                chkSumByte += Data[i];
            return chkSumByte;
        }

        public byte[] addByteToArray(byte bytevalue)
        {
            byte[] newArray = new byte[2];
            newArray[0] = bytevalue;
            newArray[1] = 0x01;
            return newArray;
        }
    }
}

