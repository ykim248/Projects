using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;

namespace Server
{
    public partial class Server : Form
    {
        bool ServerOnline = false;

        private delegate void srvDelegate(object temp, int loc);

        private TcpListener listener;
        private Socket connection;
        NetworkStream connectionStream = null;

        //  For Connection thread
        //Manages incoming connections
        private Thread WFCThread = null;
        private static BinaryFormatter formatter = new BinaryFormatter();
        Thread[] AllThreads;
        UserData[] AllUsers;
        int NextLocation = 0;

        TableStatus ServerTS = new TableStatus();
        Card[] Hand;


        public Server()
        {
            InitializeComponent();
            AllThreads = new Thread[5];
            AllUsers = new UserData[5];
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if(ServerOnline == false)
            {
                ServerOnline = true;
                Btn_Start.Text = "Stop";

                if (WFCThread == null || !WFCThread.IsAlive)
                {
                    //Is this a parameterized thread? No
                    WFCThread = new Thread(new ThreadStart(WFCProcedure));
                    WFCThread.Start();
                }
            }
            else
            {
                ServerOnline = false;
                Btn_Start.Text = "Start";

                connection.Close();
                listener.Stop();
                WFCThread.Abort();
                WFCThread.Join();

                for (int i = 0; i < 5; i++)
                {
                    if (AllUsers[i] != null)
                    {
                        AllUsers[i].ConnStream.Close();
                        AllThreads[i].Abort();
                        AllUsers[i] = null;
                    }
                }
            }
        }

        private void WFCProcedure()
        {
            int port = 3005;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            listener = new TcpListener(localAddr, port);
            listener.Start();

            try
            {
                while (ServerOnline)
                {
                    connection = listener.AcceptSocket(); //blocking call
                    
                    AllUsers[NextLocation] = new UserData();

                    //If we want to shut this down, we need the socket
                    AllUsers[NextLocation].TheSocket = connection;

                    //This is the stream (Think of it like a pointer to the client)
                    AllUsers[NextLocation].ConnStream = new NetworkStream(connection);
                    AllUsers[NextLocation].Connected = true;

                    //Can be used to track which client connection this is. 
                    //Might not need this, but we have it for debugging
                    AllUsers[NextLocation].ClientNumber = NextLocation;

                    AllThreads[NextLocation] = new Thread(new ParameterizedThreadStart(ClientHandler));
                    AllThreads[NextLocation].Start(AllUsers[NextLocation]);
                    NextLocation++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Server Shutting down!");
            }
        }

        private void ClientHandler(object NewClient)
        {
            UserData who = null;
            object IncomingPacket;
            if (NewClient is UserData)
            {
                who = (UserData)NewClient;
            }

            try
            {
                while (true)
                {
                    if (who != null)
                    {
                        IncomingPacket = formatter.Deserialize(who.ConnStream);  //Blocking Call

                        if (listBox1.InvokeRequired)
                        {
                            BeginInvoke(new srvDelegate(HandlePacket), IncomingPacket, who.ClientNumber);
                        }
                        for (int x = 0; x < 5; x++)
                        {
                            if (AllUsers[x] != null)
                            {
                                if (AllUsers[x].ClientNumber != who.ClientNumber)
                                    formatter.Serialize(AllUsers[x].ConnStream, IncomingPacket); //send new message to clients
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Client Died!");
            }
        }

        void SendToAllClients(Packet OutgoingPacket)
        {
            for (int i = 0; i < 5; i++)
            {
                if (AllUsers[i] != null)
                {
                    formatter.Serialize(AllUsers[i].ConnStream, OutgoingPacket);
                }
            }
        }

        private void DealerProcess(int TableNum, int Stage)
        {
            switch(Stage)
            {
                case 1:
                    BetPacket BP = new BetPacket();
                    BP.MinBet = 1;
                    BP.TableNum = TableNum;

                    Table DealerTable = ServerTS.Tables[TableNum];

                    foreach (UserData User in AllUsers)
                    {
                        foreach (Player Plr in DealerTable.Players)
                        {
                            if (Plr.username == User.Username)
                            {
                                formatter.Serialize(User.ConnStream, BP);
                            }
                        }
                    }

                    break;
            }
        }

        private void HandlePacket(object IncomingPacket, int UserIndex)
        {
            if (IncomingPacket is Chat)
            {
                Chat Msg = (Chat)IncomingPacket;
                listBox1.Items.Add(Msg.Text);

                for (int i =0; i < 5; i++)
                {
                    if (AllUsers[i] != null)
                    {
                        formatter.Serialize(AllUsers[i].ConnStream, Msg);
                        break;
                    }
                }
            }
            else if(IncomingPacket is SetUsername)
            {
                SetUsername Name = (SetUsername)IncomingPacket;
                AllUsers[UserIndex].Username = Name.Username;
            }
            else if(IncomingPacket is JoinTable)
            {
                JoinTable JT = (JoinTable)IncomingPacket;

                switch (JT.TableNumber)
                {
                    case 1:
                        ServerTS.Tables[0].AddAPlayer(AllUsers[UserIndex].Username);

                        if (ServerTS.Tables[0].Players.Count == 1)
                        {
                            DealerProcess(0, 1);
                        }

                        break;
                    case 2:
                        ServerTS.Tables[1].AddAPlayer(AllUsers[UserIndex].Username);

                        if (ServerTS.Tables[1].Players.Count == 1)
                        {
                            DealerProcess(1, 1);
                        }

                        break;
                    case 3:
                        ServerTS.Tables[2].AddAPlayer(AllUsers[UserIndex].Username);

                        if (ServerTS.Tables[2].Players.Count == 1)
                        {
                            DealerProcess(2, 1);
                        }

                        break;
                }
               //ServerTS.p = PacketType.PlayerInGame;

                SendToAllClients(ServerTS);
            }
            else if(IncomingPacket is DrawCardRequest)
            {
                DrawCardRequest DCR = (DrawCardRequest)IncomingPacket;
                ServerTS.Tables[DCR.TableNum - 1].GivetoPlayer(AllUsers[UserIndex].Username);
                //ServerTS.p = PacketType.Draw;
                SendToAllClients(ServerTS);

            }
            else if(IncomingPacket is BetPacket)
            {
                BetPacket Pot = (BetPacket)IncomingPacket;
                ServerTS.Tables[Pot.TableNum].Players.
            }
        }

    }
}
