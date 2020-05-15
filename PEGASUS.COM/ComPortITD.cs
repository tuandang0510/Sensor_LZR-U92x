using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEGASUS.COM
{
    public class ComPortITD : IComPort
    {
        public event ComDelegate.ComReaderReceived OnComReaderReceived;

        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public bool Disconnect()
        {
            throw new NotImplementedException();
        }

        public bool Init()
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public bool Reconnect()
        {
            throw new NotImplementedException();
        }

        public bool SendCommand(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
