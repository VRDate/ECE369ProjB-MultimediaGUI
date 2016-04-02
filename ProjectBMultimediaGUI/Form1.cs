using System;
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

namespace ProjectBMultimediaGUI
{
    public partial class Form1 : Form
    {
        private delegate void ObjectDelegate(string msg, IPEndPoint sender);

        const int PUBLISH_PORT_NUMBER = 8030; // Port number used for publish (UDP communications)
        const int TCP_PORT_NUMBER = 8031; // Port number used for the rest of communications (TCP communications)

        const string CLIENT_ANNOUNCE = "[ECE 369] Multimedia client publish"; // UDP datagram to be sent when the client is announcing itself
        const string CLIENT_DISCONNECT = "[ECE 369] Multimedia client disconnect"; // UDP datagram to be sent when the client is announcing that it is disconnecting

        UdpClient pub = new UdpClient(PUBLISH_PORT_NUMBER, AddressFamily.InterNetwork); // Creates a new UDP client capable of communicating on a network on port defined by const, via IPv4 addressing
        IPEndPoint UDP_BROADCAST = new IPEndPoint(IPAddress.Broadcast, PUBLISH_PORT_NUMBER); // Broadcast address and port

        IPAddress me = GetLocalIP(); // me is the IPAddress that your machine currently owns on the local network

        Timer tmr = new Timer(); // Timer used to announce client on the local network every 250 ms

        bool isClosing = false; // Used to determine if program is closing

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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        { Application.Exit(); }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fopen = new OpenFileDialog();
            fopen.CheckFileExists = true; fopen.CheckPathExists = true; fopen.Filter = "WAV Files|*.wav";
            fopen.ShowDialog();
        }

        private void playpauseBUT_MouseClick(object sender, MouseEventArgs e)
        {
            (sender as Button).ImageIndex = ((sender as Button).ImageIndex == 0) ? 1 : 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            butIML.ImageSize = new Size(playpauseBUT.Size.Width-1,playpauseBUT.Size.Height-1); // This ensures the play and pause buttons are always the same size as the button they are encased in
            stopBUT.Size = playpauseBUT.Size; // Ensures the stop button is the same size as the play/pause button.
            stopBUT.Location = new Point(stopBUT.Location.X, playpauseBUT.Location.Y);

            pub.AllowNatTraversal(false); // Disables the ability for the program to communicate with the outside world, for security purposes
            try { pub.BeginReceive(new AsyncCallback(RecvPub), null); }
            catch(Exception err) { MessageBox.Show("An error occurred!\n"+err.ToString()); Application.Exit(); }

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
                ObjectDelegate del = new ObjectDelegate(HandleMsg);
                dmessage = Encoding.ASCII.GetString(message);
                del.Invoke(dmessage, recv);
                HandleMsg(dmessage, recv);
            }

            if (!isClosing)
                pub.BeginReceive(new AsyncCallback(RecvPub), null);
        }

        private void HandleMsg(string msg, IPEndPoint sender) // Used for handling UDP messages
        {
            if (!sender.Address.Equals(me)) // Verifies the UDP datagram received isn't from your own machine.
            { //This is done because some UDP datagrams are sent to the broadcast address, which means we receive what we've sent. We obviously don't want packets from ourselves so we block them.
                if (InvokeRequired) // Used for handling thread magic. Please don't ask me to explain this.
                {
                    ObjectDelegate method = new ObjectDelegate(HandleMsg);
                    Invoke(method, msg, sender);
                    return;
                }

                switch (msg)
                {
                    case CLIENT_ANNOUNCE:
                        if (!hostsLB.Items.Contains(sender.Address)) // If the client is not already in the list box
                            hostsLB.Items.Add(sender.Address);
                        break;
                    case CLIENT_DISCONNECT:
                        if (hostsLB.Items.Contains(sender.Address))
                            hostsLB.Items.Remove(sender.Address);
                        break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
            Announce_Client_Disconnect();
        }

        private void Announce_Client_Disconnect()
        {
            byte[] dgram = Encoding.ASCII.GetBytes(CLIENT_DISCONNECT);
            pub.Send(dgram, dgram.Length, UDP_BROADCAST);
        }

        private void Announce_Client_Connect()
        {
            byte[] dgram = Encoding.ASCII.GetBytes(CLIENT_ANNOUNCE);
            pub.Send(dgram, dgram.Length, UDP_BROADCAST);
        }

        static IPAddress GetLocalIP() // Has the machine report its local network IP address
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    return ip;
                }
            }
            return null;
        }
    }
}
