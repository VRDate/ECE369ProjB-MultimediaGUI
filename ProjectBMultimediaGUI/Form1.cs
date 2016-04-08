﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets; // For network programming
using System.Net; // For network programming
using System.Media; // For playing .WAV files
using System.IO; // For playing .WAV files (SoundPlayer in System.Media accepts either a filepath or an IO stream.)

namespace ProjectBMultimediaGUI
{

    public partial class Form1 : Form
    {
        private delegate void ObjectDelegate(string msg, IPEndPoint sender);
        private delegate void LabelChanger(string msg);

        const int PUBLISH_PORT_NUMBER = 8030; // Port number used for publish (UDP communications)
        const int TCP_PORT_NUMBER = 8031; // Port number used for the rest of communications (TCP communications)
        IPAddress me = GetLocalIP(); // me is the IPAddress that your machine currently owns on the local network

        const string CLIENT_ANNOUNCE = "[ECE 369] Multimedia client publish"; // UDP datagram to be sent when the client is announcing itself
        const string CLIENT_DISCONNECT = "[ECE 369] Multimedia client disconnect"; // UDP datagram to be sent when the client is announcing that it is disconnecting

        UdpClient pub = new UdpClient(PUBLISH_PORT_NUMBER, AddressFamily.InterNetwork); // Creates a new UDP client capable of communicating on a network on port defined by const, via IPv4 addressing
        IPEndPoint UDP_BROADCAST = new IPEndPoint(IPAddress.Broadcast, PUBLISH_PORT_NUMBER); // Broadcast address and port

        TcpListener tlisten = new TcpListener(IPAddress.Any,TCP_PORT_NUMBER); // Sets up a listener that looks for TCP connections
        TcpClient tcprecvr;

        Stream wavstream = new MemoryStream(); // Initializes a memory stream that will hold .wav file data when being written to. Will be reinitialized in packet receiving functions

        Timer tmr = new Timer(); // Timer used to announce client on the local network every 250 ms

        bool isClosing = false; // Used to determine if program is closing

        byte[] readbuf = new byte[1024];
        long wavpos = 0;

        public Form1()
        {
            InitializeComponent();
            #region Timer Setup
            tmr.Interval = 250;
            tmr.Start();
            tmr.Tick += new EventHandler(tmr_Tick);
            #endregion
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            if (!isClosing)
                Announce_Client_Connect(); // Announce the client is connected every 250 ms
        }

