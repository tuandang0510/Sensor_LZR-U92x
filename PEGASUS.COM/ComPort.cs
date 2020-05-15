using ITD.ACV.TLS.Common.Log;
using PEGASUS.Common.ConvertDigital;
using ReaderB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using Enum = PEGASUS.Protocol.lzru920_u921.Enum;

namespace PEGASUS.COM
{
    public delegate void MyDelegate(byte[] data);
    public class ComPort : IComPort
    {
        public event ComDelegate.ComReaderReceived OnComReaderReceived;

        #region Fields

        /// <summary>
        /// Thời gian delay
        /// </summary>
        private int frmcomportindex = -1;
        private readonly int _delayTime = 10;
        private int baudrate;
        private string namePort;
        private int port;
        public event MyDelegate DataReceived;
        /// <summary>
        /// Cổng com dùng để giao tiếp với plc
        /// </summary>
        private SerialPort _mSerialPort = new SerialPort();

        #endregion Fields

        #region Contructor

        /// <summary>
        /// Khởi tạo COMPLC
        /// </summary>
        /// <param name="namePort"></param>
        /// <param name="baudrate">9600</param>
        /// <param name="delay">10ms</param>
        public ComPort(int port, int delayTime, int pbaudrate)
        {
            _delayTime = delayTime;
            namePort = string.Format("COM{0}",port);
            this.baudrate = pbaudrate;
        }

        #endregion Contructor

        public bool Init()
        {
            bool check = false;
            if (_mSerialPort == null)
            {
                _mSerialPort = new SerialPort();
            }
            _mSerialPort.PortName = namePort;
            _mSerialPort.BaudRate = baudrate;
            _mSerialPort.StopBits = StopBits.One;
            _mSerialPort.Parity = Parity.None;
            _mSerialPort.DataBits = 8;
            //_mSerialPort.ReadBufferSize = 8;
            //_mSerialPort.ReceivedBytesThreshold = 8;
            _mSerialPort.Handshake = Handshake.None;
            _mSerialPort.DtrEnable = true;
            _mSerialPort.RtsEnable = false;
            _mSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
           // MyDelegate del = new MyDelegate(GetSensorMessage);
            check = true;
            return check;
        }


        #region Methods

        /// <summary>
        /// Khởi tạo cổng com để bắt đầu giao tiếp với PLC(đối vơi PLC COM)
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                
                if (_mSerialPort == null)
                {
                    return false;
                }
                if (_mSerialPort.IsOpen)
                {
                    _mSerialPort.Close();
                }
                _mSerialPort.Open();
                _mSerialPort.DiscardInBuffer();
                _mSerialPort.DiscardOutBuffer();
                _mSerialPort.RtsEnable = true;
                _mSerialPort.DtrEnable = true;
                return _mSerialPort.IsOpen;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Open COM Port failed: " + GetType() + "." + MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        /// <summary>
        /// Tắt kết nối với thiết bị
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            try
            {
                if (_mSerialPort == null)
                {
                    return false;
                }
                if (_mSerialPort.IsOpen)
                {
                    _mSerialPort.Close();
                }
                
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Close COM Port failed: " + GetType() + "." + MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        /// <summary>
        /// Kết nối lại
        /// </summary>
        /// <returns></returns>
        public bool Reconnect()
        {
            bool check;
            try
            {
                check = Disconnect();
                if (check)
                {
                    check = Connect();
                }
            }
            catch (Exception ex)
            {
                check = false;
                LogHelper.Error("Re Send To Client failed: " + GetType() + "." + MethodBase.GetCurrentMethod().Name, ex);
            }
            return check;
        }

        /// <summary>
        /// Gửi dữ liệu xuống PLC
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public bool SendCommand(byte[] bytes)
        {

            bool ret = false;
            try
            {
                if (_mSerialPort != null && _mSerialPort.IsOpen)
                {
                    _mSerialPort.Write(bytes,0,bytes.Length);
                    System.Threading.Thread.Sleep(_delayTime);
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error($"{GetType()}. {MethodBase.GetCurrentMethod().Name}: {ex.Message}");
            }
            return ret;
        }

        /// <summary>
        /// Kiểm tra cổng COM mở, kênh PLC đã sẵn sàng
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            try
            {
                if (_mSerialPort == null)
                {
                    return false;
                }

                return _mSerialPort.IsOpen;
            }
            catch (Exception ex)
            {
                LogHelper.Error("Check COM port failed: " + GetType() + "." + MethodBase.GetCurrentMethod().Name, ex);
            }
            return false;
        }

        #region Receive data
        /// <summary>
        /// Hàm xử lý dữ liệu nhận được (COM)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_mSerialPort.IsOpen)
            {
                return;
            }
            int bytes = _mSerialPort.BytesToRead;
            if (bytes == 0)
            {
                return;
            }
            byte[] buffer = new byte[bytes];           
            try                                                                                                                                                       
            {
                _mSerialPort.Read(buffer, 0, bytes);
                _mSerialPort.DiscardInBuffer();
                if (bytes > 8)
                {

                    string sync = BitConverter.ToString(buffer.Skip(0).Take(4).ToArray()); // Lấy 4 bytes đầu tiên - phần dữ liệu Sync
                    if (sync.Equals(Enum.Common.Sync_String)) // Nếu dự liệu Sync đúng định dạng
                    {
                        GetSensorMessage(buffer);
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogHelper.Error(" failed: " + GetType() + "." + MethodBase.GetCurrentMethod().Name, ex);
            }
        }
        public void GetSensorMessage(byte[] message)
        {
            DataReceived?.Invoke(message);
        }

        public string GetDataTag()
        {
            byte[] array = new byte[40960];
            int num = 0;
            //int num2 = StaticClassReaderB.ReadActiveModeData(array, ref num, this.frmcomportindex);
            bool flag = num == 0;
            string result;
            string text2 = this.ByteArrayToHexString(array);
           
            if (flag)
            {
                string text = "";

                for (int i = 0; i < num; i++)
                {
                    text += text2.Substring(i * 2, 2);
                }
                bool flag2 = num > 0;
                if (flag2)
                {
                    result = text;
                    //NLogHelper.Info(text2);
                }
                else
                {
                    result = "";
                }

                return "";
            }
            return "";
        }

        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] array = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                array[i / 2] = Convert.ToByte(s.Substring(i, 2), 16);
            }
            return array;
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder stringBuilder = new StringBuilder(data.Length * 3);
            for (int i = 0; i < data.Length; i++)
            {
                byte value = data[i];
                stringBuilder.Append(Convert.ToString(value, 16).PadLeft(2, '0'));
            }
            return stringBuilder.ToString().ToUpper();
        }
        #endregion Receive data

        #endregion Methods


    }
}
