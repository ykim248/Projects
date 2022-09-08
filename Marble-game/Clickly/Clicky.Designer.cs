namespace Clickly
{
    partial class Clicky
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
            this.stopwatch1 = new DLL.Stopwatch();
            this.Btn_Click = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stopwatch1
            // 
            this.stopwatch1.Location = new System.Drawing.Point(12, 103);
            this.stopwatch1.Name = "stopwatch1";
            this.stopwatch1.Size = new System.Drawing.Size(271, 231);
            this.stopwatch1.TabIndex = 0;
            // 
            // Btn_Click
            // 
            this.Btn_Click.Location = new System.Drawing.Point(447, 294);
            this.Btn_Click.Name = "Btn_Click";
            this.Btn_Click.Size = new System.Drawing.Size(81, 40);
            this.Btn_Click.TabIndex = 1;
            this.Btn_Click.Text = "Click Me";
            this.Btn_Click.UseVisualStyleBackColor = true;
            this.Btn_Click.Click += new System.EventHandler(this.Btn_Click_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "How fast can you click to twenty?";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(462, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // Clicky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_Click);
            this.Controls.Add(this.stopwatch1);
            this.Name = "Clicky";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DLL.Stopwatch stopwatch1;
        private System.Windows.Forms.Button Btn_Click;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

