namespace Blackjack
{
    partial class ClientControl
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
            this.Btn_Join = new System.Windows.Forms.Button();
            this.IPAddress = new System.Windows.Forms.TextBox();
            this.ChatDisplay = new System.Windows.Forms.ListBox();
            this.Btn_SendChat = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Table1 = new System.Windows.Forms.Label();
            this.Table2 = new System.Windows.Forms.Label();
            this.Table3 = new System.Windows.Forms.Label();
            this.Btn_Table1 = new System.Windows.Forms.Button();
            this.Btn_Table2 = new System.Windows.Forms.Button();
            this.Btn_Table3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Join
            // 
            this.Btn_Join.Location = new System.Drawing.Point(168, 197);
            this.Btn_Join.Name = "Btn_Join";
            this.Btn_Join.Size = new System.Drawing.Size(75, 23);
            this.Btn_Join.TabIndex = 0;
            this.Btn_Join.Text = "Join Sever";
            this.Btn_Join.UseVisualStyleBackColor = true;
            this.Btn_Join.Click += new System.EventHandler(this.Btn_Join_Click);
            // 
            // IPAddress
            // 
            this.IPAddress.Location = new System.Drawing.Point(121, 171);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(173, 20);
            this.IPAddress.TabIndex = 1;
            this.IPAddress.Text = "127.0.0.1";
            // 
            // ChatDisplay
            // 
            this.ChatDisplay.FormattingEnabled = true;
            this.ChatDisplay.Location = new System.Drawing.Point(12, 35);
            this.ChatDisplay.Name = "ChatDisplay";
            this.ChatDisplay.Size = new System.Drawing.Size(173, 160);
            this.ChatDisplay.TabIndex = 2;
            // 
            // Btn_SendChat
            // 
            this.Btn_SendChat.Location = new System.Drawing.Point(58, 260);
            this.Btn_SendChat.Name = "Btn_SendChat";
            this.Btn_SendChat.Size = new System.Drawing.Size(75, 23);
            this.Btn_SendChat.TabIndex = 4;
            this.Btn_SendChat.Text = "Send";
            this.Btn_SendChat.UseVisualStyleBackColor = true;
            this.Btn_SendChat.Click += new System.EventHandler(this.Btn_SendChat_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(12, 220);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(173, 20);
            this.ChatBox.TabIndex = 5;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(121, 145);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(173, 20);
            this.UserName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP Address";
            // 
            // Table1
            // 
            this.Table1.AutoSize = true;
            this.Table1.Location = new System.Drawing.Point(237, 53);
            this.Table1.Name = "Table1";
            this.Table1.Size = new System.Drawing.Size(43, 13);
            this.Table1.TabIndex = 6;
            this.Table1.Text = "Table 1";
            // 
            // Table2
            // 
            this.Table2.AutoSize = true;
            this.Table2.Location = new System.Drawing.Point(237, 100);
            this.Table2.Name = "Table2";
            this.Table2.Size = new System.Drawing.Size(43, 13);
            this.Table2.TabIndex = 7;
            this.Table2.Text = "Table 2";
            // 
            // Table3
            // 
            this.Table3.AutoSize = true;
            this.Table3.Location = new System.Drawing.Point(237, 144);
            this.Table3.Name = "Table3";
            this.Table3.Size = new System.Drawing.Size(43, 13);
            this.Table3.TabIndex = 8;
            this.Table3.Text = "Table 3";
            // 
            // Btn_Table1
            // 
            this.Btn_Table1.Location = new System.Drawing.Point(347, 48);
            this.Btn_Table1.Name = "Btn_Table1";
            this.Btn_Table1.Size = new System.Drawing.Size(75, 23);
            this.Btn_Table1.TabIndex = 9;
            this.Btn_Table1.Text = "Join";
            this.Btn_Table1.UseVisualStyleBackColor = true;
            this.Btn_Table1.Click += new System.EventHandler(this.Btn_Table1_Click);
            // 
            // Btn_Table2
            // 
            this.Btn_Table2.Location = new System.Drawing.Point(347, 95);
            this.Btn_Table2.Name = "Btn_Table2";
            this.Btn_Table2.Size = new System.Drawing.Size(75, 23);
            this.Btn_Table2.TabIndex = 10;
            this.Btn_Table2.Text = "Join";
            this.Btn_Table2.UseVisualStyleBackColor = true;
            this.Btn_Table2.Click += new System.EventHandler(this.Btn_Table2_Click);
            // 
            // Btn_Table3
            // 
            this.Btn_Table3.Location = new System.Drawing.Point(347, 139);
            this.Btn_Table3.Name = "Btn_Table3";
            this.Btn_Table3.Size = new System.Drawing.Size(75, 23);
            this.Btn_Table3.TabIndex = 11;
            this.Btn_Table3.Text = "Join";
            this.Btn_Table3.UseVisualStyleBackColor = true;
            this.Btn_Table3.Click += new System.EventHandler(this.Btn_Table3_Click);
            // 
            // ClientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 291);
            this.Controls.Add(this.Btn_Table3);
            this.Controls.Add(this.Btn_Table2);
            this.Controls.Add(this.Btn_Table1);
            this.Controls.Add(this.Table3);
            this.Controls.Add(this.Table2);
            this.Controls.Add(this.Table1);
            this.Controls.Add(this.ChatDisplay);
            this.Controls.Add(this.Btn_SendChat);
            this.Controls.Add(this.ChatBox);
            this.Name = "ClientControl";
            this.Text = "ClientControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Join;
        private System.Windows.Forms.TextBox IPAddress;
        private System.Windows.Forms.ListBox ChatDisplay;
        private System.Windows.Forms.Button Btn_SendChat;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Table1;
        private System.Windows.Forms.Label Table2;
        private System.Windows.Forms.Label Table3;
        private System.Windows.Forms.Button Btn_Table1;
        private System.Windows.Forms.Button Btn_Table2;
        private System.Windows.Forms.Button Btn_Table3;
    }
}