using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marble_Game
{
    public partial class Form1 : Form
    {
        Image imgPuzzleBox;
        int PuzzleSize;
        int BallsinPlay;
        bool WinLose = false;
        Image imgTemp = Image.FromFile("puzzleWide.jpg");

        private MarblePictureBox[,] pbxGrid;

        private int WallNumber(bool LeftWall, bool RightWall, bool UpWall, bool DownWall)
        {
            int WallNumber = 0;

            if (LeftWall == false && RightWall == false && UpWall == false && DownWall == false)
            {
                WallNumber = 0;
            }
            else if (LeftWall == true && RightWall == false && UpWall == false && DownWall == false)
            {
                WallNumber = 1;
            }
            else if (LeftWall == false && RightWall == true && UpWall == false && DownWall == false)
            {
                WallNumber = 2;
            }
            else if (LeftWall == false && RightWall == false && UpWall == true && DownWall == false)
            {
                WallNumber = 3;
            }
            else if (LeftWall == false && RightWall == false && UpWall == false && DownWall == true)
            {
                WallNumber = 4;
            }
            else if (LeftWall == true && RightWall == false && UpWall == true && DownWall == false)
            {
                WallNumber = 5;
            }
            else if (LeftWall == true && RightWall == true && UpWall == false && DownWall == false)
            {
                WallNumber = 6;
            }
            else if (LeftWall == true && RightWall == false && UpWall == false && DownWall == true)
            {
                WallNumber = 7;
            }
            else if (LeftWall == false && RightWall == true && UpWall == true && DownWall == false)
            {
                WallNumber = 8;
            }
            else if (LeftWall == false && RightWall == true && UpWall == false && DownWall == true)
            {
                WallNumber = 9;
            }
            else if (LeftWall == false && RightWall == false && UpWall == true && DownWall == true)
            {
                WallNumber = 10;
            }
            else if (LeftWall == true && RightWall == false && UpWall == true && DownWall == true)
            {
                WallNumber = 11;
            }
            else if (LeftWall == false && RightWall == true && UpWall == true && DownWall == true)
            {
                WallNumber = 12;
            }
            else if (LeftWall == true && RightWall == true && UpWall == true && DownWall == false)
            {
                WallNumber = 13;
            }
            else if (LeftWall == true && RightWall == true && UpWall == false && DownWall == true)
            {
                WallNumber = 14;
            }
            else if (LeftWall == true && RightWall == true && UpWall == true && DownWall == true)
            {
                WallNumber = 15;
            }

            return WallNumber;
        }

        private void Draw()
        {
            for (int row = 0; row < PuzzleSize; row++)
            {
                for (int col = 0; col < PuzzleSize; col++)
                {

                    int Wall = WallNumber(pbxGrid[row, col].leftwall, pbxGrid[row, col].rightwall, pbxGrid[row, col].topwall, pbxGrid[row, col].bottomwall);

                    int X = 0;
                    int Y = 0;

                    if (pbxGrid[row, col].Error == false)
                    {
                        if (pbxGrid[row, col].Balls == 0 && pbxGrid[row, col].Holes == 0)
                        {
                            X = 0;
                            Y = 0;
                        }
                        else if (pbxGrid[row, col].Balls > 0 && pbxGrid[row, col].Holes == 0)
                        {
                            X = 4;
                            Y = 4;
                        }
                        else if (pbxGrid[row, col].Balls == 0 && pbxGrid[row, col].Holes > 0)
                        {
                            X = 2;
                            Y = 2;
                        }
                        int XAdd = Wall;
                        int YAdd = 0;

                        while (XAdd + X > 6)
                        {
                            XAdd = XAdd - 7;
                            YAdd = YAdd + 1;
                        }

                        X += XAdd;
                        Y += YAdd;
                    }
                    else
                    {
                        X = 6;
                        Y = 6;
                    }

                    int pw = imgTemp.Width / 7;
                    int ph = imgTemp.Height / 7;

                    Bitmap bm = new Bitmap(pw, ph);
                    Graphics g = Graphics.FromImage(bm);
                    Rectangle r = new Rectangle(0, 0, pw, ph);
                    g.DrawImage(imgTemp, r, pw*X, ph * Y, pw, ph, GraphicsUnit.Pixel);

                    Font f = new Font("Arial", 30f);
                    String StringValue = "";
                    Brush StringBrush = Brushes.White;


                    if (pbxGrid[row,col].Balls > 0)
                    {
                        StringValue = Convert.ToString(pbxGrid[row, col].Balls);
                    }

                    if (pbxGrid[row, col].Holes > 0)
                    {
                        StringValue = Convert.ToString(pbxGrid[row, col].Holes);
                    }
                    g.DrawString(StringValue, f, StringBrush, pw / 2, ph / 2);
                    
                    pbxGrid[row, col].Image = bm;
                }
            }


            

        }

        private void readfile()
        {
            string[] lines = System.IO.File.ReadAllLines("Puzzle.txt");
            string[] pieces = lines[0].Split(' ');
            int size = Convert.ToInt32(pieces[0]);            
            int ballCount = Convert.ToInt32(pieces[1]);
            int wallCount = Convert.ToInt32(pieces[2]);

            BallsinPlay = ballCount;

            PuzzleSize = size;

            int PBWidth = 0;
            int PBHeight = 0;

            int reservedSpace = 250;

            

            if(imgTemp.Height >= imgTemp.Width)
            {

                double ratio = (float)imgTemp.Width / (float)reservedSpace;
                PBWidth = reservedSpace / size;
                PBHeight = (int)(imgTemp.Height / ratio) / size;


                //PBWidth = reservedSpace / size;
                //PBHeight = (imgTemp.Width * PBWidth) / imgTemp.Height;
            }
            else
            {

                double ratio = (float)imgTemp.Height / (float)reservedSpace;
                PBHeight = reservedSpace / size;
                PBWidth = (int)(imgTemp.Width / ratio) / size;
                


                //PBHeight = reservedSpace / size;
                //PBWidth = (imgTemp.Width * PBHeight) / imgTemp.Width;
            }

            //Called pbxGrid

            pbxGrid = new MarblePictureBox[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    pbxGrid[row, col] = new MarblePictureBox();
                    pbxGrid[row, col].Size = new System.Drawing.Size(PBWidth, PBHeight);
                    pbxGrid[row, col].Location = new System.Drawing.Point(PBWidth * col + 50, PBHeight * row + 15);
                    pbxGrid[row, col].BackColor = System.Drawing.Color.Red;
                    pbxGrid[row, col].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbxGrid[row, col].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pbxGrid[row, col].MouseHover += new System.EventHandler(this.OnHover);
                    // size, location, color
                    // Edit grid of buttons into grid of marblepictureboxes

                    Controls.Add(pbxGrid[row, col]);
                }
            }

            for (int idx = 1; idx <= ballCount; idx++)
            {
                
                string[] coords = lines[idx].Split(' ');
                int r = Convert.ToInt32(coords[0]);
                int c = Convert.ToInt32(coords[1]);

                pbxGrid[r,c].Balls = idx;
            }

            for (int idx = ballCount + 1; idx <= ballCount + ballCount; idx++)
            {
                string[] coords = lines[idx].Split(' ');
                int r = Convert.ToInt32(coords[0]);
                int c = Convert.ToInt32(coords[1]);

                pbxGrid[r,c].Holes = idx - ballCount;
            }

            for (int idx = (2 * ballCount) + 1; idx <= ballCount + ballCount + wallCount; idx++)
            {
                string[] coords = lines[idx].Split(' ');
                int r1 = Convert.ToInt32(coords[0]);
                int c1 = Convert.ToInt32(coords[1]);
                int r2 = Convert.ToInt32(coords[2]);
                int c2 = Convert.ToInt32(coords[3]);

                if (r1 == r2)
                {
                    if (c1 < c2) // right of r1,c1
                    {
                        pbxGrid[r1,c1].rightwall = true;
                        pbxGrid[r2,c2].leftwall = true;
                    }
                    else //left of r1,c1
                    {
                        pbxGrid[r1, c1].leftwall = true;
                        pbxGrid[r2, c2].rightwall = true;
                        
                    }
                }
                else if (c1 == c2)
                {
                    if (r1 > r2)
                    {
                        pbxGrid[r1, c1].topwall = true;
                        pbxGrid[r2, c2].bottomwall = true;
                    }
                    else
                    {
                        pbxGrid[r1, c1].bottomwall = true;
                        pbxGrid[r2, c2].topwall = true;
                    }
                }
                for (int X = 0; X < PuzzleSize; X++)
                {
                    pbxGrid[0, X].topwall = true;
                    pbxGrid[X, 0].leftwall = true;
                    pbxGrid[X, PuzzleSize - 1].rightwall = true;
                    pbxGrid[PuzzleSize - 1, X].bottomwall = true;
                }
                //pbxGrid[r,c];
            }
        }

        private void OnHover(object sender, EventArgs args)
        {
            MarblePictureBox hovered = sender as MarblePictureBox;

            Console.Write("Ball: " + hovered.Balls);
            Console.Write("Hole: " + hovered.Holes);
        }

        public Form1()
        {
            InitializeComponent();
            readfile();
            Draw();
        }

        private void Btn_Left_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                for (int col = 1; col < PuzzleSize; col++)
                {
                    for (int row = 0; row < PuzzleSize; row++)
                    {
                        if (pbxGrid[row, col].Balls > 0)
                        {
                            for (int tempcol = col; tempcol > 0; tempcol--)
                            {
                                if (pbxGrid[row, tempcol].leftwall == false && pbxGrid[row, tempcol - 1].Balls == 0)
                                {
                                    pbxGrid[row, tempcol - 1].Balls = pbxGrid[row, tempcol].Balls;
                                    pbxGrid[row, tempcol].Balls = 0;


                                    if (pbxGrid[row, tempcol - 1].Balls == pbxGrid[row, tempcol - 1].Holes)
                                    {
                                        pbxGrid[row, tempcol - 1].Balls = 0;
                                        pbxGrid[row, tempcol - 1].Holes = 0;

                                        BallsinPlay--;

                                        if(BallsinPlay == 0)
                                        {
                                            WinLose = true;
                                            MessageBox.Show("You Win!");
                                            Btn_Left.Visible = false;
                                            Btn_Right.Visible = false;
                                            Btn_Up.Visible = false;
                                            Btn_Down.Visible = false;
                                        }
                                    }
                                    else if (pbxGrid[row, tempcol - 1].Balls != pbxGrid[row, tempcol - 1].Holes && pbxGrid[row, tempcol - 1].Holes > 0)
                                    {
                                        pbxGrid[row, tempcol - 1].Error = true;
                                        pbxGrid[row, tempcol - 1].Balls = 0;
                                        pbxGrid[row, tempcol - 1].Holes = 0;

                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_Left.Visible = false;
                                        Btn_Right.Visible = false;
                                        Btn_Up.Visible = false;
                                        Btn_Down.Visible = false;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        Draw();
                    }
                }
            }
        }

        private void Btn_Right_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                for (int col = (PuzzleSize - 2); col >= 0; col--)
                {
                    for (int row = 0; row < PuzzleSize; row++)
                    {
                        if (pbxGrid[row, col].Balls > 0)
                        {
                            for (int tempcol = col; tempcol < PuzzleSize - 1; tempcol++)
                            {
                                if (pbxGrid[row, tempcol].rightwall == false && pbxGrid[row, tempcol + 1].Balls == 0)
                                {
                                    pbxGrid[row, tempcol + 1].Balls = pbxGrid[row, tempcol].Balls;
                                    pbxGrid[row, tempcol].Balls = 0;


                                    if (pbxGrid[row, tempcol + 1].Balls == pbxGrid[row, tempcol + 1].Holes)
                                    {
                                        pbxGrid[row, tempcol + 1].Balls = 0;
                                        pbxGrid[row, tempcol + 1].Holes = 0;

                                        BallsinPlay--;

                                        if (BallsinPlay == 0)
                                        {
                                            WinLose = true;
                                            MessageBox.Show("You Win!");
                                            Btn_Left.Visible = false;
                                            Btn_Right.Visible = false;
                                            Btn_Up.Visible = false;
                                            Btn_Down.Visible = false;
                                        }
                                    }
                                    else if (pbxGrid[row, tempcol + 1].Balls != pbxGrid[row, tempcol + 1].Holes && pbxGrid[row, tempcol + 1].Holes > 0)
                                    {
                                        pbxGrid[row, tempcol + 1].Error = true;
                                        pbxGrid[row, tempcol + 1].Balls = 0;
                                        pbxGrid[row, tempcol + 1].Holes = 0;

                                        WinLose = true;
                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_Left.Visible = false;
                                        Btn_Right.Visible = false;
                                        Btn_Up.Visible = false;
                                        Btn_Down.Visible = false;

                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        Draw();
                    }
                }
            }
            
        }

        private void Btn_Up_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                for (int col = 0; col < PuzzleSize; col++)
                {
                    for (int row = 0; row < PuzzleSize; row++)
                    {
                        if (pbxGrid[row, col].Balls > 0)
                        {
                            for (int temprow = row; temprow > 0; temprow--)
                            {
                                if (pbxGrid[temprow, col].topwall == false && pbxGrid[temprow - 1, col].Balls == 0)
                                {
                                    pbxGrid[temprow - 1, col].Balls = pbxGrid[temprow, col].Balls;
                                    pbxGrid[temprow, col].Balls = 0;

                                    if (pbxGrid[temprow - 1, col].Balls == pbxGrid[temprow - 1, col].Holes)
                                    {
                                        pbxGrid[temprow - 1, col].Balls = 0;
                                        pbxGrid[temprow - 1, col].Holes = 0;

                                        BallsinPlay--;

                                        if (BallsinPlay == 0)
                                        {
                                            WinLose = true;
                                            MessageBox.Show("You Win!");
                                            Btn_Left.Visible = false;
                                            Btn_Right.Visible = false;
                                            Btn_Up.Visible = false;
                                            Btn_Down.Visible = false;
                                        }
                                    }

                                    else if (pbxGrid[temprow - 1, col].Balls != pbxGrid[temprow - 1, col].Holes && pbxGrid[temprow - 1, col].Holes > 0)
                                    {
                                        pbxGrid[temprow - 1, col].Error = true;
                                        pbxGrid[temprow - 1, col].Balls = 0;
                                        pbxGrid[temprow - 1, col].Holes = 0;

                                        WinLose = true;
                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_Left.Visible = false;
                                        Btn_Right.Visible = false;
                                        Btn_Up.Visible = false;
                                        Btn_Down.Visible = false;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        Draw();
                    }
                }
            }
            
        }

        private void Btn_Down_Click(object sender, EventArgs e)
        {
            if(WinLose == false)
            {
                for (int col = 0; col < PuzzleSize; col++)
                {
                    for (int row = PuzzleSize - 2; row >= 0; row--)
                    {
                        if (pbxGrid[row, col].Balls > 0)
                        {
                            for (int temprow = row; temprow < PuzzleSize - 1; temprow++)
                            {
                                if (pbxGrid[temprow, col].bottomwall == false && pbxGrid[temprow + 1, col].Balls == 0)
                                {
                                    pbxGrid[temprow + 1, col].Balls = pbxGrid[temprow, col].Balls;
                                    pbxGrid[temprow, col].Balls = 0;

                                    if (pbxGrid[temprow + 1, col].Balls == pbxGrid[temprow + 1, col].Holes)
                                    {
                                        pbxGrid[temprow + 1, col].Balls = 0;
                                        pbxGrid[temprow + 1, col].Holes = 0;

                                        BallsinPlay--;

                                        if (BallsinPlay == 0)
                                        {
                                            WinLose = true;
                                            MessageBox.Show("You Win!");
                                            Btn_Left.Visible = false;
                                            Btn_Right.Visible = false;
                                            Btn_Up.Visible = false;
                                            Btn_Down.Visible = false;
                                        }
                                    }

                                    else if (pbxGrid[temprow + 1, col].Balls != pbxGrid[temprow + 1, col].Holes && pbxGrid[temprow + 1, col].Holes > 0)
                                    {
                                        pbxGrid[temprow + 1, col].Error = true;
                                        pbxGrid[temprow + 1, col].Balls = 0;
                                        pbxGrid[temprow + 1, col].Holes = 0;

                                        WinLose = true;
                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_Left.Visible = false;
                                        Btn_Right.Visible = false;
                                        Btn_Up.Visible = false;
                                        Btn_Down.Visible = false;
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                        Draw();
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox sent = sender as PictureBox;

            Console.WriteLine(sent.Size.Width);
            Console.WriteLine(sent.Size.Height);
        }
    }
}
