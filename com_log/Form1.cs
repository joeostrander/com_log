using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com_log
{
    public partial class Form1 : Form
    {
        const byte XON_CHARACTER = 0x11;
        const byte XOFF_CHARACTER = 0x13;

        private static SerialPort serialPort1 = new SerialPort();

        private static List<KeyValuePair<string, string>> listPorts1 = new List<KeyValuePair<string, string>>();
        private static bool boolConnected;

        private static FileStream filestream_log;
        //private static MemoryStream mStream;
        //private int totalBytes;
        private string logFilename;
        private bool bool_logging = false;
        private DateTime last_xon;

        public void ThreadSafeDelegate(MethodInvoker method)
        {
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        //string filename = saveFileDialog1.FileName;
            //        //FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);
            //        mStream.Seek(0, SeekOrigin.Begin);
            //        mStream.WriteTo(filestream_log);
            //        filestream_log.Close();
            //        mStream.Seek(0, SeekOrigin.End);    // move to end in case we want to append...

            //        MessageBox.Show("See file:  " + logFilename, "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    }
            //}

            close_log_file(false);

        }




        private void Form1_Load(object sender, EventArgs e)
        {

            //textBoxReceived.Font = new Font(FontFamily.GenericMonospace, textBoxReceived.Font.Size);

            LoadPortsList();

            comboBoxComPort1.DataSource = listPorts1;
            comboBoxComPort1.ValueMember = "Key";
            comboBoxComPort1.DisplayMember = "Value";

            comboBoxBitsPerSecond.SelectedItem = "115200";
            comboBoxDataBits.SelectedItem = "8";
            comboBoxFlowControl.SelectedIndex = 0;
            comboBoxStopBits.SelectedIndex = 0;
            comboBoxParity.SelectedIndex = 0;

            this.Text = Application.ProductName;

            last_xon = DateTime.Now;
            timer1.Enabled = true;
        }


        private void LoadPortsList()
        {
            listPorts1.Clear();
            string strQuery = "Select * from Win32_PnPEntity Where Name LIKE '% (COM%)'";

            listPorts1.Add(new KeyValuePair<string, string>("", ""));

            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(strQuery);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject item in collection)
                {
                    string fn = item.Properties["Name"].Value.ToString();
                    string strPattern = @"^(?<porttext>.*?)\((?<portname>COM[\d]+)\)$";
                    Match m = Regex.Match(fn, strPattern);

                    if (m.Success)
                    {
                        string portname = m.Groups["portname"].Value.ToString();
                        string porttext = m.Groups["porttext"].Value.ToString();
                        listPorts1.Add(new KeyValuePair<string, string>(portname, portname.PadRight(6, ' ') + porttext));
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not get serial port list!", "Serial Ports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.WriteLine(ex.Message);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {



            buttonConnect.Enabled = false;
            if (boolConnected)
            {
                disconnect();
            }
            else
            {
                connect();
            }
        }

        private void choose_log_file()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                logFilename = saveFileDialog1.FileName;
                linkLabelFilename.Text = Path.GetFileName(saveFileDialog1.FileName);
                this.toolTip1.SetToolTip(this.linkLabelFilename, saveFileDialog1.FileName);
            }
        }

        private void disconnect()
        {
            boolConnected = false;
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            buttonConnect.Enabled = true;


        }

        private void close_log_file(bool silent)
        {
            try
            {
                if (filestream_log != null)
                {
                    filestream_log.Close();
                }
            }
            catch (Exception ex)
            {
                if (silent)
                {
                    Console.WriteLine(ex.Message);
                }
                else
                {
                    MessageBox.Show("Error closing log file.\n\n" + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void connect()
        {
            string strPortName1 = comboBoxComPort1.SelectedValue.ToString();
            if (string.IsNullOrEmpty(strPortName1))
            {
                buttonConnect.Enabled = true;
                return;
            }

            serialPort1.PortName = strPortName1;
            serialPort1.BaudRate = Int32.Parse(comboBoxBitsPerSecond.SelectedItem.ToString());
            serialPort1.ReadBufferSize = 1024;
            //serialPort1.Encoding = Encoding.UTF8;


            switch (comboBoxParity.SelectedItem.ToString())
            {
                case "Even":
                    serialPort1.Parity = Parity.Even;
                    break;
                case "Odd":
                    serialPort1.Parity = Parity.Odd;
                    break;
                case "None":
                    serialPort1.Parity = Parity.None;
                    break;
                case "Mark":
                    serialPort1.Parity = Parity.Mark;
                    break;
                case "Space":
                    serialPort1.Parity = Parity.Space;
                    break;
            }


            serialPort1.DataBits = Int32.Parse(comboBoxDataBits.SelectedItem.ToString());
            serialPort1.StopBits = (StopBits)Int32.Parse(comboBoxStopBits.SelectedItem.ToString());

            switch (comboBoxFlowControl.SelectedItem.ToString())
            {
                case "Xon / Xoff":
                    serialPort1.Handshake = Handshake.XOnXOff;
                    break;
                case "Hardware":
                    serialPort1.Handshake = Handshake.RequestToSend;
                    break;
                case "Both":
                    serialPort1.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
                case "None":
                    serialPort1.Handshake = Handshake.None;
                    break;
            }


            try
            {
                serialPort1.Open();
                boolConnected = true;
                //mStream = new MemoryStream();

                //totalBytes = 0;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                boolConnected = false;

                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }

            buttonConnect.Enabled = true;
            //clearBytes();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                SerialPort sp = (SerialPort)sender;

                int byteLength = sp.BytesToRead;
                byte[] buffer = new byte[byteLength];
                sp.Read(buffer, 0, byteLength);


                foreach (byte b in buffer)
                {
                    Console.Write(b.ToString("X2") + " ");
                    
                    // TODO append to file
                    //mStream.WriteByte(unescaped);
                    //mStream.WriteByte(b);
                    if (filestream_log != null)
                    {
                        filestream_log.WriteByte(b);
                    }
                }

                //ThreadSafeDelegate(delegate {
                //    labelBytesReceivedValue.Text = mStream.Length.ToString();
                //});


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void enableControls(bool enable)
        {

            try
            {
                foreach (Control item in this.Controls)
                {
                    if (item.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        item.Enabled = enable;
                    }
                }
            }
            catch (Exception ex)
            {
                //do nothing
                Console.WriteLine(ex.Message);
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(serialPort1.PortName))
                {
                    if (serialPort1.IsOpen)
                    {
                        boolConnected = true;
                        comboBoxComPort1.Enabled = false;
                    }
                    else
                    {
                        boolConnected = false;
                        comboBoxComPort1.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                boolConnected = false;
                comboBoxComPort1.Enabled = true;
                Console.WriteLine(ex.Message);
            }


            if (boolConnected)
            {
                buttonConnect.Text = "&Disconnect";
                toolStripStatusLabel1.Text = "Connected to port:  " + serialPort1.PortName;

                //TESTING!!!
                // if connected... and XON/XOFF is selected... send XON if ready to receive... every second?
                if (serialPort1.Handshake == Handshake.XOnXOff)
                {
                    if (serialPort1.BytesToRead == 0)
                    {
                        //if ( DateTime.Now - last_xon ) 
                        //TimeSpan ts = new TimeSpan();
                        TimeSpan elapsed = DateTime.Now - last_xon;
                        if (elapsed.TotalMilliseconds >= 1000)
                        {
                            serialPort1.Write(new byte[] { XON_CHARACTER }, 0, 1);
                            last_xon = DateTime.Now;
                        }
                    }

                }


            }
            else
            {
                buttonConnect.Text = "&Connect";
                toolStripStatusLabel1.Text = "Disconnected";
            }

            buttonStart.Text = bool_logging ? "&Stop" : "&Start";

            enableControls(!boolConnected);

            //if (mStream != null)
            //{
            //    labelBytesReceivedValue.Text = mStream.Length.ToString();
            //}

            if (filestream_log != null)
            {
                if (filestream_log.CanWrite)
                    labelBytesReceivedValue.Text = filestream_log.Length.ToString();
            }

        }

        //private void buttonClear_Click(object sender, EventArgs e)
        //{
        //    if (mStream != null)
        //    {
        //        if (mStream.Length > 0)
        //        {
        //            if (MessageBox.Show("Clear existing data?",Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                mStream = new MemoryStream();
        //            }
        //        }
        //    }
        //}

        private void linkLabelFilename_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            choose_log_file();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(logFilename))
            {
                choose_log_file();

                if (string.IsNullOrEmpty(logFilename))
                    return;
            }

            //if (!boolConnected)
            //{
            //    return;
            //}

            if (bool_logging)
            {
                stop_logging();
            }
            else
            {
                start_logging();
            }

        }

        private void stop_logging()
        {
            try
            {
                filestream_log.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            //buttonStart.Text = "&Start";
            bool_logging = false;
        }

        private void start_logging()
        {

            try
            {
                FileMode filemode = checkBoxAppend.Checked ? FileMode.Append : FileMode.Create;
                filestream_log = new FileStream(logFilename, filemode, FileAccess.Write);

                //buttonStart.Enabled = false;
                //buttonStop.Enabled = true;
                buttonStart.Text = "&Stop";
                bool_logging = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void checkBoxAppend_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxAppend.Text = checkBoxAppend.Checked ? "Yes" : "No";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
