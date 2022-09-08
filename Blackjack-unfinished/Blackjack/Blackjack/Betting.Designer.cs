namespace Blackjack
{
    partial class Betting
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
            this.TotalCashLabel = new System.Windows.Forms.Label();
            this.BettingLabel = new System.Windows.Forms.Label();
            this.Btn_1 = new System.Windows.Forms.Button();
            this.Btn_5 = new System.Windows.Forms.Button();
            this.Btn_10 = new System.Windows.Forms.Button();
            this.Btn_20 = new System.Windows.Forms.Button();
            this.Btn_Deal = new System.Windows.Forms.Button();
            this.Btn_AllInn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TotalCashLabel
            // 
            this.TotalCashLabel.AutoSize = true;
            this.TotalCashLabel.Location = new System.Drawing.Point(41, 42);
            this.TotalCashLabel.Name = "TotalCashLabel";
            this.TotalCashLabel.Size = new System.Drawing.Size(58, 13);
            this.TotalCashLabel.TabIndex = 0;
            this.TotalCashLabel.Text = "TotalCash:";
            // 
            // BettingLabel
            // 
            this.BettingLabel.AutoSize = true;
            this.BettingLabel.Location = new System.Drawing.Point(359, 42);
            this.BettingLabel.Name = "BettingLabel";
            this.BettingLabel.Size = new System.Drawing.Size(26, 13);
            this.BettingLabel.TabIndex = 1;
            this.BettingLabel.Text = "Bet:";
            // 
            // Btn_1
            // 
            this.Btn_1.Location = new System.Drawing.Point(37, 110);
            this.Btn_1.Name = "Btn_1";
            this.Btn_1.Size = new System.Drawing.Size(75, 25);
            this.Btn_1.TabIndex = 2;
            this.Btn_1.Text = "$1";
            this.Btn_1.UseVisualStyleBackColor = true;
            this.Btn_1.Click += new System.EventHandler(this.Btn_1_Click);
            // 
            // Btn_5
            // 
            this.Btn_5.Location = new System.Drawing.Point(149, 110);
            this.Btn_5.Name = "Btn_5";
            this.Btn_5.Size = new System.Drawing.Size(75, 25);
            this.Btn_5.TabIndex = 3;
            this.Btn_5.Text = "$5";
            this.Btn_5.UseVisualStyleBackColor = true;
            this.Btn_5.Click += new System.EventHandler(this.Btn_5_Click);
            // 
            // Btn_10
            // 
            this.Btn_10.Location = new System.Drawing.Point(261, 110);
            this.Btn_10.Name = "Btn_10";
            this.Btn_10.Size = new System.Drawing.Size(75, 25);
            this.Btn_10.TabIndex = 4;
            this.Btn_10.Text = "$10";
            this.Btn_10.UseVisualStyleBackColor = true;
            this.Btn_10.Click += new System.EventHandler(this.Btn_10_Click);
            // 
            // Btn_20
            // 
            this.Btn_20.Location = new System.Drawing.Point(373, 110);
            this.Btn_20.Name = "Btn_20";
            this.Btn_20.Size = new System.Drawing.Size(75, 25);
            this.Btn_20.TabIndex = 5;
            this.Btn_20.Text = "$20";
            this.Btn_20.UseVisualStyleBackColor = true;
            this.Btn_20.Click += new System.EventHandler(this.Btn_20_Click);
            // 
            // Btn_Deal
            // 
            this.Btn_Deal.Location = new System.Drawing.Point(182, 196);
            this.Btn_Deal.Name = "Btn_Deal";
            this.Btn_Deal.Size = new System.Drawing.Size(120, 50);
            this.Btn_Deal.TabIndex = 6;
            this.Btn_Deal.Text = "Deal";
            this.Btn_Deal.UseVisualStyleBackColor = true;
            this.Btn_Deal.Click += new System.EventHandler(this.Btn_Deal_Click);
            // 
            // Btn_AllInn
            // 
            this.Btn_AllInn.Location = new System.Drawing.Point(205, 152);
            this.Btn_AllInn.Name = "Btn_AllInn";
            this.Btn_AllInn.Size = new System.Drawing.Size(75, 25);
            this.Btn_AllInn.TabIndex = 7;
            this.Btn_AllInn.Text = "All In";
            this.Btn_AllInn.UseVisualStyleBackColor = true;
            this.Btn_AllInn.Click += new System.EventHandler(this.Btn_AllInn_Click);
            // 
            // Betting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.Btn_AllInn);
            this.Controls.Add(this.Btn_Deal);
            this.Controls.Add(this.Btn_20);
            this.Controls.Add(this.Btn_10);
            this.Controls.Add(this.Btn_5);
            this.Controls.Add(this.Btn_1);
            this.Controls.Add(this.BettingLabel);
            this.Controls.Add(this.TotalCashLabel);
            this.Name = "Betting";
            this.Text = "Betting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TotalCashLabel;
        private System.Windows.Forms.Label BettingLabel;
        private System.Windows.Forms.Button Btn_1;
        private System.Windows.Forms.Button Btn_5;
        private System.Windows.Forms.Button Btn_10;
        private System.Windows.Forms.Button Btn_20;
        private System.Windows.Forms.Button Btn_Deal;
        private System.Windows.Forms.Button Btn_AllInn;
    }
}