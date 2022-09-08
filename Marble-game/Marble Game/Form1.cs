using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;



namespace Marble_Game
{
    public partial class Form1 : Form
    {
        String fileContent = String.Empty;
        String CurrentPath = String.Empty;
        private List<PersonItem> ExistingPersonList;
        

        int NumMoves = 0;
        private string PlayerName;
        private int minutes, seconds;

        private Label[] NameLBL;
        private Label[] MoveLBL;
        private Label[] TimeLBL;

        int PuzzleSize;
        int BallsinPlay;
        bool WinLose = false;
        bool Created = false;
        Image imgTemp;

        private MarblePictureBox[,] pbxGrid;
        private TableLayoutPanel puzzlePanel;
        private TableLayoutPanel puzzlePanel2;

        private int oldWidth;
        private int oldHeight;
        private int oldDimensions;


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
                    g.DrawImage(imgTemp, r, pw * X, ph * Y, pw, ph, GraphicsUnit.Pixel);
                    pbxGrid[row, col].SizeMode = PictureBoxSizeMode.StretchImage;
                    Font f = new Font("Arial", 30f);
                    String StringValue = "";
                    Brush StringBrush = Brushes.White;
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;
                    



                    if (pbxGrid[row, col].Balls > 0)
                    {
                        StringValue = Convert.ToString(pbxGrid[row, col].Balls);
                    }

                    if (pbxGrid[row, col].Holes > 0)
                    {
                        StringValue = Convert.ToString(pbxGrid[row, col].Holes);
                    }
                    g.DrawString(StringValue, f, StringBrush, r, sf);

