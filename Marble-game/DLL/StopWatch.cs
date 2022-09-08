using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLL
{
    public partial class Stopwatch : UserControl
    {
        private BufferedGraphicsContext CurrentContext;
        private float radius;
        private Point center;
        private float smallradius;
        private Point smallcenter;
        bool ticking = false;

        private DateTime StartTime = DateTime.Now;
        private TimeSpan TimePassed, PauseTime;

        public int Minutes
        {
            get
            {
                return TimePassed.Minutes;
            }
        }

        public int Seconds
        {
            get
            {
                return TimePassed.Seconds;
            }
        }

        public Stopwatch()
        {
            InitializeComponent();

            if (Height > Width)
            {
                radius = Width / 2;
                smallradius = Width / 3;
            }
            else
            {
                radius = Height / 2;
                smallradius = Height / 3;
            }

            center = new Point(Width / 2, Height / 2);
            smallcenter = new Point(Width / 2, Height / 3);
        }

        public void Start()
        {
            if (ticking == false)
            {
                ticking = true;
                StartTime = DateTime.Now;
                timer1.Enabled = true;
            }
        }

        public void Pause()
        {
            ticking = false;

            PauseTime += DateTime.Now - StartTime;
        }

        public void Stop()
        {
            ticking = false;

            TimePassed = TimeSpan.Zero;
            PauseTime = TimeSpan.Zero;

            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.WhiteSmoke);

            DrawSecondLines(bg.Graphics);
            DrawMinuteLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);

            bg.Render();
        }

        private void Stopwatch_Paint(object sender, PaintEventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.WhiteSmoke);

            DrawSecondLines(bg.Graphics);
            DrawMinuteLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);

            bg.Render();
        }
        private void DrawSecondLines(Graphics g)
        {
            Pen myPen1 = new Pen(Color.Red, radius * 0.07f);
            Pen myPen2 = new Pen(Color.Black, radius * 0.05f);
            Pen myPen3 = new Pen(Color.Black, radius * 0.005f);

            for (int i = 0; i < 4; i++)
            {
                float x = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .7f + center.X;
                float y = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .7f + center.Y;

                float x2 = (float)Math.Cos(i * 90 * Math.PI / 180) * radius * .8f + center.X;
                float y2 = (float)Math.Sin(i * 90 * Math.PI / 180) * radius * .8f + center.Y;

                g.DrawLine(myPen1, x, y, x2, y2);
            }
            for (int i = 0; i < 12; i++)
            {
                if (i % 3 != 0)
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .7f + center.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .7f + center.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * radius * .8f + center.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * radius * .8f + center.Y;

                    g.DrawLine(myPen2, x, y, x2, y2);
                }

            }
            for (int i = 0; i < 60; i++)
            {
                if (i % 5 != 0)
                {
                    float x = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .7f + center.X;
                    float y = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .7f + center.Y;

                    float x2 = (float)Math.Cos(i * 6 * Math.PI / 180) * radius * .8f + center.X;
                    float y2 = (float)Math.Sin(i * 6 * Math.PI / 180) * radius * .8f + center.Y;

                    g.DrawLine(myPen3, x, y, x2, y2);
                }
            }
        }

        private void DrawMinuteLines(Graphics g)
        {
            Pen myPen = new Pen(Color.Black, radius * 0.05f);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < 12; i++)
            {
                {
                    float x = (float)Math.Cos(i * 30 * Math.PI / 180) * smallradius * .4f + smallcenter.X;
                    float y = (float)Math.Sin(i * 30 * Math.PI / 180) * smallradius * .4f + smallcenter.Y;

                    float x2 = (float)Math.Cos(i * 30 * Math.PI / 180) * smallradius * .5f + smallcenter.X;
                    float y2 = (float)Math.Sin(i * 30 * Math.PI / 180) * smallradius * .5f + smallcenter.Y;

                    g.DrawLine(myPen, x, y, x2, y2);
                }
            }
        }

        private void DrawNumbers(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            Font numfont = new Font("Tahoma", radius * 0.11f, FontStyle.Bold);
            Brush numbrush = new SolidBrush(Color.Black);

            for (int i = 1; i <= 60; i++)
            {
                if (i % 5 == 0)
                {
                    float x = (float)Math.Cos(((i / 5) * 30 - 90) * Math.PI / 180) * radius * .9f + center.X;
                    float y = (float)Math.Sin(((i / 5) * 30 - 90) * Math.PI / 180) * radius * .9f + center.Y;
                    g.DrawString(i.ToString(), numfont, numbrush, x, y, sf);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ticking)
            {
                TimePassed = DateTime.Now - StartTime + PauseTime;

                CurrentContext = BufferedGraphicsManager.Current;
                System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

                bg.Graphics.Clear(Color.WhiteSmoke);

                DrawSecondLines(bg.Graphics);
                DrawMinuteLines(bg.Graphics);
                DrawNumbers(bg.Graphics);
                DrawHands(bg.Graphics);

                bg.Render();
            }

        }

        private void Stopwatch_Resize(object sender, EventArgs e)
        {
            if (Height > Width)
            {
                radius = Width / 2;
                smallradius = Width / 3;
            }
            else
            {
                radius = Height / 2;
                smallradius = Height / 3;
            }

            center = new Point(Width / 2, Height / 2);
            smallcenter = new Point(Width / 2, Height / 3);

            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            bg.Graphics.Clear(Color.WhiteSmoke);

            DrawSecondLines(bg.Graphics);
            DrawMinuteLines(bg.Graphics);
            DrawNumbers(bg.Graphics);
            DrawHands(bg.Graphics);

            bg.Render();
        }

        private void DrawHands(Graphics g)
        {
            TimePassed = DateTime.Now - StartTime + PauseTime;

            Pen minPen = new Pen(Color.Red, radius * 0.03f);
            Pen secPen = new Pen(Color.Red, radius * 0.01f);

            int minutes = TimePassed.Minutes;
            int seconds = TimePassed.Seconds;

            float sx = (float)Math.Cos((seconds * 6 - 90) * Math.PI / 180) * radius * .7f + center.X;
            float sy = (float)Math.Sin((seconds * 6 - 90) * Math.PI / 180) * radius * .7f + center.Y;

            float mx = (float)Math.Cos((minutes * 6 - 90) * Math.PI / 180) * smallradius * .3f + smallcenter.X;
            float my = (float)Math.Sin((minutes * 6 - 90) * Math.PI / 180) * smallradius * .3f + smallcenter.Y;

            //float sx2 = (float)Math.Cos(90 * Math.PI / 180) * radius * .8f + center.X;
            //float sy2 = (float)Math.Sin(90 * Math.PI / 180) * radius * .8f + center.Y;

            g.DrawLine(secPen, center.X, center.Y, sx, sy);
            g.DrawLine(minPen, smallcenter.X, smallcenter.Y, mx, my);
        }
    }
}
