// Use this code inside a project created with the Visual C# > Windows Desktop > Console Application template.
// Replace the code in Program.cs with this code.

using System;
using System.IO.Ports;
using System.Threading;

public class PortChat
{
    static bool _continue;
    static SerialPort _serialPort;

    public static void Main()
    {
        string name;
        string message;
        StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
        Thread readThread = new Thread(Read);

        //实例化一个serialPort对象以进行操作
        _serialPort = new SerialPort();

        //初始化设置
        _serialPort.PortName = SetPortName(_serialPort.PortName);//设置串口名字
        _serialPort.BaudRate = SetPortBaudRate(_serialPort.BaudRate);//设置波特率
        _serialPort.Parity = SetPortParity(_serialPort.Parity);//设置奇偶校验位
        _serialPort.DataBits = SetPortDataBits(_serialPort.DataBits);//设置数据传输位位数
        _serialPort.StopBits = SetPortStopBits(_serialPort.StopBits);//设置停止位位数
        _serialPort.Handshake = SetPortHandshake(_serialPort.Handshake);//设置连接方法

        //设置最大时间*/
        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;

        _serialPort.Open();
        _continue = true;
        readThread.Start();
        //设置用户名
        Console.Write("设置您的ID: ");
        name = Console.ReadLine();

        Console.WriteLine("打出\"退出\"退出");
        Console.WriteLine("打出\"设置\"设置");

        while (_continue)
        {
            message = Console.ReadLine();

            if (stringComparer.Equals("退出", message))
            {
                _continue = false;
            }
            else if (stringComparer.Equals("设置", message))
            {
                SetUp(_serialPort);
            }
            else
            {
                _serialPort.WriteLine(message);
                Console.WriteLine(String.Format("{1},<SEND>: {0}",  message,DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.ffff")));
            }
        }

        readThread.Join();
        _serialPort.Close();
    }

    public static void SetUp(SerialPort _serialPort)
    {
        string idx = "0";
        Console.WriteLine("Menu\n请输入您想要更改的设置：(默认为不修改)");
        Console.Write("1:设置串口名字\n2:设置波特率\n3:设置奇偶校验位\n4:设置数据传输位位数\n5:设置停止位位数\n6:设置连接方法");
        idx = Console.ReadLine();
        if (idx == "1")
            _serialPort.PortName = SetPortName(_serialPort.PortName);//设置串口名字
        if (idx == "2")
            _serialPort.BaudRate = SetPortBaudRate(_serialPort.BaudRate);//设置波特率
        if (idx == "3")
            _serialPort.Parity = SetPortParity(_serialPort.Parity);//设置奇偶校验位
        if (idx == "4")
            _serialPort.DataBits = SetPortDataBits(_serialPort.DataBits);//设置数据传输位位数
        if (idx == "5")
            _serialPort.StopBits = SetPortStopBits(_serialPort.StopBits);//设置停止位位数
        if (idx == "6")
            _serialPort.Handshake = SetPortHandshake(_serialPort.Handshake);//设置连接方法
        else return;
        return;
    }

    public static void Read()
    {
        while (_continue)
        {
            try
            {
                string ss = _serialPort.ReadLine();
                Console.WriteLine(String.Format("{1},<RECV>: {0}", ss, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.ffff")));
                
            }
            catch (TimeoutException) { }
        }
    }

    //修改虚拟串口
    public static string SetPortName(string defaultPortName)
    {
        string portName;

        Console.WriteLine("可用的串口有:");
        foreach (string s in SerialPort.GetPortNames())
        {
            Console.WriteLine("   {0}", s);
        }

        Console.Write("请输入串口：\n (默认为: {0}): ", defaultPortName);
        portName = Console.ReadLine();

        //检验输入合法性
        if (portName == "" || !(portName.ToLower()).StartsWith("com"))
        {
            portName = defaultPortName;
        }
        return portName;
    }
    //修改波特率
    public static int SetPortBaudRate(int defaultPortBaudRate)
    {
        string baudRate;

        Console.Write("请输入波特率：\n(默认：{0}): ", defaultPortBaudRate);
        baudRate = Console.ReadLine();

        if (baudRate == "")
        {
            baudRate = defaultPortBaudRate.ToString();
        }

        return int.Parse(baudRate);
    }

    // 修改奇偶校验
    public static Parity SetPortParity(Parity defaultPortParity)
    {
        string parity;

        Console.WriteLine("支持的奇偶校验方式:");
        Console.WriteLine("0.无校验");
        Console.WriteLine("1.奇校验");
        Console.WriteLine("2.偶校验");
        
        Console.Write("请输入奇偶校验方式 (默认： 0.无校验):");
        parity = Console.ReadLine();

        if (parity == "")
        {
            parity = defaultPortParity.ToString();
        }
        if (parity == "0")//无校验
        {
            parity = "None";
        }
        if (parity == "1")//奇校验
        {
            parity = "Odd";
        }
        if (parity == "2")//偶校验
        {
            parity = "Even";
        }
        return (Parity)Enum.Parse(typeof(Parity), parity, true);
    }
    //修改传输位
    public static int SetPortDataBits(int defaultPortDataBits)
    {
        string dataBits;

        Console.Write("输入传输位 (默认: {0}): ", defaultPortDataBits);
        dataBits = Console.ReadLine();

        if (dataBits == "")
        {
            dataBits = defaultPortDataBits.ToString();
        }

        return int.Parse(dataBits.ToUpperInvariant());
    }

    //修改终止位
    public static StopBits SetPortStopBits(StopBits defaultPortStopBits)
    {
        string stopBits;
        int idx = 0;
        Console.WriteLine("支持的停止位选项:");
        foreach (string s in Enum.GetNames(typeof(StopBits)))
        {
            Console.WriteLine(" {1}:  {0}", s,idx++);
        }
        
        Console.Write("请输入停止位 (不支持\"None\"的情况 \n" +
         "这将会导致越界错误. \n (默认: {0})):", defaultPortStopBits.ToString());
        stopBits = Console.ReadLine();
        if (stopBits == "0")
        {
            stopBits = "None";
        }
        if (stopBits == "1")
        {
            stopBits = "One";
        }
        if (stopBits == "2")
        {
            stopBits = "Two";
        }
        if (stopBits == "3")
        {
            stopBits = "OnePointFive";
        }
        if (stopBits == "")
        {
            stopBits = defaultPortStopBits.ToString();
        }

        return (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
    }
    //修改握手控件
    public static Handshake SetPortHandshake(Handshake defaultPortHandshake)
    {
        string handshake;
        int idx = 0;
        Console.WriteLine("支持的握手控件有:");
        foreach (string s in Enum.GetNames(typeof(Handshake)))
        {
            Console.WriteLine(" {1}:  {0}协议", s, idx++);
        }

        Console.Write("请输入握手控件 (默认: {0}协议):", defaultPortHandshake.ToString());
        handshake = Console.ReadLine();

        if (handshake == "")
        {
            handshake = defaultPortHandshake.ToString();
        }

        return (Handshake)Enum.Parse(typeof(Handshake), handshake, true);
    }
}
