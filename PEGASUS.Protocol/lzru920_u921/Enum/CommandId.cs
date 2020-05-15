using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.Protocol.lzru920_u921.Enum
{
    public class CommandId
    {
        /// <summary>
        /// khai báo mã ra lệnh
        /// </summary>
        public const ushort SETRAWDATAMODE = 50001;
        /// <summary>
        /// 
        /// </summary>
        public const ushort SETRAWDATACONFIG = 50003;
        /// <summary>
        /// 
        /// </summary>
        public const ushort GETRAWDATADISTANCEVALUES = 50011;
        /// <summary>
        /// 
        /// </summary>
        public const ushort SETRAWDATAERRORLOGRESET = 50006;
        /// <summary>
        /// 
        /// </summary>
        public const ushort SETRAWDATAFRAMECOUNTERRESET = 50014;
        /// <summary>
        /// 
        /// </summary>
        public const ushort GETRAWDATAMODE = 50002;
        /// <summary>
        /// 
        /// </summary>
        public const ushort GETRAWDATAINFORMATION = 50008;
        public const ushort GETRAWDATACONFIG = 50004;
        public const ushort SETRAWDATACONFIGSTORE = 50005;
        public const ushort SETRAWDATACONFIGRESTORE = 50007;
        public const ushort SETRAWDATAHEARTBEAT = 50012;
        public const ushort GETRAWDATAHEARTBEAT = 50013;
        public const ushort SETRAWDATAREDLASER = 50009;
        public const ushort GETRAWDATAREDLASER = 50010;
    }
}
