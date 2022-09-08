using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Client : Form
    {
        Deck TheDeck;

        Card[] ClientHand;
        Card[] DealerHand;
        Card[] SplitHand1;
        Card[] SplitHand2;

        int[] StoredHand;

        int ClientHandIterator = 0;
        int DealerHandIterator = 0;
        int SplitHandIterator = 2;
        int SplitHandNum = 0;
        int CardValue = 0;
        int PlayerCardVal = 0;
        int DealerCardVal = 0;
        int SplitHandVal = 0;
        int PlayerCash = 250;
        int Pot;
        int StoredValue = 0;
        int HandArray = 0;

        bool FirstAce = false;
        bool isDealer = false;
        bool IsSplit = false;
        bool Stand = false;
        bool HitBtnClicked = false;

        Image imgTemp;
        private PictureBox FaceDown;

        public Client()
        {
            InitializeComponent();
            Btn_Hit.Enabled = false;
            Btn_Stand.Enabled = false;
            Btn_Split.Enabled = false;
            Btn_Split.Visible = false;
            Btn_Double.Enabled = false;
            Btn_Double.Visible = false;
        }

        void Hit()
        {
            //HandIterator++;
            if (isDealer == false && IsSplit == false)
            {
                ClientHand[ClientHandIterator] = TheDeck.DrawCard();
                ClientHand[ClientHandIterator].Location = new System.Drawing.Point((45 * ClientHandIterator) + 150, 135);
                PlayerTable.Controls.Add(ClientHand[ClientHandIterator++]);

                PlayerValue.Text = HandValue().ToString();
                PlayerValue.BackColor = System.Drawing.Color.White;

                if (HandValue() == 21)
                {
                    MessageBox.Show("BlackJack");
                    Btn_Hit.Enabled = false;
                    Btn_Stand.Enabled = false;
                    Btn_Play.Enabled = true;
                    PlayerCash += Pot * 2;

                }
                if (HandValue() > 21)
                {
                    MessageBox.Show("Bust");
                    Btn_Hit.Enabled = false;
                    Btn_Stand.Enabled = false;
                    Btn_Play.Enabled = true;

                }

            }
            else if (isDealer == true)
            {
                DealerHand[DealerHandIterator] = TheDeck.DrawCard();
                DealerHand[DealerHandIterator].Location = new System.Drawing.Point((45 * DealerHandIterator) + 160, 10);
                DealerTable.Controls.Add(DealerHand[DealerHandIterator++]);
                // find me later
                DealerCardVal = HandValue();
                DealerValue.BackColor = System.Drawing.Color.White;

            }
            else if(IsSplit == true)
            {
                if(SplitHandNum == 0)
                {
                    SplitHand1[SplitHandIterator] = TheDeck.DrawCard();
                    SplitHand1[SplitHandIterator].Location = new System.Drawing.Point((45 * SplitHandIterator) + 150, 135);
                    PlayerTable.Controls.Add(SplitHand1[SplitHandIterator++]);

                    SplitHandVal = HandValue();
                    PlayerValue.Text = HandValue().ToString();
                    PlayerValue.BackColor = System.Drawing.Color.White;

                    if (HandValue() > 21)
                    {
                        MessageBox.Show("Bust");
                        Btn_Hit.Enabled = false;
                        Btn_Stand.Enabled = true;
                        Btn_Play.Enabled = true;

                    }
                }
                else if(SplitHandNum == 1)
                {
                    SplitHand2[SplitHandIterator] = TheDeck.DrawCard();
                    SplitHand2[SplitHandIterator].Location = new System.Drawing.Point((45 * SplitHandIterator) + 150, 45);
                    PlayerTable.Controls.Add(SplitHand2[SplitHandIterator++]);

                    SplitHandVal = HandValue();
                    PlayerValue.Text = HandValue().ToString();
                    PlayerValue.BackColor = System.Drawing.Color.White;

                    if (HandValue() > 21)
                    {
                        MessageBox.Show("Bust");
                        Btn_Hit.Enabled = false;
                        Btn_Stand.Enabled = true;
                        Btn_Play.Enabled = true;

                    }
                }
                
            }
            
        }

        int HandValue()
        {
            int CardValue = 0;
            bool FirstAce = false;
            if (isDealer == false && IsSplit == false)
            {
                for (int i = 0; i < ClientHandIterator; i++)
                {
                    if (ClientHand[i].CardNumber == 1)
                    {
                        if (FirstAce == true)
                        {
                            CardValue += 1;
                        }
                        else
                        {
                            CardValue += 11;
                            FirstAce = true;
                        }
                    }
                    else if (ClientHand[i].CardNumber == 11 || ClientHand[i].CardNumber == 12 || ClientHand[i].CardNumber == 13)
                    {
                        CardValue += 10;
                    }
                    else
                    {
                        CardValue += ClientHand[i].CardNumber;
                    }
                }

                if (CardValue > 21 && FirstAce == true)
                {
                    CardValue -= 10;
                }      
            }
            else if (isDealer == true)
            {
                for (int i = 0; i < DealerHandIterator; i++)
                {
                    if (DealerHand[i].CardNumber == 1)
                    {
                        if (FirstAce == true)
                        {
                            CardValue += 1;
                        }
                        else
                        {
                            CardValue += 11;
                            FirstAce = true;
                        }
                    }
                    else if (DealerHand[i].CardNumber == 11 || DealerHand[i].CardNumber == 12 || DealerHand[i].CardNumber == 13)
                    {
                        CardValue += 10;
                    }
                    else
                    {
                        CardValue += DealerHand[i].CardNumber;
                    }
                }

                if (CardValue > 21 && FirstAce == true)
                {
                    CardValue -= 10;
                }
            }
            else if(isDealer == false && IsSplit == true)
            {
                if(SplitHandNum == 0)
                {
                    for (int i = 0; i < SplitHandIterator; i++)
                    {
                        if (SplitHand1[i].CardNumber == 1)
                        {
                            if (FirstAce == true)
                            {
                                CardValue += 1;
                            }
                            else
                            {
                                CardValue += 11;
                                FirstAce = true;
                            }
                        }
                        else if (SplitHand1[i].CardNumber == 11 || SplitHand1[i].CardNumber == 12 || SplitHand1[i].CardNumber == 13)
                        {
                            CardValue += 10;
                        }
                        else
                        {
                            CardValue += SplitHand1[i].CardNumber;
                        }
                    }
                }
                else if(SplitHandNum == 1)
                {
                    for (int i = 0; i < SplitHandIterator; i++)
                    {
                        if (SplitHand2[i].CardNumber == 1)
                        {
                            if (FirstAce == true)
                            {
                                CardValue += 1;
                            }
                            else
                            {
                                CardValue += 11;
                                FirstAce = true;
                            }
                        }
                        else if (SplitHand2[i].CardNumber == 11 || SplitHand2[i].CardNumber == 12 || SplitHand2[i].CardNumber == 13)
                        {
                            CardValue += 10;
                        }
                        else
                        {
                            CardValue += SplitHand2[i].CardNumber;
                        }
                    }
                }
                
            }
            return CardValue;

        }

        void CashOut()
        {
            for(int i = 0;i<= StoredHand.Length; i++)
            {
                if(StoredHand[i] != 0)
                {
                    if (DealerCardVal > 21)
                    {
                        MessageBox.Show("Dealer Bust");
                    }
                    else if (DealerCardVal == 21)
                    {
                        MessageBox.Show("Dealer BlackJack");
                    }
                    else if (DealerCardVal > StoredHand[i])
                    {
                        MessageBox.Show("Dealer Wins");
                    }
                    else if (DealerCardVal == StoredHand[i])
                    {
                        MessageBox.Show("Draw");
                        PlayerCash += Pot;
                    }
                    else if (DealerCardVal < StoredHand[i])
                    {
                        MessageBox.Show("You Win");
                        PlayerCash += Pot * 2;
                    }
                }
                else
                {
                    break;
                }                
            }
            Btn_Play.Enabled = true;
        }
        private void HideCard()
        {
            imgTemp = Image.FromFile("CardButt.jpg");

            int ph = imgTemp.Height;
            int pw = imgTemp.Width;

            FaceDown = new PictureBox();
            FaceDown.Size = new System.Drawing.Size(63, 87);
            FaceDown.Location = DealerHand[0].Location;
            FaceDown.BackColor = System.Drawing.Color.Red;
            FaceDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            FaceDown.SizeMode = PictureBoxSizeMode.StretchImage;
            //FaceDown.Dock = DockStyle.Fill;
            FaceDown.Margin = new System.Windows.Forms.Padding(0);
            FaceDown.Image = imgTemp;

            //Bitmap bm = new Bitmap(pw, ph);
            //Graphics g = Graphics.FromImage(bm);
            //Rectangle r = new Rectangle(0, 0, pw, ph);
            //g.DrawImage(imgTemp, r, 25 , 25 , pw, ph, GraphicsUnit.Pixel);
            
            //FaceDown.Image = bm;

            DealerTable.Controls.Add(FaceDown);
            DealerTable.Controls.Remove(DealerHand[0]);

            //FaceDown = new PictureBox();
            //FaceDown.BackColor = System.Drawing.Color.Red;
            //FaceDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //FaceDown.SizeMode = PictureBoxSizeMode.StretchImage;
            //FaceDown.Dock = DockStyle.Fill;
            //FaceDown.Margin = new System.Windows.Forms.Padding(0);

        }
        private void Btn_Hit_Click(object sender, EventArgs e)
        {
            HitBtnClicked = true;
            isDealer = false;
            if(IsSplit == true)
            {
                Btn_Split.Visible = false;
            }
            if(HitBtnClicked == true)
            {
                Btn_Double.Enabled = false;
                Btn_Double.Visible = false;
            }
            Hit();
        }

        private void Reset()
        {
            if(ClientHand != null)
            {
                for (int i = 0; i <= ClientHandIterator; i++)
                {
                    PlayerTable.Controls.Remove(ClientHand[i]);
                    ClientHand[i] = null;
                }
                PlayerValue.Text = "";
            }
            if (DealerHand != null)
            {
                for (int i = 0; i <= DealerHandIterator; i++)
                {
                    DealerTable.Controls.Remove(DealerHand[i]);
                    DealerHand[i] = null;
                }
                DealerValue.Text =  "";
                DealerTable.Controls.Remove(FaceDown);
            }
            if (SplitHand1 != null)
            {
                IsSplit = false;
                for (int i = 0; i <= SplitHandIterator; i++)
                {
                    PlayerTable.Controls.Remove(SplitHand1[i]);
                    PlayerTable.Controls.Remove(SplitHand2[i]);
                    SplitHand1[i] = null;
                    SplitHand2[i] = null;
                }
                PlayerValue.Text = "";
            }

            HandArray = 0;
        }

        private void Btn_Play_Click(object sender, EventArgs e)
        {
            
            Btn_Play.Enabled = false;
            Reset();
            if(PlayerCash == 0)
            {
                PlayerCash = 250;
            }
            
            Blackjack.Betting NewGame = new Blackjack.Betting(PlayerCash);

            if (NewGame.ShowDialog() == DialogResult.Yes)
            {
                PlayerCash = NewGame.TotalCash;
                Pot = NewGame.Bet;
                Label_Pot.Text = "Pot: " + Pot;

                Btn_Hit.Enabled = true;
                Btn_Stand.Enabled = true;

                HitBtnClicked = false;
                Btn_Hit.Enabled = true;
                Btn_Stand.Enabled = true;
                Reset();
                TheDeck = new Deck();
                TheDeck.shuffle();
                ClientHand = new Card[10];
                DealerHand = new Card[10];
                StoredHand = new int[5];
                ClientHandIterator = 0;
                DealerHandIterator = 0;
                TheDeck.DrawCount = 0;
                Stand = false;
                Person();
                Dealer();
                HideCard();
                Btn_Double.Enabled = true;
                Btn_Double.Visible = true;
            }
            else
            {
                Btn_Play.Enabled = true;
            }     

        }

        void Person()
        {
            isDealer = false;
            if(ClientHand[0] == null)
            {
                for (int i = 0; i < 2; i++)
                {
                    Hit();
                }
            }            

            if(ClientHand[0].CardNumber == ClientHand[1].CardNumber)
            {
                Btn_Split.Visible = true;
                Btn_Split.Enabled = true;
            }
            
                
        }

        void Dealer()
        {
            isDealer = true;
            if (DealerHand[0] == null)
            {
                for (int i = 0; i < 2; i++)
                {
                    Hit();
                }
                
            }
            else
            {
                int x = 0;
                while (StoredHand[x] != 0)
                {
                    if(DealerCardVal < StoredHand[x])
                    {
                        if (DealerCardVal < 17)
                        {
                            for (int i = 0; i < DealerHandIterator; i++)
                            {
                                Hit();
                                break;
                            }
                        }                        
                    }
                    x++;
                }
                DealerValue.Text = DealerCardVal.ToString();                
            }
            isDealer = false;
        }

        private void Btn_Stand_Click(object sender, EventArgs e)
        {
            if (IsSplit == false)
            {
                PlayerCardVal = Int32.Parse(PlayerValue.Text);
                StoredHand[HandArray++] = PlayerCardVal;

                Stand = true;
                Btn_Hit.Enabled = false;
                Btn_Stand.Enabled = false;

                DealerTable.Controls.Remove(FaceDown);
                DealerTable.Controls.Add(DealerHand[0]);

                Dealer();
                CashOut();
            }
            else if (IsSplit == true && SplitHandNum == 0) 
            {
                HitBtnClicked = false;
                Btn_Hit.Enabled = true;
                PlayerValue.Text = "";

                SplitHandNum = 1;
                SplitHandIterator = 2;

                StoredValue = HandValue();

                PlayerValue.Text = StoredValue.ToString();
                PlayerValue.BackColor = System.Drawing.Color.White;
                PlayerValue.Location = new System.Drawing.Point(0, 45);
                if (StoredValue == 21)
                {
                    MessageBox.Show("BlackJack");
                    Btn_Hit.Enabled = false;
                    Btn_Stand.Enabled = true;
                    PlayerCash += Pot * 2;
                }
            }
            else if (IsSplit == true && SplitHandNum == 1)
            {
                StoredHand[HandArray++] = SplitHandVal;
                Stand = true;
                Btn_Hit.Enabled = false;
                Btn_Stand.Enabled = false;

                DealerTable.Controls.Remove(FaceDown);
                DealerTable.Controls.Add(DealerHand[0]);

                Dealer();
                CashOut();
            }


        }

        private void Btn_Split_Click(object sender, EventArgs e)
        {
            IsSplit = true;

            for (int i = 0; i <= ClientHandIterator; i++)
            {
                PlayerTable.Controls.Remove(ClientHand[i]);
            }
            PlayerValue.Text = "";

            SplitHand1 = new Card[10];
            SplitHand2 = new Card[10];

            SplitHand1[0] = ClientHand[0];
            SplitHand2[0] = ClientHand[1];

            SplitHand1[1] = TheDeck.DrawCard();
            SplitHand2[1] = TheDeck.DrawCard();

            SplitHand1[1].Location = new System.Drawing.Point((45 * 1) + 150, 135);

            SplitHandVal = HandValue();
            StoredHand[HandArray++] = SplitHandVal;
            PlayerValue.Text = HandValue().ToString();
            PlayerValue.BackColor = System.Drawing.Color.White;
            PlayerValue.Location = new System.Drawing.Point(0, 135);
            if (HandValue() == 21)
            {
                MessageBox.Show("BlackJack");
                Btn_Hit.Enabled = false;
                Btn_Stand.Enabled = true;
                PlayerCash += Pot * 2;

            }

            SplitHand2[0].Location = new System.Drawing.Point((45 * 0) + 150, 45);
            SplitHand2[1].Location = new System.Drawing.Point((45 * 1) + 150, 45);

            for (int i = 0; i < 2; i++)
            {
                PlayerTable.Controls.Add(SplitHand1[i]);
                PlayerTable.Controls.Add(SplitHand2[i]);
            }
            Btn_Split.Enabled = false;
        }

        private void Btn_Double_Click(object sender, EventArgs e)
        {
            Pot += Pot * 2;
            Btn_Hit.Enabled = false;
            Btn_Double.Enabled = false;
            Btn_Double.Visible = true;
            Hit();
        }
    }    
}