        private void playpauseBUT_MouseClick(object sender, MouseEventArgs e)
        {
            Button sbut = (sender as Button);
            SoundPlayer splayer = new SoundPlayer(wavstream);
            if (sbut.ImageIndex == 0) // If the PLAY button was clicked
            { // Initiate play functions
                //splayer.Load();
                //splayer.LoadAsync();
                if (wavstream.CanRead && wavstream.Length > 0)
                {
                    splayer.Stream.Position = wavpos;
                    //splayer.PlaySync();
                    splayer.Play();
                }
                sbut.ImageIndex = 1; // Change the button to show PAUSE
            }
            else // If the PAUSE button was clicked
            {
                splayer.Stop();
                //wavpos = splayer.Stream.Position;
                sbut.ImageIndex = 0; // Change the button to show PLAY

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            butIML.ImageSize = new Size(playpauseBUT.Size.Width-1,playpauseBUT.Size.Height-1); // This ensures the play and pause buttons are always the same size as the button they are encased in
            stopBUT.Size = playpauseBUT.Size; // Ensures the stop button is the same size as the play/pause button.
            stopBUT.Location = new Point(stopBUT.Location.X, playpauseBUT.Location.Y);

            pub.AllowNatTraversal(false); // Disables the ability for the program to communicate with the outside world, for security purposes
            try { pub.BeginReceive(new AsyncCallback(RecvPub), null); }
            catch(Exception err) { MessageBox.Show("An error occurred!\n"+err.ToString()); Application.Exit(); }

            tlisten.AllowNatTraversal(false);
            tlisten.Start();
            tlisten.BeginAcceptTcpClient(new AsyncCallback(RecvTcp), null);

            Announce_Client_Connect();
        }

        private void stopBUT_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void mainMS_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black), mainMS.Left, mainMS.Bottom-1, mainMS.Right, mainMS.Bottom-1); // Draws a border on the bottom of the main menu strip.
        }

        private void RecvPub(IAsyncResult res) // Function used to handle received UDP messages
        {
            IPEndPoint recv = new IPEndPoint(IPAddress.Any, PUBLISH_PORT_NUMBER);
            byte[] message = null;
            string dmessage;
            if (!isClosing)
                message = pub.EndReceive(res, ref recv);

            if(message != null) // If a message was received
            {
                ObjectDelegate del = new ObjectDelegate(HandleUDPDatagram);
                dmessage = Encoding.ASCII.GetString(message);
                del.Invoke(dmessage, recv);
                HandleUDPDatagram(dmessage, recv);
            }

            if (!isClosing)
                pub.BeginReceive(new AsyncCallback(RecvPub), null);
        }

        private void RecvTcp(IAsyncResult res)
        {
            LabelChanger lblchgr = new LabelChanger(dataavailable); // Used for cross thread operations on dataavailLBL

            wavstream.Flush(); // Clear the wav stream, we don't want two wav files in one stream, it would cause errors.

            lblchgr.Invoke("Data unavailable."); // No data available yet.

            tlisten.AcceptTcpClient(); // Accept the incoming TCP connection.
            tcprecvr = tlisten.EndAcceptTcpClient(res); // Create a new TCP connection with the requester
            NetworkStream stream = tcprecvr.GetStream(); // Get the TCP network stream
            
            if (stream.CanRead)
                stream.BeginRead(readbuf, 0, readbuf.Length, new AsyncCallback(RecvTCPData), null);
            else
            {
                tcprecvr.Close();
                MessageBox.Show("An error has occurred. Unable to read incoming TCP stream.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void RecvTCPData(IAsyncResult res)
        {
            LabelChanger lblchgr = new LabelChanger(dataavailable); // Used for cross thread operations on dataavailLBL

            wavpos = 0; // Reset the WAV stream position

            NetworkStream stream = tcprecvr.GetStream(); // Get the TCP data stream
            int nbytes = stream.EndRead(res); // Get the number of bytes read
            if (nbytes == 0) // Finished reading
            {
                tcprecvr.Close(); // Close the TCP connection
                lblchgr.Invoke("Data available!"); // Inform the user there is a .WAV file to be played
                return;
            }
            else // Not finished reading, data in buffer
            {
                wavstream.Write(readbuf, 0, readbuf.Length); // Write WAV data to wav stream
                stream.BeginRead(readbuf, 0, readbuf.Length, new AsyncCallback(RecvTCPData), null); // begin read again
            }
        }

        private void dataavailable(string msg)
        {
            if(InvokeRequired)
            {
                LabelChanger method = new LabelChanger(dataavailable);
                Invoke(method, msg);
                return;
            }
            dataavailLBL.Text = "Data available!";
        }

        private void HandleUDPDatagram(string msg, IPEndPoint sender) // Used for handling UDP messages
        {
            if (!sender.Address.Equals(me)) // Verifies the UDP datagram received isn't from your own machine.
            { //This is done because some UDP datagrams are sent to the broadcast address, which means we receive what we've sent. We obviously don't want packets from ourselves so we block them.
                if (InvokeRequired && !isClosing) // Used for handling thread magic. Please don't ask me to explain this.
                {
                    ObjectDelegate method = new ObjectDelegate(HandleUDPDatagram);
                    Invoke(method, msg, sender);
                    return;
                }

                switch (msg)
                {
                    case CLIENT_ANNOUNCE: // If we've received a client connection message
                        if (!hostsLB.Items.Contains(sender.Address)) // If the client is not already in the list box
                            hostsLB.Items.Add(sender.Address); // Add the client to the listbox of clients
                        break;
                    case CLIENT_DISCONNECT: // If we've received a client disconnection message
                        if (hostsLB.Items.Contains(sender.Address)) // If the client is in the listbox
                            hostsLB.Items.Remove(sender.Address); // Remove the client from the listbox of clients
                        break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
            Announce_Client_Disconnect(); // Declare your disconnection to the other clients on the network
        }

        private void Announce_Client_Disconnect()
        {
            byte[] dgram = Encoding.ASCII.GetBytes(CLIENT_DISCONNECT); // Encode the client disconnection message into an array of bytes
            pub.Send(dgram, dgram.Length, UDP_BROADCAST); // Send the disconnection message off to all clients on the network via the broadcast address
        }

        private void Announce_Client_Connect()
        {
            byte[] dgram = Encoding.ASCII.GetBytes(CLIENT_ANNOUNCE); // Encode the client connection message into an array of bytes
            pub.Send(dgram, dgram.Length, UDP_BROADCAST); // Send the connection message off to all clients on the network via the broadcast address
        }

        private void OpenBrowse()
        { // This function allows the user to browse for a file and then sets the file path textbox with the path of the file.
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.CheckFileExists = true; fopen.CheckPathExists = true; fopen.Filter = "WAV Files|*.wav";
            fopen.ShowDialog();
            filepathTB.Text = fopen.FileName;
        }

        private void sendwavBUT_MouseClick(object sender, MouseEventArgs e)
        {
            if (hostsLB.Items.Count > 0 && hostsLB.SelectedItem != null)
            {
                TcpClient tcpsender = new TcpClient((hostsLB.SelectedItem as IPAddress).ToString(),TCP_PORT_NUMBER); // Connect to the client

                sendwavBUT.Enabled = false; filesendPB.UseWaitCursor = true;
                try
                {
                    FileStream fs = new FileStream(filepathTB.Text, FileMode.Open);
                    while(fs.CanRead && fs.Position!=fs.Length)
                    {
                        tcpsender.GetStream().WriteByte((byte)fs.ReadByte());
                        filesendPB.Value = (int)((fs.Position / fs.Length) * 100);
                    }
                    fs.Close();
                }
                catch(Exception err) { MessageBox.Show(err.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }

                /*do
                {
                    int dat = tcpsender.GetStream().ReadByte();
                    if (dat == '!' || dat == -1)
                        break;
                }
                while (tcpsender.GetStream().CanRead);*/

                MessageBox.Show("File send complete.");
                sendwavBUT.Enabled = true; filesendPB.UseWaitCursor = false;
                tcpsender.Close();
            }
            else if (hostsLB.Items.Count <= 0)
                MessageBox.Show("There are no clients to send this file to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("You must select a client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static IPAddress GetLocalIP() // Has the machine report its local network IP address
        { // This code snippet has been taken from StackOverflow and adapted to return an IPAddress rather than a string
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
                if (ip.AddressFamily.ToString() == "InterNetwork")
                    return ip;

            return null;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        { Application.Exit(); }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        { OpenBrowse(); }
        private void browseBUT_MouseClick(object sender, MouseEventArgs e)
        { OpenBrowse(); }
    }
}
