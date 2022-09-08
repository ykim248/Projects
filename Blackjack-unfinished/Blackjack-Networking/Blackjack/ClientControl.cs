using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Packets;


namespace Blackjack
{
    public partial class ClientControl : Form
    {
        private delegate void clDelegate(object temp);
        private delegate void UpdateScreen();

        private Thread WFPThread = null;
        NetworkStream clientStream = null;
        private static BinaryFormatter formatter = new BinaryFormatter();
        bool Connected = false;
        string Username;

        TableStatus LocalTS = new TableStatus();
        Table MyTable;
        Blackjack GameWindow;
        int TableNumber;

        bool BJCreated = false;

        public ClientControl()
        {
            InitializeComponent();
            Disconnected();
        }

        private void Btn_Join_Click(object sender, EventArgs e)
        {
            if (WFPThread == null || !WFPThread.IsAlive)
            {
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect(IPAddress.Text, 3005);
                    clientStream = client.GetStream();

                    Connected = true;
                    InServer();
                    WFPThread = new Thread(new ThreadStart(WaitForPacketProcedure));
                    WFPThread.Start();

                    SetUsername User = new SetUsername();
                    User.Username = UserName.Text;
                    formatter.Serialize(clientStream, User);
                    Username = UserName.Text;

                }
                catch (SocketException)
                {
                    MessageBox.Show("Cannot connect to server");
                }

            }
        }
        public void WaitForPacketProcedure()
        {
            object IncomingPacket;
            try
            {
                while (Connected)
                {
                    IncomingPacket = formatter.Deserialize(clientStream); //blocking call

                    BeginInvoke(new clDelegate(HandlePacket), IncomingPacket);
                }
            }
            catch
            {      
                BeginInvoke(new UpdateScreen(Disconnected));
                WFPThread.Abort();
            }
        }

        private void HandlePacket(object IncomingPacket)
        {
            if (IncomingPacket is Chat)
            {
                Chat m = (Chat)IncomingPacket;
                ChatDisplay.Items.Add(m.Text);
            }
            if(IncomingPacket is TableStatus)
            {
                LocalTS = (TableStatus)IncomingPacket;
                bool inTable = false;
                foreach(Player PlayerVal in LocalTS.Tables[0].Players)
                {
                    if(PlayerVal.username == Username)
                    {
                        MyTable = LocalTS.Tables[0];
                        inTable = true;
                        break;
                    }
                }

                if(inTable == false)
                {
                    foreach (Player PlayerVal in LocalTS.Tables[1].Players)
                    {
                        if (PlayerVal.username == Username)
                        {
                            MyTable = LocalTS.Tables[1];
                            inTable = true;
                            break;
                        }
                    }
                }                
                if(inTable == false)
                {
                    foreach (Player PlayerVal in LocalTS.Tables[2].Players)
                    {
                        if (PlayerVal.username == Username)
                        {
                            MyTable = LocalTS.Tables[2];
                            inTable = true;
                            break;
                        }
                    }
                }
                if (inTable && !BJCreated)
                {
                    BJCreated = true;
                    ShowBlackJack();
                }

                int MyIndex = 0;

                foreach (Player PlayerVal in LocalTS.Tables[TableNumber].ActivePlayers)
                {
                    if (PlayerVal.username == Username)
                    {
                        break;
                    }
                    else
                    {
                        MyIndex++;
                    }
                }
                GameWindow.UpdateHand(LocalTS.Tables[TableNumber - 1].ActivePlayers[0].Hand);
                
            }
        }

        private void Btn_SendChat_Click(object sender, EventArgs e)
        {
            Chat ChatPacket = new Chat();
            ChatPacket.Text = Username + ": " + ChatBox.Text;
            formatter.Serialize(clientStream, ChatPacket);
            ChatBox.Clear();
        }

        void InServer()
        {
            Controls.Clear();

            Controls.Add(ChatDisplay);
            Controls.Add(Btn_SendChat);
            Controls.Add(ChatBox);
            Controls.Add(Btn_Table3);
            Controls.Add(Btn_Table2);
            Controls.Add(Btn_Table1);
            Controls.Add(Table3);
            Controls.Add(Table2);
            Controls.Add(Table1);
        }
        
        void Disconnected()
        {
            Controls.Clear();
            UserName.Text = "";

            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(IPAddress);
            Controls.Add(Btn_Join);
            Controls.Add(UserName);
            ChatDisplay.Items.Clear();
            ChatBox.Clear();
        }

        private void Btn_Table1_Click(object sender, EventArgs e)
        {
            JoinTable JoinTablePacket = new JoinTable();
            JoinTablePacket.TableNumber = 1;
            TableNumber = 1;
            formatter.Serialize(clientStream, JoinTablePacket);

        }

        private void Btn_Table2_Click(object sender, EventArgs e)
        {
            JoinTable JoinTablePacket = new JoinTable();
            JoinTablePacket.TableNumber = 2;
            TableNumber = 2;
            formatter.Serialize(clientStream, JoinTablePacket);
        }

        private void Btn_Table3_Click(object sender, EventArgs e)
        {
            JoinTable JoinTablePacket = new JoinTable();
            JoinTablePacket.TableNumber = 3;
            TableNumber = 3;
            formatter.Serialize(clientStream, JoinTablePacket);
        }



        private void ShowBlackJack()
        {
            Hide();

            GameWindow = new Blackjack(this, clientStream, TableNumber);
            GameWindow.Show();

        }
    }
}
