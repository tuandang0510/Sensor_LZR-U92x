using PEGASUS.COM;
using PEGASUS.Core;
using PEGASUS.Protocol.lzru920_u921;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static PEGASUS.COM.ComDelegate;
using PEGASUS.Test.Utilities;
using PEGASUS.Common;
using System.Reflection;
using System.Collections.Generic;
using PEGASUS.Protocol.lzru920_u921.Enum;

namespace PEGASUS.Test
{
    public partial class Form1 : Form
    {
        #region Members
        PegasusCore core;
        SetRawDataConfig _lzr_SetDataConfig;
        GetRawDataConfig _lzr_GetDataConfig;            
        GetRawDataMode _lzr_GetDataMode;
        GetDataOneShotMeasurement _lzr_GetDataOneMeasure;
        SetRawDataRedLaser _lzr_SetRawDataRedLazer;
        SetRawDataMode _lzr_SetRawDataMode;
        ComPort comPort;
        int portNumber;
        #endregion
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            _lzr_SetDataConfig = new SetRawDataConfig();
 
            // Thêm toàn bộ các COM đã tìm được vào combox cbCom
            if (ports.Count() > 0)
            {
                cbCom.Items.AddRange(ports);
                cbCom.SelectedIndex = 0;
            }
            
        }
        #region Events
        private void btnTestCom_Click(object sender, EventArgs e)
        {

            string comNameSelected = cbCom.SelectedItem.ToString();
            string a = comNameSelected.Substring(3);
            portNumber = int.Parse(comNameSelected.Substring(3));

            comPort = new ComPort(portNumber, 10, PEGASUS.Protocol.lzru920_u921.Enum.Common.baudrate);
            comPort.DataReceived += ComPort_DataReceived;
            core = new PegasusCore(comPort);

            bool check = core.InitCom();
            if (check)
            {
                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("Disconnected");
            }
        }
        private void btnTestSend_Click(object sender, EventArgs e)
        {
            core = new PegasusCore(new ComPort(portNumber, 10, PEGASUS.Protocol.lzru920_u921.Enum.Common.baudrate));
            core.SendData();
        }
        private void btnStatusMode_Click(object sender, EventArgs e)
        {
            try
            {
                _lzr_GetDataMode = new GetRawDataMode(0x00); //(0xA05);
                bool result = core.SendData(_lzr_GetDataMode.Serialize());
                if (result)
                {
                    //MessageBox.Show("Switch to configuration mode: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Switch to configuration mode: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnSwitchConfigMode_Click(object sender, EventArgs e)
        {
            try
            {
                _lzr_GetDataMode = new GetRawDataMode(0xA5); //(0xA5);
                bool result = core.SendData(_lzr_GetDataMode.Serialize());
                if (result)
                {
                    //MessageBox.Show("Switch to configuration mode: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Switch to configuration mode: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnGetConfig_Click(object sender, EventArgs e)
        {
            try
            {
                _lzr_GetDataConfig = new GetRawDataConfig();
                bool result = core.SendData(_lzr_GetDataConfig.Serialize());
                if (result)
                {
                    MessageBox.Show("Send the command Get config: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Send the command Get config: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGet1Measure_Click_1(object sender, EventArgs e)
        {
            try
            {
                _lzr_GetDataOneMeasure = new GetDataOneShotMeasurement();
                bool result = core.SendData(_lzr_GetDataOneMeasure.Serialize());
                if (result)
                {
                    MessageBox.Show("Send the command Get 1 Measure: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Send the command Get 1 Measure: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnSetBeamOn_Click(object sender, EventArgs e)
        {
            try
            {
                _lzr_SetRawDataRedLazer = new SetRawDataRedLaser(1);
                bool result = core.SendData(_lzr_SetRawDataRedLazer.Serialize());
                if (result)
                {
                    MessageBox.Show("Send the command turn on Beam: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Send the command turn on Beam: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnSetBeamOff_Click(object sender, EventArgs e)
        {
            try
            {
                _lzr_SetRawDataRedLazer = new SetRawDataRedLaser(0);
                bool result = core.SendData(_lzr_SetRawDataRedLazer.Serialize());
                if (result)
                {
                    MessageBox.Show("Send the command turn on Beam: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Send the command turn on Beam: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnMeasureMode_Click(object sender, EventArgs e)
        {
            try
            {
                _lzr_SetRawDataMode = new SetRawDataMode(1);
                bool result = core.SendData(_lzr_SetRawDataMode.Serialize());
                if (result)
                {
                    MessageBox.Show("Send the command turn on Beam: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Send the command turn on Beam: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion

        #region Methods
        private void ComPort_DataReceived(byte[] data)
        {
            try
            {
                switch (Utilities.Utility.ToUInt16(data, 6))
                {
                    case CommandId.GETRAWDATADISTANCEVALUES: // Neu la du lieu Measuring (do dac)
                        DataReceive_Get1Measure(data);
                        break;
                    case CommandId.GETRAWDATAMODE: // Neu la tra goi tin mode dang hoat dong
                        DataReceive_GetDrawDataMode(data);
                        break;
                    case CommandId.GETRAWDATAREDLASER: // Neu la2 tra goi tin Red lazer
                        DataReceive_SetDrawDataRedLaser(data);
                        break;
                    case CommandId.SETRAWDATAMODE:
                        DataReceive_SetDrawDataMode(data);
                        break;
                    default:
                        break;
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

        private void DataReceive_Get1Measure(byte[] data)
        {
            try
            {
                List<int> distance = new List<int>();
                NLogHelper.Info("============================================================================");
                string data_Hexa = BitConverter.ToString(data.ToArray()).Replace('-', ' ');   // Chuoi du lieu tho, dinh dang hexa
                NLogHelper.Info(String.Format("Sync data: {0}", BitConverter.ToString(data.Take(4).ToArray()).Replace('-', ' ')));  // Truong du lieu Sync
                NLogHelper.Info(String.Format("Size data: {0}", Utilities.Utility.ToInt16(data, 4)));    // Truong du lieu Size
                NLogHelper.Info(String.Format("CMD data: {0}", Utilities.Utility.ToUInt16(data, 6)));      //Truong du lieu CMD

                data = data.Skip(14).ToArray();   //Cat bo 14 bytes du lieu dau, con lai cac bytes cua cac truong du lieu: Message + Chk
                NLogHelper.Info(String.Format("Plan data: {0}", data[0]));   // Truong du lieu Plan
                data = data.Skip(1).ToArray();  // Cat bo truong du lieu Plan
                data = data.Take(data.Length - 2).ToArray();    // Cat bo truong du lieu Chk
                int i = 0;
                int j = 1;
                while (i < (data.Length - 1))
                {
                    if (i + 1 <= data.Length)
                    {
                        int point_measure = Utilities.Utility.ToUInt16(data, i); // 1 gia tri khoang cach do duoc
                        NLogHelper.Info(String.Format("Length data: {0} - {1} - {2} mm", j, BitConverter.ToString(data.Skip(i).Take(2).ToArray().CorrectEndian()).Replace('-', ' '), point_measure));
                        distance.Add(point_measure);
                        j++;
                        i = i + 2;
                    }
                }
                NLogHelper.Info(String.Format("Distance min: {0}", distance.Min()));      //Khoảng cách ngắn nhất
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

        private void DataReceive_GetDrawDataMode(byte[] data)
        {
            try
            {
                string data_Hexa = BitConverter.ToString(data.ToArray()).Replace('-', ' ');   // Chuoi du lieu tho, dinh dang hexa
                NLogHelper.Info(String.Format("Sync data: {0}", BitConverter.ToString(data.Take(4).ToArray()).Replace('-', ' ')));  // Truong du lieu Sync
                NLogHelper.Info(String.Format("Size data: {0}", Utilities.Utility.ToInt16(data, 4)));    // Truong du lieu Size
                NLogHelper.Info(String.Format("CMD data: {0}", Utilities.Utility.ToUInt16(data, 6)));      //Truong du lieu CMD

                data = data.Skip(8).ToArray();   //Cat bo 14 bytes du lieu dau, con lai cac bytes cua cac truong du lieu: Message + Chk
                if (BitConverter.ToString(data.Take(1).ToArray()).Equals("01")) //Measuring mode
                {
                    MessageBox.Show("Measuring mode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (BitConverter.ToString(data.Take(1).ToArray()).Equals("02")) //Configuration mode
                {
                    MessageBox.Show("Configuration mode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void DataReceive_SetDrawDataRedLaser(byte[] data)
        {
            try
            {
                string data_Hexa = BitConverter.ToString(data.ToArray()).Replace('-', ' ');   // Chuoi du lieu tho, dinh dang hexa
                NLogHelper.Info(String.Format("Sync data: {0}", BitConverter.ToString(data.Take(4).ToArray()).Replace('-', ' ')));  // Truong du lieu Sync
                NLogHelper.Info(String.Format("Size data: {0}", Utilities.Utility.ToInt16(data, 4)));    // Truong du lieu Size
                NLogHelper.Info(String.Format("CMD data: {0}", Utilities.Utility.ToUInt16(data, 6)));      //Truong du lieu CMD

                data = data.Skip(8).ToArray();   //Cat bo 14 bytes du lieu dau, con lai cac bytes cua cac truong du lieu: Message + Chk
                if (BitConverter.ToString(data.Take(1).ToArray()).Equals("01")) //Measuring mode
                {
                    MessageBox.Show("Beam on Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (BitConverter.ToString(data.Take(1).ToArray()).Equals("02")) //Configuration mode
                {
                    MessageBox.Show("Beam on Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DataReceive_SetDrawDataMode(byte[] data)
        {
            try
            {
                string data_Hexa = BitConverter.ToString(data.ToArray()).Replace('-', ' ');   // Chuoi du lieu tho, dinh dang hexa
                NLogHelper.Info(String.Format("Sync data: {0}", BitConverter.ToString(data.Take(4).ToArray()).Replace('-', ' ')));  // Truong du lieu Sync
                NLogHelper.Info(String.Format("Size data: {0}", Utilities.Utility.ToInt16(data, 4)));    // Truong du lieu Size
                NLogHelper.Info(String.Format("CMD data: {0}", Utilities.Utility.ToUInt16(data, 6)));      //Truong du lieu CMD

                data = data.Skip(8).ToArray();   //Cat bo 14 bytes du lieu dau, con lai cac bytes cua cac truong du lieu: Message + Chk
                if (BitConverter.ToString(data.Take(1).ToArray()).Equals("01")) //Measuring mode
                {
                    MessageBox.Show("Switch to measuring mode: Success", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (BitConverter.ToString(data.Take(1).ToArray()).Equals("02")) //Configuration mode
                {
                    MessageBox.Show("Switch to measuring mode: Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion


    }
}
