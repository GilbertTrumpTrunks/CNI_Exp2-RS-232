using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ComDataTest
{
    public partial class ComDataTest : Form
    {
        public ComDataTest()
        {
            InitializeComponent();
        }

        public string strPortName1;
        public string strPortName2;
        public int BaudRatenumber;
        public string data;
        public int databits;
        public string parity;

        private void ComDataTest_Load(object sender, EventArgs e)
        {
            //获取串口号
            cmdportname1.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            cmdportname2.DataSource = System.IO.Ports.SerialPort.GetPortNames();
            CmdCloseSerialPort.Enabled = false;

        }

        private void CmdOpenSerialPort_Click(object sender, EventArgs e)
        {
            //关闭打开按钮，启动关闭按钮
            CmdOpenSerialPort.Enabled = false;
            CmdCloseSerialPort.Enabled = true;

            //获取串口名
            strPortName1 = cmdportname1.SelectedItem.ToString();
            strPortName2 = cmdportname2.SelectedItem.ToString();

            //获取波特率
            BaudRatenumber = int.Parse(cmdbaudrate.SelectedItem.ToString());

            //获取数据位和奇偶校验
            databits =int.Parse(cmbBits.SelectedItem.ToString());
            parity = cmbParity.SelectedItem.ToString();
            //打开串口1
            serialPort1.PortName = strPortName1;
            serialPort1.BaudRate = BaudRatenumber;
            serialPort1.DataBits = databits;

            if (cmbParity.SelectedItem.ToString() == "无")
                serialPort1.Parity = Parity.None;
            else if (cmbParity.SelectedItem.ToString() == "奇")
                serialPort1.Parity = Parity.Odd;
            else if (cmbParity.SelectedItem.ToString() == "偶")
                serialPort1.Parity = Parity.Even;

            serialPort1.Open();

            //打开串口2
            serialPort2.PortName = strPortName2;
            serialPort2.BaudRate = BaudRatenumber;
            serialPort2.DataBits = databits;

            if (cmbParity.SelectedItem.ToString() == "无")
                serialPort2.Parity = Parity.None;
            else if (cmbParity.SelectedItem.ToString() == "奇")
                serialPort2.Parity = Parity.Odd;
            else if (cmbParity.SelectedItem.ToString() == "偶")
                serialPort2.Parity = Parity.Even;

            serialPort2.Open();
            //打开成功后提示
            if (serialPort1.IsOpen)
            {
                MessageBox.Show(strPortName1 + "打开成功", "提示");
            }
            if (serialPort2.IsOpen)
            {
                MessageBox.Show(strPortName2 + "打开成功", "提示");
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            string outdata = TextSend.Text;
            if (outdata == "")
            {
                MessageBox.Show("发送的数据不能为空！", "提醒！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            serialPort1.WriteLine(outdata);
            data = serialPort2.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void DisplayText(object sender, EventArgs e)
        {
            TextReceive.Text = TextReceive.Text + data;
        }

        private void CmdCloseSerialPort_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort2.Close();
            CmdOpenSerialPort.Enabled = true;
        }
        private void ComDataTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            if (serialPort2.IsOpen) serialPort2.Close();
        }


    }
}

