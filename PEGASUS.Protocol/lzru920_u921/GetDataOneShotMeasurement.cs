using PEGASUS.Protocol.lzru920_u921.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921
{
    public class GetDataOneShotMeasurement : CommandBase
    {
        public GetDataOneShotMeasurement()
        {
            Sync = Enum.Common.Sync;
            Cmd = BitConverter.GetBytes(CommandId.GETRAWDATADISTANCEVALUES);  //54 C3
            //Data = new byte[] { 0x01 };
            Data = new byte[0];
            ushort len = (ushort)(Cmd.Length + Data.Length);
            Size = BitConverter.GetBytes(len);

            //byte checksum = Enum.Common.calculaChecksum(Cmd, Data);
            //Chk = BitConverter.GetBytes(checksum);

            Byte checksum = Enum.Common.calculaChecksum(Cmd, Data);
            Chk = Enum.Common.addByteToArray(checksum);
        }

        //private byte calculaChecksum()
        //{
        //    Byte chkSumByte = 0x00;
        //    for (int i = 0; i < Cmd.Length; i++)
        //        chkSumByte += Cmd[i];
        //    for (int i = 0; i < Data.Length; i++)
        //        chkSumByte += Data[i];
        //    return chkSumByte;
        //}

        //public byte[] addByteToArray(byte bytevalue)
        //{
        //    byte[] newArray = new byte[2];
        //    newArray[0] = bytevalue;
        //    newArray[1] = 0x01;
        //    return newArray;
        //}
    }
}
