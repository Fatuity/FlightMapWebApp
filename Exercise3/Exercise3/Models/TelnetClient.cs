﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise3.Models.Interface;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Exercise3.Models
{
    //A class that represents a telnet client.
    public class TelnetClient : ITelnetClient, ITelnetClientFactory
    {
        private TcpClient client;
        private NetworkStream stream;
        private StreamReader reader;
        private BinaryWriter writer;
        Boolean connected = false;
        //a function that connects to a server.
        public void Connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            client.Connect(ep);
            stream = client.GetStream();
            
            reader = new StreamReader(stream);
            writer = new BinaryWriter(stream);
            connected = true;
        }
        //a function that disconnects from a server.
        public void Disconnect()
        {
            if (!connected)
                return;
            
            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();
            
        }
        // a function to read info from server.
        public string Read()
        {
            if (!connected)
                return null;
            string value = "";
            try
            {
                value = reader.ReadLine();
            }
            finally
            {
                
            }


            return value;
        }
        //a function to write commands to a server.
        public void Write(string command)
        {
            if (!connected)
                return;
            //add \r\n because this is a telnet client.
            command += "\r\n";
            //encode and send the message.
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(command);
            writer.Write(bytes,0,bytes.Length);
            writer.Flush();
        }
        public ITelnetClient New()
        {
            return new TelnetClient();
        }
    }
}
