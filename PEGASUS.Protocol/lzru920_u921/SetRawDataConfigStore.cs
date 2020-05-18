using PEGASUS.Protocol.lzru920_u921.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921
{
    public class SetRawDataConfigStore : CommandBase
    {
        public SetRawDataConfigStore() 
        {
            Sync = new byte[] { 0xFF, 0xFE, 0xFD, 0xFC };
            Cmd = BitConverter.GetBytes(CommandId.SETRAWDATACONFIGSTORE);
            //Data = new byte[] { 0x01 };
            Data = new byte[0];
            ushort len = (ushort)(Cmd.Length + Data.Length);
            Size = BitConverter.GetBytes(len);

            ushort checksum = Enum.Common.calculaChecksum(Cmd, Data);
            Chk = BitConverter.GetBytes(checksum);
        }

        //private ushort calculaChecksum()
        //{
        //    int value = 0;
        //    for (int i = 0; i < Cmd.Length; i++)
        //    {
        //        value = value ^ Cmd[i];
        //    }
        //    for (int i = 0; i < Data.Length; i++)
        //    {
        //        value = value ^ Data[i];
        //    }
        //    return (ushort)value;
        //}
    }
}

