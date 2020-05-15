using PEGASUS.Common.ConvertDigital;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921
{
    public class CommandBase : ICommandBase// where T : ISerializable, new()
    {
        /// <summary>
        /// Kích thước gói tin khi chưa mã hóa
        /// </summary>
        //public T Body { get; set; }
        public byte[] Sync { get; set; }
        public byte[] Size { get; set; }
        public byte[] Cmd { get; set; }
        public byte[] Data { get; set; }
        public byte[] Chk { get; set; }
     
        public byte[] Serialize()
        {
            
            List<byte> bytes = new List<byte>();
            bytes.AddRange(Sync);
            bytes.AddRange(Size);
            bytes.AddRange(Cmd);
            bytes.AddRange(Data); 
            bytes.AddRange(Chk);
            //bytes.AddRange(Body.Serialize());
            return bytes.ToArray();
        }

        public void Deserialize(byte[] bytes)
        {
            for (int i = 0; i < 4; i++)
            {
                Sync[i] = bytes[i];
            }
            for (int i = 0; i < 2; i++)
            {
                Size[i] = bytes[i + 4];
            }
            for (int i = 0; i < 2; i++)
            {
                Cmd[i] = bytes[i + 6];
            }
            for (int i = 0; i < 1; i++)
            {
                Data[i] = bytes[i + 8];
            }
            for (int i = 0; i < 2; i++)
            {
                Chk[i] = bytes[i + 9];
            };
     
        }
    }
}
