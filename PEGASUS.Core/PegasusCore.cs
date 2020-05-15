using PEGASUS.COM;
using PEGASUS.Common;
using PEGASUS.Protocol.lzru920_u921;
using System;
using System.Reflection;
using System.Windows.Forms;
using static PEGASUS.COM.ComDelegate;

namespace PEGASUS.Core
{
    public class PegasusCore
    {
        IComPort com;
        public PegasusCore(IComPort com)
        {
            this.com = com;
        }
        public bool InitCom()
        {
            bool check = false;
            if (com.Init()) 
            {
                if (com.Connect())
                {
                    com.OnComReaderReceived += new ComReaderReceived(this._port_DataReceived);
                }
                else
                {
                    return check;
                }

            }           
            else
            {
               return check;
            }

            return true;
        }

        private void _port_DataReceived(string cmd)
        {
            string txt01="";
            try
            {                
                    txt01 = cmd;           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SendData()
        {
            try
            {
                if (com != null /*&& com.IsConnected()*/)
                {
                    //byte[] sysc = new byte[] { 0xFF, 0xFE, 0xFD, 0xFC };
                    //byte[] data = new byte[] { 0x01 };
                   // ICommandBase comm = new SetRawDataMode(0);
                    byte[] datasend = { 0xA5 };
                    com.SendCommand(datasend);
                   
                }
                else
                {
                    MessageBox.Show("Disconnected");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    NLogHelper.Error(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name + " - " + "DbLibrary.ExecuteNonQuery(DbCommand)" + " - " +
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                else
                    NLogHelper.Error(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name + " - " + "DbLibrary.ExecuteNonQuery(DbCommand)" + " - " +
                        ex.Message);
            }
        }

        public bool SendData(byte[] datasend)
        {
            bool result = true;
            try
            {
                if (com != null /*&& com.IsConnected()*/)
                {
                    com.SendCommand(datasend);
                }
            }
            catch (Exception ex)
            {
                result = false;
                if (ex.InnerException != null)
                    NLogHelper.Error(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name + " - " + "DbLibrary.ExecuteNonQuery(DbCommand)" + " - " +
                        ex.Message + ".InnerMessage:" + ex.InnerException.Message);
                else
                    NLogHelper.Error(
                        MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name + " - " + "DbLibrary.ExecuteNonQuery(DbCommand)" + " - " +
                        ex.Message);

            }
            return result;
        }
    }
}

