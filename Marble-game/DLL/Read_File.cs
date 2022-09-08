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




namespace DLL
{
    public partial class Read_File : Form
    {

        public string FullPath;
        private string tempLocation = string.Empty;
        private string GamePath;
        private string binfile;

        public Read_File()
        {
            InitializeComponent();
            FullPath = Directory.GetCurrentDirectory();
            GetDirectory();
        }

        public string gamepath
        {
            set
            {
                GamePath = value;
            }
            get
            {
                return GamePath;
            }
        }

        public string BinFile
        {
            set
            {
                binfile = value;
            }
            get
            {
                return binfile;
            }
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Btn_Open_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                string SelectedFile = this.listView1.SelectedItems[0].Text;
                string NextPath = FullPath + "\\" + SelectedFile;
                string SelectedFileType = Path.GetExtension(SelectedFile);
                if (SelectedFileType == ".mrb")
                {
                    this.DialogResult = DialogResult.Yes;
                    extract(NextPath);
                    BinFile = NextPath;
                    this.Close();

                }
                else if (SelectedFileType == "")
                {
                    FullPath = NextPath;
                    GetDirectory();
                }
            }


        }



        private void GetDirectory()
        {
            listView1.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(FullPath);
            if (FullPath != "C:\\")
            {
                textBox1.Text = FullPath;
            }
            else
            {
                MessageBox.Show("At Root Directory");
            }


            FileInfo[] filelist = dirInfo.GetFiles();
            DirectoryInfo[] directories = dirInfo.GetDirectories();

            foreach (DirectoryInfo directory in directories)
            {

                string directoryName = directory.Name;
                string directoryDate = directory.LastWriteTime.ToString();
                string fileType = "Folder";
                string[] row = { directoryDate, fileType };

                ListViewItem NewItems = new ListViewItem();
                NewItems.Text = directoryName;
                NewItems.SubItems.AddRange(row);
                NewItems.ImageIndex = 4;
                listView1.Items.Add(NewItems);
            }

            foreach (FileInfo file in filelist)
            {
                ListViewItem NewItem = new ListViewItem();
                string filesize = FileSize((int)file.Length);
                string[] row1 = { filesize, (file.LastWriteTime.ToString()) };

                //listView1.Items.Add(file.Name).SubItems.AddRange(row1);
                NewItem.Text = file.Name;
                NewItem.SubItems.AddRange(row1);

                string extension = System.IO.Path.GetExtension(file.Name);
                int icon = 10;

                if (extension == ".mrb")
                {
                    icon = 0;
                }
                else if (extension == ".jpg" || extension == ".png")
                {
                    icon = 1;
                }
                else if (extension == ".txt")
                {
                    icon = 2;
                }
                else
                {
                    icon = 3;
                }
                NewItem.ImageIndex = icon;
                listView1.Items.Add(NewItem);

                //listView1.Items.Add(file.Name).SubItems.Add(file.Length.ToString()).SubItems.Add(file.LastWriteTime.ToString());

                //listView1.Items.Add(file.Length.ToString());
                //listView1.Items.Add(file.LastWriteTime.ToString());
            }
        }
        private string FileSize(int bytes)
        {
            string memory = bytes.ToString() + " B";
            if (bytes > 1000)
            {
                memory = (bytes / 1000).ToString() + " KB";
            }
            else if (bytes > 1000000)
            {
                memory = (bytes / 1000000).ToString() + " MB";
            }
            return memory;
        }

        private void Btn_Lvl_Up_Click(object sender, EventArgs e)
        {
            if (Directory.GetParent(FullPath) == null)
            {
                MessageBox.Show("At Root");
            }
            else
            {
                string DirPath = Directory.GetParent(FullPath).ToString();
                FullPath = DirPath;
                if (PB_Preview.Image != null)
                {
                    PB_Preview.Image = null;
                    PB_Preview.Invalidate();
                    this.Label_Size.Text = "Size: ";
                    this.Label_Balls.Text = "Balls: ";
                    this.Label_Walls.Text = "Walls: ";
                }
                GetDirectory();
            }
        }

