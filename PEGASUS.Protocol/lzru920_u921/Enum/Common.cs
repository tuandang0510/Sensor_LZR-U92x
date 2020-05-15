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
    }
}
