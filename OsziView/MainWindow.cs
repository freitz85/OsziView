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
    public partial class MainWindow : Form
    {
        Waveform wave1, wave2, waveA, waveB;

        public MainWindow()
        {
            InitializeComponent();
            wave1 = new Waveform();
            wave2 = new Waveform();
            waveA = new Waveform();
            waveB = new Waveform();

            wave1.memoryNumber = "1";
            wave1.frontAddress = "0000";
            wave1.numberData = "1000";
           // Oszi oszi = new Oszi();
            Oszi.init();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SerialPort port = new SerialPort("COM1", 4800, Parity.None, 8, StopBits.One);
        //    port.Handshake = Handshake.RequestToSend;
        //    // Open the port for communications
        //    port.Open();
  
        //    // Write a string
        //    port.Write("S1\r");
        //    label1.Text = port.ReadLine();
  
        //    // Close the port
        //    port.Close();
        //}

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var checkedButton = groupBoxChannel.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (checkedButton == radioButtonWave1)
            {
                Oszi.getWaveforn(wave1);
                this.chart1.Series["Series1"].Points.Clear();

                foreach (var x in wave1.data.Skip(15))
                {
                    this.chart1.Series["Series1"].Points.AddY(x);
                }
            }

        }

        private void testCommunicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Oszi.checkTransmission())
                MessageBox.Show("Success");
            else
                MessageBox.Show("Failure");
        }
    }
}