                    pbxGrid[row, col].Image = bm;
                }
            }




        }

        public Form1()
        {
            InitializeComponent();
            oldWidth = this.Width;
            oldHeight = this.Height;
            DLL.Stopwatch stopwatch1 = new DLL.Stopwatch();
        }

        private void Btn_Left_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                NumMoves++;
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

                                        if (BallsinPlay == 0)
                                        {
                                            WinLose = true;
                                            EnterPlayerName();
                                            Btn_visible(false);                                            
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (pbxGrid[row, tempcol - 1].Balls != pbxGrid[row, tempcol - 1].Holes && pbxGrid[row, tempcol - 1].Holes > 0)
                                    {
                                        pbxGrid[row, tempcol - 1].Error = true;
                                        pbxGrid[row, tempcol - 1].Balls = 0;
                                        pbxGrid[row, tempcol - 1].Holes = 0;

                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_visible(false);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            Draw();
        }

        private void Btn_Right_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                NumMoves++;
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
                                            EnterPlayerName();
                                            Btn_visible(false);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (pbxGrid[row, tempcol + 1].Balls != pbxGrid[row, tempcol + 1].Holes && pbxGrid[row, tempcol + 1].Holes > 0)
                                    {
                                        pbxGrid[row, tempcol + 1].Error = true;
                                        pbxGrid[row, tempcol + 1].Balls = 0;
                                        pbxGrid[row, tempcol + 1].Holes = 0;

                                        WinLose = true;
                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_visible(false);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            Draw();
        }

        private void Btn_Up_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                NumMoves++;
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
                                            EnterPlayerName();
                                            Btn_visible(false);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    else if (pbxGrid[temprow - 1, col].Balls != pbxGrid[temprow - 1, col].Holes && pbxGrid[temprow - 1, col].Holes > 0)
                                    {
                                        pbxGrid[temprow - 1, col].Error = true;
                                        pbxGrid[temprow - 1, col].Balls = 0;
                                        pbxGrid[temprow - 1, col].Holes = 0;

                                        WinLose = true;
                                        MessageBox.Show("Wrong hole! First time?");

                                        Btn_visible(false);
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                    }
                }
            }
            Draw();
        }

        private void Btn_Down_Click(object sender, EventArgs e)
        {
            if (WinLose == false)
            {
                NumMoves++;
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
                                            EnterPlayerName();
                                            Btn_visible(false);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    else if (pbxGrid[temprow + 1, col].Balls != pbxGrid[temprow + 1, col].Holes && pbxGrid[temprow + 1, col].Holes > 0)
                                    {
                                        pbxGrid[temprow + 1, col].Error = true;
                                        pbxGrid[temprow + 1, col].Balls = 0;
                                        pbxGrid[temprow + 1, col].Holes = 0;

                                        WinLose = true;
                                        MessageBox.Show("Wrong hole! First time?");
                                        Btn_visible(false);
                                    }
                                }
                                else
                                {
                                    break;
                                }

                            }
                        }
                    }
                }
            }
            Draw();
        }

        private void Btn_visible(bool TrueFalse)
        {
            Btn_Left.Visible = TrueFalse;
            Btn_Right.Visible = TrueFalse;
            Btn_Up.Visible = TrueFalse;
            Btn_Down.Visible = TrueFalse;
        }

        //size of form is w = 456 and h = 279 dw = 177
        private void Btn_ReadFile_Click(object sender, EventArgs e)
        {
            stopwatch1.Pause();
            
            DLL.Read_File NewGame = new DLL.Read_File();
            if (NewGame.ShowDialog() == DialogResult.Yes)
            {

                WinLose = false;
                fileContent = NewGame.gamepath;
                CurrentPath = NewGame.BinFile;
                Created = true;
                NumMoves = 0;
                stopwatch1.Stop();

                stopwatch1.Start();
            }
            else
            {
                stopwatch1.Start();
                return;                
            }

            

            string fileimg = fileContent + "/" + "puzzle.jpg";
            string filepath = fileContent + "/" + "puzzle.txt";
            string filescores = fileContent + "/" + "puzzle.bin";

            //IFormatter formatter = new BinaryFormatter();
            //using (ZipArchive archive = ZipFile.Open(CurrentPath, ZipArchiveMode.Update))
            //{
            //    ZipArchiveEntry entry = archive.GetEntry("puzzle.bin");

            //    if(entry != null)
            //    {
            //        Stream stream = entry.Open();

            //        if(stream.Length > 0)
            //        {
            //            ExistingPersonList = ((List < PersonItem >) formatter.Deserialize(stream));
            //            PlayerList();

            //        }
            //    }
            //    else
            //    {
            //        ExistingPersonList = new List<PersonItem>();
            //    }

            //}

            extractBin(fileContent);

            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] pieces = lines[0].Split(' ');
            int size = Convert.ToInt32(pieces[0]);
            int ballCount = Convert.ToInt32(pieces[1]);
            int wallCount = Convert.ToInt32(pieces[2]);

            imgTemp = Image.FromFile(fileimg);

            BallsinPlay = ballCount;

            PuzzleSize = size;

            int PBWidth = 0;
            int PBHeight = 0;

            int reservedSpace = 250;
            float ratio = 0;

            oldWidth = this.Width;
            oldHeight = this.Height;

            

            if (imgTemp.Height >= imgTemp.Width)
            {
                //PBWidth = reservedSpace / size;
                //PBHeight = (imgTemp.Width * PBWidth) / imgTemp.Height;

                ratio = (float)imgTemp.Width / (float)imgTemp.Height;
                //PBHeight = reservedSpace / size;
                //PBWidth = (int)(imgTemp.Width / ratio) / size;
            }
            else
            {                
                //PBHeight = reservedSpace / size;
                //PBWidth = (imgTemp.Width * PBHeight) / imgTemp.Width;

                ratio = (float)imgTemp.Height / (float)imgTemp.Width;
                //PBWidth = reservedSpace / size;
                //PBHeight = (int)(imgTemp.Height / ratio) / size;

            }



            //Called pbxGrid


            //if (pbxGrid != null)
            //{
            //    for (int row = 0; row < size; row++)
            //    {
            //        for (int col = 0; col < size; col++)
            //        {
            //            this.Controls.Remove(pbxGrid[row, col]);
            //        }
            //    }
            //    pbxGrid = null;
            //}


            pbxGrid = new MarblePictureBox[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    pbxGrid[row, col] = new MarblePictureBox();
                    pbxGrid[row, col].BackColor = System.Drawing.Color.Red;
                    pbxGrid[row, col].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pbxGrid[row, col].SizeMode = PictureBoxSizeMode.StretchImage;
                    pbxGrid[row, col].Dock = DockStyle.Fill;
                    pbxGrid[row, col].Margin = new System.Windows.Forms.Padding(0);
                    //pbxGrid[row, col].Size = new System.Drawing.Size(PBWidth, PBHeight);
                    //pbxGrid[row, col].Location = new System.Drawing.Point(PBWidth * col + 50, PBHeight * row + 15);

                    Controls.Add(pbxGrid[row, col]);
                }
            }

            for (int idx = 1; idx <= ballCount; idx++)
            {

                string[] coords = lines[idx].Split(' ');
                int r = Convert.ToInt32(coords[0]);
                int c = Convert.ToInt32(coords[1]);

                pbxGrid[r, c].Balls = idx;
            }

            for (int idx = ballCount + 1; idx <= ballCount + ballCount; idx++)
            {
                string[] coords = lines[idx].Split(' ');
                int r = Convert.ToInt32(coords[0]);
                int c = Convert.ToInt32(coords[1]);

                pbxGrid[r, c].Holes = idx - ballCount;
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
                        pbxGrid[r1, c1].rightwall = true;
                        pbxGrid[r2, c2].leftwall = true;
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
            }

            int Dimension = size;
            float PBSize = 100f / Dimension;

            if (puzzlePanel2 != null)
            {
                for (int row = 0; row < oldDimensions; row++)
                {
                    for (int col = 0; col < oldDimensions; col++)
                    {
                        puzzlePanel2.Controls.RemoveAt(0);
                    }
                }

                //DFS: added after the end of the class video
                tableLayoutPanel1.Controls.Remove(puzzlePanel);
            }


            puzzlePanel = new TableLayoutPanel();
            puzzlePanel.Dock = DockStyle.Fill;
            puzzlePanel.Margin = new System.Windows.Forms.Padding(0);
            oldDimensions = Dimension;
            if (imgTemp.Width > imgTemp.Height)
            {
                puzzlePanel.RowCount = 2;
                puzzlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, ratio * 100));
                puzzlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, Math.Abs((ratio * 100) - 100)));
                tableLayoutPanel1.Controls.Add(puzzlePanel, 0, 0);
            }
            else if (imgTemp.Height > imgTemp.Width)
            {
                puzzlePanel.ColumnCount = 2;
                puzzlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, ratio * 100));
                puzzlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, Math.Abs((ratio * 100) - 100)));
                tableLayoutPanel1.Controls.Add(puzzlePanel, 0, 0);

            }
            else
            {
                puzzlePanel.RowCount = 1;
                puzzlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (ratio * 100)));
                tableLayoutPanel1.Controls.Add(puzzlePanel, 0, 0);
            }

            puzzlePanel2 = new TableLayoutPanel();
            puzzlePanel2.Dock = DockStyle.Fill;
            puzzlePanel2.Margin = new System.Windows.Forms.Padding(0);
            puzzlePanel2.ColumnCount = Dimension;
            puzzlePanel2.RowCount = Dimension;
            puzzlePanel.Controls.Add(puzzlePanel2, 0, 0);
            oldDimensions = Dimension;

            for (int row = 0; row < Dimension; row++)
            {
                puzzlePanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, PBSize));
                puzzlePanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, PBSize));

                for (int col = 0; col < Dimension; col++)
                {
                   
                    puzzlePanel2.Controls.Add(pbxGrid[row, col], col, row);
                    Draw();

                }
            }
            Btn_visible(true);
        }

        private void extractBin(string file)
        {
            string BinFile = Path.Combine(file, "puzzle.bin");

            FileInfo NewFileInfo = new FileInfo(BinFile);

            if (NewFileInfo.Exists == true)
            {
                using (FileStream stream = new FileStream(BinFile, FileMode.Open, FileAccess.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    ExistingPersonList = (List<PersonItem>)formatter.Deserialize(stream);
                }

                PlayerList();
            }
            else
            {
                ExistingPersonList = new List<PersonItem>();
            }
        }

        private void AddWinner(string PlayerName)
        {
            PersonItem NewEntry = new PersonItem();
            NewEntry.Name = PlayerName;
            NewEntry.Moves = NumMoves;
            NewEntry.Time = (stopwatch1.Minutes * 60) + stopwatch1.Seconds;

            ExistingPersonList.Add(NewEntry);

            PlayerList();
        }

        private void EnterPlayerName()
        {
            stopwatch1.Stop();
            MessageBox.Show("You Won!");
            PlayerName = Interaction.InputBox("Enter Player Name");

            if (PlayerName == "")
            {
                PlayerName = "Jizanthapus";
            }

            AddWinner(PlayerName);

            //PlayerList();

            IFormatter formatter = new BinaryFormatter();
            //string PersonFile = Path.Combine(CurrentPath, "puzzle.bin");
            //using (FileStream stream = new FileStream(PersonFile, FileMode.Create))
            //{
            //    formatter.Serialize(stream, ExistingPersonList);
            //}

            //location for zip file to add bin file to:
            string archiveLocation = Path.GetFileName(CurrentPath);
            using (ZipArchive archive = ZipFile.Open(CurrentPath, ZipArchiveMode.Update))
            {
                //Needed to prevent multiple files of same name in zip
                ZipArchiveEntry entry = archive.GetEntry("puzzle.bin");
                if (entry != null)
                {
                    entry.Delete();
                }

                ZipArchiveEntry peopleList = archive.CreateEntry("puzzle.bin");
                using (Stream stream = peopleList.Open())
                {
                    formatter.Serialize(stream, ExistingPersonList);
                }
            }
        }

        private void PlayerList()
        {
            HighScoreGB.Controls.Clear();
            HighScoreGB.Controls.Add(NameLabel);
            HighScoreGB.Controls.Add(MoveLabel);
            HighScoreGB.Controls.Add(TimeLabel);

            NameLBL = new Label[5];
            MoveLBL = new Label[5];
            TimeLBL = new Label[5];

            sortList();
            
            for (int i = 0; i < ExistingPersonList.Count; i++)
            {
                if(i < 5)
                {
                    addPersonList(ExistingPersonList[i], i);
                }
                
            }

        }

        private void addPersonList(PersonItem Person, int personindex)
        {
            NameLBL = new Label[5];
            MoveLBL = new Label[5];
            TimeLBL = new Label[5];

            NameLBL[personindex] = new Label();
            NameLBL[personindex].Text = Person.Name;
            NameLBL[personindex].Location = new System.Drawing.Point(9, 36 + personindex * 20);
            NameLBL[personindex].AutoSize = true;
            HighScoreGB.Controls.Add(NameLBL[personindex]);

            MoveLBL[personindex] = new Label();
            MoveLBL[personindex].Text = Person.Moves.ToString();
            MoveLBL[personindex].Location = new System.Drawing.Point(80, 36 + personindex * 20);
            MoveLBL[personindex].AutoSize = true;
            HighScoreGB.Controls.Add(MoveLBL[personindex]);

            TimeLBL[personindex] = new Label();
            TimeLBL[personindex].Text = Person.Time.ToString();
            TimeLBL[personindex].Location = new System.Drawing.Point(151, 36 + personindex * 20);
            TimeLBL[personindex].AutoSize = true;
            HighScoreGB.Controls.Add(TimeLBL[personindex]);
        }

        private void sortList()
        {
            ExistingPersonList = ExistingPersonList.OrderBy(s => s.Moves).ThenBy(s => s.Time).ToList();
        }

        bool Paused = true;

        //private void NonButtonStart()
        //{
        //    if (Paused)
        //    {
        //        Paused = false;

        //        StartStop.Text = "Pause";
        //        stopwatch1.Start();
        //    }
        //    else
        //    {
        //        Paused = true;

        //        StartStop.Text = "Start";
        //        stopwatch1.Pause();
        //    }
        //}

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            if (Paused)
            {
                Paused = false;

                StartStop.Text = "Pause";
                stopwatch1.Start();


                puzzlePanel2.Show();
            }
            else
            {
                Paused = true;

                StartStop.Text = "Start";
                stopwatch1.Pause();

                puzzlePanel2.Hide();
            }
            Btn_visible(!Paused);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
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
