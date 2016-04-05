using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoInput
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CheckCard()
        {
            SerialPort arduinoSerialPortCom6 = new SerialPort("COM6");

            arduinoSerialPortCom6.BaudRate = 9600;
            arduinoSerialPortCom6.Parity = Parity.None;
            arduinoSerialPortCom6.StopBits = StopBits.One;
            arduinoSerialPortCom6.DataBits = 8;
            arduinoSerialPortCom6.Handshake = Handshake.None;
            arduinoSerialPortCom6.RtsEnable = true;

            arduinoSerialPortCom6.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            if(!arduinoSerialPortCom6.IsOpen)
            {
                try
                {
                    arduinoSerialPortCom6.Open();
                    MessageBox.Show("Press OK to continue...");
                    arduinoSerialPortCom6.Close();
                }
                catch
                {
                    MessageBox.Show("COM-Error");
                }
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            MessageBox.Show(indata);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckCard();
        }
    }
}
