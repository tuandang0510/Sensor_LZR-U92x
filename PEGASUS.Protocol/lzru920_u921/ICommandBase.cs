using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921
{
    public interface ICommandBase : ISerializable
    {
        byte[] Sync { get; set; }
        byte[] Size { get; set; }
        byte[] Cmd { get; set; }
        byte[] Data { get; set; }
        byte[] Chk { get; set; }

    }
}
