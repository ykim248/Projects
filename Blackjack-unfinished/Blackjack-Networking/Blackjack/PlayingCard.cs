using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Packets;

namespace Blackjack
{
    public partial class Card : UserControl
    {
        public Suit CardSuit;
        public int CardNumber;
        
        Image CardImage;

        private int oldWidth;
        private int oldHeight;

        public Card()
        {
            InitializeComponent();
            Initialize(Suit.Hearts, 13);
        }

        public Card(Suit NewSuit, int NewNumber)
        {
            InitializeComponent();
            Initialize(NewSuit, NewNumber);
            oldWidth = this.Width;
            oldHeight = this.Height;
        }

        public void Initialize(Suit NewSuit, int NewNumber)
        {
            CardSuit = NewSuit;
            CardNumber = NewNumber;

            if (NewSuit == Suit.Clubs)
            {
                SuitImage.Image = SuitImages.Images[0];
                TopLeftLabel.ForeColor = System.Drawing.Color.Black;
                BottomRightLabel.ForeColor = System.Drawing.Color.Black;
            }
            else if (NewSuit == Suit.Diamonds)
            {
                SuitImage.Image = SuitImages.Images[1];
                TopLeftLabel.ForeColor = System.Drawing.Color.Red;
                BottomRightLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (NewSuit == Suit.Hearts)
            {
                SuitImage.Image = SuitImages.Images[2];
                TopLeftLabel.ForeColor = System.Drawing.Color.Red;
                BottomRightLabel.ForeColor = System.Drawing.Color.Red;
            }
            else if (NewSuit == Suit.Spades)
            {
                SuitImage.Image = SuitImages.Images[3];
                TopLeftLabel.ForeColor = System.Drawing.Color.Black;
                BottomRightLabel.ForeColor = System.Drawing.Color.Black;
            }

            if (NewNumber == 1)
            {
                TopLeftLabel.Text = "A";
                BottomRightLabel.Text = "A";
            }
            else if (NewNumber == 11)
            {
                TopLeftLabel.Text = "J";
                BottomRightLabel.Text = "J";
            }
            else if (NewNumber == 12)
            {
                TopLeftLabel.Text = "Q";
                BottomRightLabel.Text = "Q";
            }
            else if (NewNumber == 13)
            {
                TopLeftLabel.Text = "K";
                BottomRightLabel.Text = "K";
            }
            else
            {
                TopLeftLabel.Text = NewNumber.ToString();
                BottomRightLabel.Text = NewNumber.ToString();
            }
        }

        private void Card_Resize(object sender, EventArgs e)
        {
            int dw = Math.Abs(oldWidth - this.Width);
            int dh = Math.Abs(oldHeight - this.Height);

            if (dw > dh)
            {
                this.Height = this.Width - 177;
            }
            else
            {
                this.Width = this.Height + 177;
            }

            oldWidth = this.Width;
            oldHeight = this.Height;
        }
    }
}
