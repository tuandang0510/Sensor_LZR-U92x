using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921
{

    public interface ISerializable
    {
        byte[] Serialize();

        void Deserialize(byte[] bytes);
    }

}
