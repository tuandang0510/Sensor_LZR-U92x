using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PEGASUS.COM.ComDelegate;

namespace PEGASUS.COM
{
    public interface IComPort
    {
        bool Init();
        bool Connect();
        bool Disconnect();
        bool SendCommand(byte[] bytes);
        bool IsConnected();
       
        bool Reconnect();
        event ComReaderReceived OnComReaderReceived;
    }
}
