using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clickly
{
    public partial class Clicky : Form
    {
        private int count;
        private int time;
        public Clicky()
        {
            InitializeComponent();
            count = 0;
            stopwatch1.Start();
        }

        private void Btn_Click_Click(object sender, EventArgs e)
        {            
            count++;
            label1.Text = count.ToString();
            if(count == 20)
            {
                time = (stopwatch1.Minutes * 60) + stopwatch1.Seconds;
                MessageBox.Show(time.ToString()+"seconds");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
