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
using System.Threading;

namespace 串口通讯器
{
    public partial class 串口通讯器 : Form
    {

        public SerialPort ComDevice = new SerialPort();

        public 串口通讯器()
        {
            InitializeComponent();

            InitralConfig();
        }

        private void InitralConfig()
        {
            comboBox_Port.Items.AddRange(SerialPort.GetPortNames());


            if (comboBox_Port.Items.Count > 0)
            {
                comboBox_Port.SelectedIndex = 0;
            }
            else
            {
                comboBox_Port.Text = "未检测到串口";
            }

            //波特率
            comboBox_BaudRate.Items.Add("110");
            comboBox_BaudRate.Items.Add("300");
            comboBox_BaudRate.Items.Add("1200");
            comboBox_BaudRate.Items.Add("2400");
            comboBox_BaudRate.Items.Add("4800");
            comboBox_BaudRate.Items.Add("9600");
            comboBox_BaudRate.SelectedIndex = 5;

            //数据位
            comboBox_DataBits.Items.Add("5");
            comboBox_DataBits.Items.Add("6");
            comboBox_DataBits.Items.Add("7");
            comboBox_DataBits.Items.Add("8");
            comboBox_DataBits.SelectedIndex = 3;

            //停止位
            comboBox_StopBits.Items.Add("1");
            comboBox_StopBits.Items.Add("2");
            comboBox_StopBits.SelectedIndex = 0;

            //校验位
            comboBox_CheckBits.Items.Add("无");
            comboBox_CheckBits.SelectedIndex = 0;


            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);

        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //实现数据的解码与显示
            AddData(ReDatas);
        }

        public void AddData(byte[] data)
        {
            AddContent(new ASCIIEncoding().GetString(data));
        }

        private void AddContent(string content)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                textBox_Receive.AppendText(content);
            }));
        }

        private void button_Switch_Click(object sender, EventArgs e)
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                ComDevice.PortName = comboBox_Port.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(comboBox_BaudRate.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(comboBox_CheckBits.SelectedIndex.ToString());
                ComDevice.DataBits = Convert.ToInt32(comboBox_DataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(comboBox_StopBits.SelectedItem.ToString());
                try
                {
                    //开启串口
                    ComDevice.Open();
                    button_Send.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Switch.Text = "关闭";
                //pictureBox_Status.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                    button_Send.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_Switch.Text = "开启";
                //pictureBox_Status.BackgroundImage = Properties.Resources.red;
            }

            comboBox_Port.Enabled = !ComDevice.IsOpen;
            comboBox_BaudRate.Enabled = !ComDevice.IsOpen;
            comboBox_DataBits.Enabled = !ComDevice.IsOpen;
            comboBox_StopBits.Enabled = !ComDevice.IsOpen;
            comboBox_CheckBits.Enabled = !ComDevice.IsOpen;
        }

        private void baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void button_Send_Click(object sender, EventArgs e)
        //{
        //    if (textBox_Receive.Text.Length > 0)
        //    {
        //        textBox_Receive.AppendText("\n");
        //    }

        //    byte[] sendData = null;

        //    sendData = Encoding.ASCII.GetBytes(textBox_Send.Text.Trim());

        //    SendData(sendData);
        //}

        public bool SendData(string data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //将消息传递给串口
                    ComDevice.Write(data);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void 串口通讯器_Load(object sender, EventArgs e)
        {

        }

        private void button_Switch_Click_1(object sender, EventArgs e)
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                ComDevice.PortName = comboBox_Port.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(comboBox_BaudRate.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(comboBox_CheckBits.SelectedIndex.ToString());
                ComDevice.DataBits = Convert.ToInt32(comboBox_DataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(comboBox_StopBits.SelectedItem.ToString());
                try
                {
                    //开启串口
                    ComDevice.Open();
                    button_Send.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Switch.Text = "关闭";
                //pictureBox_Status.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                    button_Send.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_Switch.Text = "开启";
                //pictureBox_Status.BackgroundImage = Properties.Resources.red;
            }

            comboBox_Port.Enabled = !ComDevice.IsOpen;
            comboBox_BaudRate.Enabled = !ComDevice.IsOpen;
            comboBox_DataBits.Enabled = !ComDevice.IsOpen;
            comboBox_StopBits.Enabled = !ComDevice.IsOpen;
            comboBox_CheckBits.Enabled = !ComDevice.IsOpen;
        }

        private void button_Send_Click_1(object sender, EventArgs e)
        {
            if (textBox_Send.Text.Length > 0)
            {
                textBox_Send.AppendText("\n");
            }

            //byte[] sendData = null;

            //sendData = Encoding.ASCII.GetBytes(textBox_Send.Text.Trim());

            //SendData(sendData);

           


            //int index = textBox_Send.

            //string sendData = textBox_Send.Lines[index];

            string sendData = textBox_Send.Text;

            SendData(sendData);

            textBox_Send.Text = "";
        }
    }
}
