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
            this.SuspendLayout();
            // 
            // Btn_Left
            // 
            this.Btn_Left.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Left.Image")));
            this.Btn_Left.Location = new System.Drawing.Point(314, 86);
            this.Btn_Left.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Left.Name = "Btn_Left";
            this.Btn_Left.Size = new System.Drawing.Size(75, 50);
            this.Btn_Left.TabIndex = 0;
            this.Btn_Left.Text = "Left";
            this.Btn_Left.UseVisualStyleBackColor = true;
            this.Btn_Left.Click += new System.EventHandler(this.Btn_Left_Click);
            // 
            // Btn_Right
            // 
            this.Btn_Right.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Right.Image")));
            this.Btn_Right.Location = new System.Drawing.Point(447, 86);
            this.Btn_Right.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Right.Name = "Btn_Right";
            this.Btn_Right.Size = new System.Drawing.Size(75, 50);
            this.Btn_Right.TabIndex = 1;
            this.Btn_Right.Text = "Right";
            this.Btn_Right.UseVisualStyleBackColor = true;
            this.Btn_Right.Click += new System.EventHandler(this.Btn_Right_Click);
            // 
            // Btn_Up
            // 
            this.Btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Up.Image")));
            this.Btn_Up.Location = new System.Drawing.Point(393, 11);
            this.Btn_Up.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Up.Name = "Btn_Up";
            this.Btn_Up.Size = new System.Drawing.Size(50, 75);
            this.Btn_Up.TabIndex = 2;
            this.Btn_Up.Text = "Up";
            this.Btn_Up.UseVisualStyleBackColor = true;
            this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
            // 
            // Btn_Down
            // 
            this.Btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Down.Image")));
            this.Btn_Down.Location = new System.Drawing.Point(393, 140);
            this.Btn_Down.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(50, 75);
            this.Btn_Down.TabIndex = 3;
            this.Btn_Down.Text = "Down";
            this.Btn_Down.UseVisualStyleBackColor = true;
            this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.Btn_Down);
            this.Controls.Add(this.Btn_Up);
            this.Controls.Add(this.Btn_Right);
            this.Controls.Add(this.Btn_Left);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Left;
        private System.Windows.Forms.Button Btn_Right;
        private System.Windows.Forms.Button Btn_Up;
        private System.Windows.Forms.Button Btn_Down;
    }
}

