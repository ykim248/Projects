namespace DLL
{
    partial class Read_File
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Read_File));
            this.listView1 = new System.Windows.Forms.ListView();
            this.ListName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Btn_Open = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Btn_Lvl_Up = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Label_Size = new System.Windows.Forms.Label();
            this.Label_Balls = new System.Windows.Forms.Label();
            this.Label_Walls = new System.Windows.Forms.Label();
            this.PB_Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ListName,
            this.Size,
            this.DateModified});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(513, 49);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(436, 364);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1Single_Click);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1Double_Click);
            // 
            // ListName
            // 
            this.ListName.Text = "Name";
            this.ListName.Width = 128;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 78;
            // 
            // DateModified
            // 
            this.DateModified.Text = "Date Modified";
            this.DateModified.Width = 90;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "MRB.png");
            this.imageList1.Images.SetKeyName(1, "jpg.jpg");
            this.imageList1.Images.SetKeyName(2, "OtherImage.png");
            this.imageList1.Images.SetKeyName(3, "FolderImage.png");
            // 
            // Btn_Open
            // 
            this.Btn_Open.Location = new System.Drawing.Point(513, 426);
            this.Btn_Open.Name = "Btn_Open";
            this.Btn_Open.Size = new System.Drawing.Size(116, 40);
            this.Btn_Open.TabIndex = 6;
            this.Btn_Open.Text = "Open";
            this.Btn_Open.UseVisualStyleBackColor = true;
            this.Btn_Open.Click += new System.EventHandler(this.Btn_Open_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(644, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.WordWrap = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchKeyEnter);
            // 
            // Btn_Lvl_Up
            // 
            this.Btn_Lvl_Up.Location = new System.Drawing.Point(664, 6);
            this.Btn_Lvl_Up.Name = "Btn_Lvl_Up";
            this.Btn_Lvl_Up.Size = new System.Drawing.Size(128, 40);
            this.Btn_Lvl_Up.TabIndex = 9;
            this.Btn_Lvl_Up.Text = "One Level Up";
            this.Btn_Lvl_Up.UseVisualStyleBackColor = true;
            this.Btn_Lvl_Up.Click += new System.EventHandler(this.Btn_Lvl_Up_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Location = new System.Drawing.Point(836, 426);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(116, 40);
            this.Btn_Cancel.TabIndex = 7;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Label_Size
            // 
            this.Label_Size.AutoSize = true;
            this.Label_Size.Location = new System.Drawing.Point(18, 426);
            this.Label_Size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Size.Name = "Label_Size";
            this.Label_Size.Size = new System.Drawing.Size(48, 20);
            this.Label_Size.TabIndex = 10;
            this.Label_Size.Text = "Size: ";
            // 
            // Label_Balls
            // 
            this.Label_Balls.AutoSize = true;
            this.Label_Balls.Location = new System.Drawing.Point(174, 426);
            this.Label_Balls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Balls.Name = "Label_Balls";
            this.Label_Balls.Size = new System.Drawing.Size(51, 20);
            this.Label_Balls.TabIndex = 11;
            this.Label_Balls.Text = "Balls: ";
            // 
            // Label_Walls
            // 
            this.Label_Walls.AutoSize = true;
            this.Label_Walls.Location = new System.Drawing.Point(328, 426);
            this.Label_Walls.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Walls.Name = "Label_Walls";
            this.Label_Walls.Size = new System.Drawing.Size(51, 20);
            this.Label_Walls.TabIndex = 12;
            this.Label_Walls.Text = "Walls:";
            // 
            // PB_Preview
            // 
            this.PB_Preview.Location = new System.Drawing.Point(22, 49);
            this.PB_Preview.Name = "PB_Preview";
            this.PB_Preview.Size = new System.Drawing.Size(360, 369);
            this.PB_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PB_Preview.TabIndex = 13;
            this.PB_Preview.TabStop = false;
            // 
            // Read_File
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 483);
            this.Controls.Add(this.PB_Preview);
            this.Controls.Add(this.Label_Walls);
            this.Controls.Add(this.Label_Balls);
            this.Controls.Add(this.Label_Size);
            this.Controls.Add(this.Btn_Lvl_Up);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Open);
            this.Name = "Read_File";
            this.Text = "Read_File";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Preview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ListName;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader DateModified;
        private System.Windows.Forms.Button Btn_Open;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Btn_Lvl_Up;

        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Label Label_Size;
        private System.Windows.Forms.Label Label_Balls;
        private System.Windows.Forms.Label Label_Walls;
        private System.Windows.Forms.PictureBox PB_Preview;
        private System.Windows.Forms.ImageList imageList1;
    }
}