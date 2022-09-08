namespace Marble_Game
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Btn_Left = new System.Windows.Forms.Button();
            this.Btn_Right = new System.Windows.Forms.Button();
            this.Btn_Up = new System.Windows.Forms.Button();
            this.Btn_Down = new System.Windows.Forms.Button();
            this.Btn_ReadFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.GB_Controls = new System.Windows.Forms.GroupBox();
            this.StartStop = new System.Windows.Forms.Button();
            this.HighScoreGB = new System.Windows.Forms.GroupBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.MoveLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.stopwatch1 = new DLL.Stopwatch();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.GB_Controls.SuspendLayout();
            this.HighScoreGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Left
            // 
            this.Btn_Left.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Left.Image")));
            this.Btn_Left.Location = new System.Drawing.Point(86, 86);
            this.Btn_Left.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Left.Name = "Btn_Left";
            this.Btn_Left.Size = new System.Drawing.Size(80, 49);
            this.Btn_Left.TabIndex = 0;
            this.Btn_Left.Text = "Left";
            this.Btn_Left.UseVisualStyleBackColor = true;
            this.Btn_Left.Click += new System.EventHandler(this.Btn_Left_Click);
            // 
            // Btn_Right
            // 
            this.Btn_Right.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Right.Image")));
            this.Btn_Right.Location = new System.Drawing.Point(207, 86);
            this.Btn_Right.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Right.Name = "Btn_Right";
            this.Btn_Right.Size = new System.Drawing.Size(80, 49);
            this.Btn_Right.TabIndex = 1;
            this.Btn_Right.Text = "Right";
            this.Btn_Right.UseVisualStyleBackColor = true;
            this.Btn_Right.Click += new System.EventHandler(this.Btn_Right_Click);
            // 
            // Btn_Up
            // 
            this.Btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Up.Image")));
            this.Btn_Up.Location = new System.Drawing.Point(164, 6);
            this.Btn_Up.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(50, 80);
            this.Btn_Up.TabIndex = 2;
            this.Btn_Up.Text = "Up";
            this.Btn_Up.UseVisualStyleBackColor = true;
            this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
            // 
            // Btn_Down
            // 
            this.Btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Down.Image")));
            this.Btn_Down.Location = new System.Drawing.Point(164, 137);
            this.Btn_Down.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(50, 80);
            this.Btn_Down.TabIndex = 3;
            this.Btn_Down.Text = "Down";
            this.Btn_Down.UseVisualStyleBackColor = true;
            this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
            // 
            // Btn_ReadFile
            // 
            this.Btn_ReadFile.Location = new System.Drawing.Point(3, 38);
            this.Btn_ReadFile.Name = "Btn_ReadFile";
            this.Btn_ReadFile.Size = new System.Drawing.Size(120, 35);
            this.Btn_ReadFile.TabIndex = 4;
            this.Btn_ReadFile.Text = "Read File";
            this.Btn_ReadFile.UseVisualStyleBackColor = true;
            this.Btn_ReadFile.Click += new System.EventHandler(this.Btn_ReadFile_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 677);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.GB_Controls, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.HighScoreGB, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(663, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 671);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // GB_Controls
            // 
            this.GB_Controls.Controls.Add(this.stopwatch1);
            this.GB_Controls.Controls.Add(this.StartStop);
            this.GB_Controls.Controls.Add(this.Btn_Up);
            this.GB_Controls.Controls.Add(this.Btn_ReadFile);
            this.GB_Controls.Controls.Add(this.Btn_Left);
            this.GB_Controls.Controls.Add(this.Btn_Down);
            this.GB_Controls.Controls.Add(this.Btn_Right);
            this.GB_Controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_Controls.Location = new System.Drawing.Point(0, 0);
            this.GB_Controls.Margin = new System.Windows.Forms.Padding(0);
            this.GB_Controls.Name = "GB_Controls";
            this.GB_Controls.Padding = new System.Windows.Forms.Padding(0);
            this.GB_Controls.Size = new System.Drawing.Size(294, 402);
            this.GB_Controls.TabIndex = 0;
            this.GB_Controls.TabStop = false;
            this.GB_Controls.Text = "Controls";
            // 
            // StartStop
            // 
            this.StartStop.Location = new System.Drawing.Point(8, 225);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(72, 74);
            this.StartStop.TabIndex = 7;
            this.StartStop.Text = "Pause";
            this.StartStop.UseVisualStyleBackColor = true;
            this.StartStop.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // HighScoreGB
            // 
            this.HighScoreGB.Controls.Add(this.TimeLabel);
            this.HighScoreGB.Controls.Add(this.MoveLabel);
            this.HighScoreGB.Controls.Add(this.NameLabel);
            this.HighScoreGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HighScoreGB.Location = new System.Drawing.Point(3, 405);
            this.HighScoreGB.Name = "HighScoreGB";
            this.HighScoreGB.Size = new System.Drawing.Size(288, 263);
            this.HighScoreGB.TabIndex = 1;
            this.HighScoreGB.TabStop = false;
            this.HighScoreGB.Text = "High Scores";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(222, 28);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(43, 20);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "Time";
            // 
            // MoveLabel
            // 
            this.MoveLabel.AutoSize = true;
            this.MoveLabel.Location = new System.Drawing.Point(114, 28);
            this.MoveLabel.Name = "MoveLabel";
            this.MoveLabel.Size = new System.Drawing.Size(55, 20);
            this.MoveLabel.TabIndex = 1;
            this.MoveLabel.Text = "Moves";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(6, 28);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name";
            // 
            // stopwatch1
            // 
            this.stopwatch1.Location = new System.Drawing.Point(121, 225);
            this.stopwatch1.Name = "stopwatch1";
            this.stopwatch1.Size = new System.Drawing.Size(176, 177);
            this.stopwatch1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 677);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.GB_Controls.ResumeLayout(false);
            this.HighScoreGB.ResumeLayout(false);
            this.HighScoreGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Left;
        private System.Windows.Forms.Button Btn_Right;
        private System.Windows.Forms.Button Btn_Up;
        private System.Windows.Forms.Button Btn_Down;
        private System.Windows.Forms.Button Btn_ReadFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox GB_Controls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox HighScoreGB;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label MoveLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button StartStop;
        private DLL.Stopwatch stopwatch1;
    }
}

