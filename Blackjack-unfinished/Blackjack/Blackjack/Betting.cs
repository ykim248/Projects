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
    public partial class Betting : Form
    {
        public int TotalCash;
        public int Bet = 0;
        public Betting(int Cash)
        {
            InitializeComponent();
            TotalCash = Cash;
            TotalCashLabel.Text = "TotalCash: " + TotalCash.ToString();
            BettingLabel.Text = "Bet: " + Bet.ToString();
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            if(TotalCash != 0)
            {
                TotalCash -= 1;
                Bet += 1;
            }
            else
            {
                MessageBox.Show("Daddy Stop");
            }

            TotalCashLabel.Text = "TotalCash: " + TotalCash.ToString();
            BettingLabel.Text = "Bet: " + Bet.ToString();
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            if (TotalCash != 0)
            {
                TotalCash -= 5;
                Bet += 5;
            }
            else
            {
                MessageBox.Show("You Must Construct Additional Pylons");
            }

            TotalCashLabel.Text = "TotalCash: " + TotalCash.ToString();
            BettingLabel.Text = "Bet: " + Bet.ToString();
        }

        private void Btn_10_Click(object sender, EventArgs e)
        {
            if (TotalCash != 0)
            {
                TotalCash -= 10;
                Bet += 10;
            }
            else
            {
                MessageBox.Show("You Must Construct Additional Pylons");
            }
            

            TotalCashLabel.Text = "TotalCash: " + TotalCash.ToString();
            BettingLabel.Text = "Bet: " + Bet.ToString();
        }

        private void Btn_20_Click(object sender, EventArgs e)
        {
            if (TotalCash != 0)
            {
                TotalCash -= 20;
                Bet += 20;
            }
            else
            {
                MessageBox.Show("You Must Construct Additional Pylons");
            }
            

            TotalCashLabel.Text = "TotalCash: " + TotalCash.ToString();
            BettingLabel.Text = "Bet: " + Bet.ToString();
        }

        private void Btn_Deal_Click(object sender, EventArgs e)
        {
            if(Bet == 0)
            {
                MessageBox.Show("Please place a bet");
            }
            else
            {                
                this.DialogResult = DialogResult.Yes;
            }
            
        }

        private void Btn_AllInn_Click(object sender, EventArgs e)
        {
            if (TotalCash != 0)
            {
                Bet += TotalCash;
                TotalCash -= TotalCash;
            }
            else
            {
                MessageBox.Show("You Must Construct Additional Pylons");
            }

            TotalCashLabel.Text = "TotalCash: " + TotalCash.ToString();
            BettingLabel.Text = "Bet: " + Bet.ToString();
        }
    }
}
