using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace OsziView
{
    static class Oszi
    {
        static SerialPort serialPort;

        public static void init()
        {
            serialPort = new SerialPort("COM2", 4800, Parity.None, 8, StopBits.One);
            serialPort.Handshake = Handshake.RequestToSend;
            serialPort.NewLine = "\r";
            serialPort.Encoding = Encoding.UTF8;
        }

        public static bool checkTransmission()
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

        public static void getWaveforn(Waveform waveform)
        {
            string answer;
            string message = "R" + waveform.memoryNumber + "(" + waveform.frontAddress +
                                 "," + waveform.numberData + ",B)";

            serialPort.Open();
            serialPort.WriteLine(message);
            //answer = serialPort.ReadLine();

            for (int i = 0; i < 14; i++)
            {
                serialPort.ReadByte();
            }

            for (int i = 0; i < 1000; i++)
            {
                waveform.data[i] = serialPort.ReadByte();
            }

            serialPort.Close();
        }

        public static void sendWaveforn()
        {
           
        }

        public static void getSettings()
        {

        }

        public static void sendSettings()
        {

        }


        public static Parity S { get; set; }
    }

    class Waveform
    {
        public string memoryNumber;
        public string Name;
        public string frontAddress;
        public string numberData;
        public int [] data;

        public struct structCondition
        {
            int i;
        };
        public structCondition condition;

        public Waveform()
        {
            condition = new structCondition();
            data = new int[1000];
        }

    }
}
