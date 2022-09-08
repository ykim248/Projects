namespace Blackjack
{
    partial class Blackjack
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PlayingPanel = new System.Windows.Forms.Panel();
            this.PlayingTable = new System.Windows.Forms.TableLayoutPanel();
            this.PlayerTable = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerValue = new System.Windows.Forms.Label();
            this.DealerTable = new System.Windows.Forms.Panel();
            this.Label_Pot = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DealerValue = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.Btn_Double = new System.Windows.Forms.Button();
            this.Btn_Split = new System.Windows.Forms.Button();
            this.Btn_Stand = new System.Windows.Forms.Button();
            this.Btn_Play = new System.Windows.Forms.Button();
            this.Btn_Hit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.PlayingPanel.SuspendLayout();
            this.PlayingTable.SuspendLayout();
            this.PlayerTable.SuspendLayout();
            this.DealerTable.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.PlayingPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonPanel, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 456);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PlayingPanel
            // 
            this.PlayingPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlayingPanel.Controls.Add(this.PlayingTable);
            this.PlayingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayingPanel.Location = new System.Drawing.Point(192, 0);
            this.PlayingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PlayingPanel.Name = "PlayingPanel";
            this.PlayingPanel.Size = new System.Drawing.Size(385, 456);
            this.PlayingPanel.TabIndex = 0;
            // 
            // PlayingTable
            // 
            this.PlayingTable.ColumnCount = 1;
            this.PlayingTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PlayingTable.Controls.Add(this.PlayerTable, 0, 1);
            this.PlayingTable.Controls.Add(this.DealerTable, 0, 0);
            this.PlayingTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayingTable.Location = new System.Drawing.Point(0, 0);
            this.PlayingTable.Name = "PlayingTable";
            this.PlayingTable.RowCount = 2;
            this.PlayingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlayingTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlayingTable.Size = new System.Drawing.Size(385, 456);
            this.PlayingTable.TabIndex = 0;
            // 
            // PlayerTable
            // 
            this.PlayerTable.Controls.Add(this.label2);
            this.PlayerTable.Controls.Add(this.PlayerValue);
            this.PlayerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerTable.Location = new System.Drawing.Point(3, 231);
            this.PlayerTable.Name = "PlayerTable";
            this.PlayerTable.Size = new System.Drawing.Size(379, 222);
            this.PlayerTable.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your Hand";
            // 
            // PlayerValue
            // 
            this.PlayerValue.AutoEllipsis = true;
            this.PlayerValue.AutoSize = true;
            this.PlayerValue.Location = new System.Drawing.Point(21, 41);
            this.PlayerValue.Name = "PlayerValue";
            this.PlayerValue.Size = new System.Drawing.Size(0, 13);
            this.PlayerValue.TabIndex = 0;
            // 
            // DealerTable
            // 
            this.DealerTable.Controls.Add(this.Label_Pot);
            this.DealerTable.Controls.Add(this.label1);
            this.DealerTable.Controls.Add(this.DealerValue);
            this.DealerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DealerTable.Location = new System.Drawing.Point(3, 3);
            this.DealerTable.Name = "DealerTable";
            this.DealerTable.Size = new System.Drawing.Size(379, 222);
            this.DealerTable.TabIndex = 1;
            // 
            // Label_Pot
            // 
            this.Label_Pot.AutoSize = true;
            this.Label_Pot.Location = new System.Drawing.Point(158, 192);
            this.Label_Pot.Name = "Label_Pot";
            this.Label_Pot.Size = new System.Drawing.Size(26, 13);
            this.Label_Pot.TabIndex = 3;
            this.Label_Pot.Text = "Pot:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dealer\'s Hand";
            // 
            // DealerValue
            // 
            this.DealerValue.AutoSize = true;
            this.DealerValue.Location = new System.Drawing.Point(24, 64);
            this.DealerValue.Name = "DealerValue";
            this.DealerValue.Size = new System.Drawing.Size(0, 13);
            this.DealerValue.TabIndex = 1;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.Btn_Double);
            this.ButtonPanel.Controls.Add(this.Btn_Split);
            this.ButtonPanel.Controls.Add(this.Btn_Stand);
            this.ButtonPanel.Controls.Add(this.Btn_Play);
            this.ButtonPanel.Controls.Add(this.Btn_Hit);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonPanel.Location = new System.Drawing.Point(577, 0);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(194, 456);
            this.ButtonPanel.TabIndex = 1;
            // 
            // Btn_Double
            // 
            this.Btn_Double.Location = new System.Drawing.Point(48, 289);
            this.Btn_Double.Name = "Btn_Double";
            this.Btn_Double.Size = new System.Drawing.Size(95, 33);
            this.Btn_Double.TabIndex = 4;
            this.Btn_Double.Text = "Double";
            this.Btn_Double.UseVisualStyleBackColor = true;
            this.Btn_Double.Click += new System.EventHandler(this.Btn_Double_Click);
            // 
            // Btn_Split
            // 
            this.Btn_Split.Location = new System.Drawing.Point(48, 228);
            this.Btn_Split.Name = "Btn_Split";
            this.Btn_Split.Size = new System.Drawing.Size(95, 33);
            this.Btn_Split.TabIndex = 3;
            this.Btn_Split.Text = "Split";
            this.Btn_Split.UseVisualStyleBackColor = true;
            this.Btn_Split.Click += new System.EventHandler(this.Btn_Split_Click);
            // 
            // Btn_Stand
            // 
            this.Btn_Stand.Location = new System.Drawing.Point(48, 411);
            this.Btn_Stand.Name = "Btn_Stand";
            this.Btn_Stand.Size = new System.Drawing.Size(95, 33);
            this.Btn_Stand.TabIndex = 2;
            this.Btn_Stand.Text = "Stand";
            this.Btn_Stand.UseVisualStyleBackColor = true;
            this.Btn_Stand.Click += new System.EventHandler(this.Btn_Stand_Click);
            // 
            // Btn_Play
            // 
            this.Btn_Play.Location = new System.Drawing.Point(48, 67);
            this.Btn_Play.Name = "Btn_Play";
            this.Btn_Play.Size = new System.Drawing.Size(95, 33);
            this.Btn_Play.TabIndex = 1;
            this.Btn_Play.Text = "Play";
            this.Btn_Play.UseVisualStyleBackColor = true;
            this.Btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // Btn_Hit
            // 
            this.Btn_Hit.Location = new System.Drawing.Point(48, 350);
            this.Btn_Hit.Name = "Btn_Hit";
            this.Btn_Hit.Size = new System.Drawing.Size(95, 33);
            this.Btn_Hit.TabIndex = 0;
            this.Btn_Hit.Text = "Hit";
            this.Btn_Hit.UseVisualStyleBackColor = true;
            this.Btn_Hit.Click += new System.EventHandler(this.Btn_Hit_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 450);
            this.panel1.TabIndex = 2;
            // 
            // Blackjack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(771, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Blackjack";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Blackjack_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.PlayingPanel.ResumeLayout(false);
            this.PlayingTable.ResumeLayout(false);
            this.PlayerTable.ResumeLayout(false);
            this.PlayerTable.PerformLayout();
            this.DealerTable.ResumeLayout(false);
            this.DealerTable.PerformLayout();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button Btn_Hit;
        private System.Windows.Forms.Button Btn_Play;
        private System.Windows.Forms.Panel PlayingPanel;
        private System.Windows.Forms.TableLayoutPanel PlayingTable;
        private System.Windows.Forms.Panel PlayerTable;
        private System.Windows.Forms.Panel DealerTable;
        private System.Windows.Forms.Label PlayerValue;
        private System.Windows.Forms.Button Btn_Stand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DealerValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label_Pot;
        private System.Windows.Forms.Button Btn_Split;
        private System.Windows.Forms.Button Btn_Double;
    }
}

