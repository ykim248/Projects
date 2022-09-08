namespace Blackjack
{
    public partial class Card
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card));
            this.SuitImage = new System.Windows.Forms.PictureBox();
            this.TopLeftLabel = new System.Windows.Forms.Label();
            this.BottomRightLabel = new System.Windows.Forms.Label();
            this.SuitImages = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SuitImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SuitImage
            // 
            this.SuitImage.Image = global::Blackjack.Properties.Resources.Spades;
            this.SuitImage.Location = new System.Drawing.Point(16, 28);
            this.SuitImage.Name = "SuitImage";
            this.SuitImage.Size = new System.Drawing.Size(32, 32);
            this.SuitImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SuitImage.TabIndex = 0;
            this.SuitImage.TabStop = false;
            // 
            // TopLeftLabel
            // 
            this.TopLeftLabel.AutoSize = true;
            this.TopLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.TopLeftLabel.Location = new System.Drawing.Point(-3, -1);
            this.TopLeftLabel.Name = "TopLeftLabel";
            this.TopLeftLabel.Size = new System.Drawing.Size(26, 25);
            this.TopLeftLabel.TabIndex = 1;
            this.TopLeftLabel.Text = "K";
            // 
            // BottomRightLabel
            // 
            this.BottomRightLabel.AutoSize = true;
            this.BottomRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.BottomRightLabel.Location = new System.Drawing.Point(35, 63);
            this.BottomRightLabel.Name = "BottomRightLabel";
            this.BottomRightLabel.Size = new System.Drawing.Size(26, 25);
            this.BottomRightLabel.TabIndex = 2;
            this.BottomRightLabel.Text = "K";
            // 
            // SuitImages
            // 
            this.SuitImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SuitImages.ImageStream")));
            this.SuitImages.TransparentColor = System.Drawing.Color.Transparent;
            this.SuitImages.Images.SetKeyName(0, "Clubs.png");
            this.SuitImages.Images.SetKeyName(1, "Diamonds.png");
            this.SuitImages.Images.SetKeyName(2, "Hearts.png");
            this.SuitImages.Images.SetKeyName(3, "Spades.png");
            this.SuitImages.Images.SetKeyName(4, "CardButt.jpg");
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.SuitImage);
            this.Controls.Add(this.TopLeftLabel);
            this.Controls.Add(this.BottomRightLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Card";
            this.Size = new System.Drawing.Size(63, 87);
            this.Resize += new System.EventHandler(this.Card_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.SuitImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SuitImage = new System.Windows.Forms.PictureBox();
        private System.Windows.Forms.Label TopLeftLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.Label BottomRightLabel = new System.Windows.Forms.Label();
        private System.Windows.Forms.ImageList SuitImages;
    }
}