        private void listView1Single_Click(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                string SelectedFile = this.listView1.SelectedItems[0].Text;
                string NextPath = Path.Combine(textBox1.Text, SelectedFile);
                string SelectedFileType = Path.GetExtension(SelectedFile);

                this.Label_Size.Text = "Size: ";
                this.Label_Balls.Text = "Balls: ";
                this.Label_Walls.Text = "Walls: ";

                if (SelectedFileType == ".mrb")
                {
                    if (tempLocation != "")
                    {
                        RemoveTempDirectory();
                    }

                    using (ZipArchive Archive = ZipFile.OpenRead(NextPath))
                    {
                        tempLocation = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                        Directory.CreateDirectory(tempLocation);

                        foreach (ZipArchiveEntry File in Archive.Entries)
                        {
                            File.ExtractToFile(Path.Combine(tempLocation, File.FullName), true);
                        }



                        string[] Lines = System.IO.File.ReadAllLines(Path.Combine(tempLocation, Archive.Entries[1].ToString()));
                        string[] GameInfo = Lines[0].Split(' ');

                        this.Label_Size.Text = "Size: " + GameInfo[0];
                        this.Label_Balls.Text = "Balls: " + GameInfo[1];
                        this.Label_Walls.Text = "Walls: " + GameInfo[2];
                    }


                    float ratio = 0; // picturebox w = 330, h = 273
                    using (Image tmp_image = Image.FromFile(Path.Combine(tempLocation, "puzzle.jpg")))
                    {
                        if (tmp_image.Height > tmp_image.Width)  //Tall
                        {
                            if (tmp_image.Height > 240)
                            {
                                ratio = (float)tmp_image.Height / 240;
                            }
                            else
                            {
                                ratio = 240 / (float)tmp_image.Height;
                            }
                        }
                        else //Wide
                        {
                            if (tmp_image.Width > 240)
                            {
                                ratio = (float)tmp_image.Width / 240;
                            }
                            else
                            {
                                ratio = 240 / (float)tmp_image.Width;
                            }
                        }

                        float newHeight = tmp_image.Height / ratio;
                        float newWidth = tmp_image.Width / ratio;

                        Bitmap bm = new Bitmap(PB_Preview.Width, PB_Preview.Height);
                        Rectangle r = new Rectangle(0, 0, (int)newWidth, (int)newHeight);
                        Graphics g = Graphics.FromImage(bm);
                        g.DrawImage(tmp_image, r, 0, 0, tmp_image.Width, tmp_image.Height, GraphicsUnit.Pixel);
                        PB_Preview.Image = bm;
                    }
                }
                else
                {
                    PB_Preview.Image = null;
                    PB_Preview.Invalidate();
                    this.Label_Size.Text = "Size: ";
                    this.Label_Balls.Text = "Balls: ";
                    this.Label_Walls.Text = "Walls: ";
                }
            }
        }

        private void listView1Double_Click(object sender, MouseEventArgs e)
        {
            string SelectedFile = this.listView1.SelectedItems[0].Text;
            string NextPath = FullPath + "\\" + SelectedFile;
            string SelectedFileType = Path.GetExtension(SelectedFile);
            if (SelectedFileType == ".mrb")
            {
                this.DialogResult = DialogResult.Yes;
                extract(NextPath);
                BinFile = NextPath;
                this.Close();

            }
            else if (SelectedFileType == "")
            {
                FullPath = NextPath;
                GetDirectory();
            }


        }

        private void SearchKeyEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string temp = FullPath;
                string SelectedFile = this.textBox1.Text;
                string NextPath = SelectedFile;
                if (Directory.Exists(textBox1.Text))
                {
                    FullPath = NextPath;
                    GetDirectory();
                }
                else
                {
                    MessageBox.Show("Nah Fam");
                    FullPath = temp;
                    GetDirectory();

                }
            }
        }

        private void extract(string mrbFile)
        {
            if (tempLocation != null)
            {
                RemoveTempDirectory();
            }
            tempLocation = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            Directory.CreateDirectory(tempLocation);

            using (ZipArchive archive = ZipFile.OpenRead(mrbFile))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(tempLocation, entry.FullName), true);
                }
            }
            gamepath = tempLocation;
        }

        private void RemoveTempDirectory()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(tempLocation);
            FileInfo[] fileList = dirInfo.GetFiles();
            foreach (FileInfo file in fileList)
            {
                File.Delete(file.FullName);
            }
            Directory.Delete(tempLocation);
        }

        //private void PreviewLables()
        //{
        //    string txtPath = System.IO.Path.Combine(tempLocation, "puzzle.txt");
        //    string[] lines = System.IO.File.ReadAllLines(txtPath);
        //    string[] pieces = lines[0].Split(' ');
        //    int size = Convert.ToInt32(pieces[0]);
        //    int ballCount = Convert.ToInt32(pieces[1]);
        //    int wallCount = Convert.ToInt32(pieces[2]);
        //    this.Label_Size.Text = "Size: " + size;
        //    this.Label_Balls.Text = "Balls: " + ballCount;
        //    this.Label_Walls.Text = "Walls: " + wallCount;
        //}
    }
}
