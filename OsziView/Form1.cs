using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace OsziView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SerialPort port = new SerialPort("COM1", 4800, Parity.None, 8, StopBits.One);
            port.Handshake = Handshake.RequestToSend;
            // Open the port for communications
            port.Open();
  
            // Write a string
            port.Write("S1\r");
            label1.Text = port.ReadLine();
  
            // Close the port
            port.Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
