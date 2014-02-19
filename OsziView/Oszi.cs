using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace OsziView
{
    class Oszi
    {
        static SerialPort serialPort;

        Oszi()
        {
            serialPort = new SerialPort("COM1:", 9600, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.RequestToSend;
            serialPort.NewLine = "\r";
        }

        public bool checkTransmission()
        {
            string answer;

            serialPort.Open();
            serialPort.WriteLine("S1");
            answer = serialPort.ReadLine();
            serialPort.Close();

            if (answer.Equals("A"))
                return true;
            else
                return false;
        }

        public void getWaveforn(Waveform waveform)
        {
            string answer;

            serialPort.Open();
            serialPort.WriteLine("R" + waveform.memoryNumber + "(" + waveform.frontAddress + 
                                 "," + waveform.numberData + ",B)");
            answer = serialPort.ReadLine();

            for (int i = waveform.frontAddress; i < waveform.numberData; i++)
            {
                waveform.data[i] = Convert.ToUInt16(answer.ElementAt(i + 14));
            }

            serialPort.Close();
        }

        public void sendWaveforn()
        {

        }

        public void getSettings()
        {

        }

        public void sendSettings()
        {

        }


        public Parity S { get; set; }
    }

    class Waveform
    {
        public char memoryNumber;
        public UInt16 frontAddress;
        public UInt16 numberData;
        public UInt16 [] data;

        Waveform()
        {
            data = new UInt16[1000];
        }
    }
}
