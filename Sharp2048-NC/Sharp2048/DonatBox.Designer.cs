namespace Sharp2048
{
    partial class DonatBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonatBox));
            this.Label = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.QRBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.QRBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label.Location = new System.Drawing.Point(12, 9);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(216, 43);
            this.Label.TabIndex = 16;
            this.Label.Text = "Use your smartphone";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(85, 239);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(72, 20);
            this.OKButton.TabIndex = 12;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // QRBox
            // 
            this.QRBox.BackColor = System.Drawing.Color.White;
            this.QRBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("QRBox.BackgroundImage")));
            this.QRBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QRBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.QRBox.InitialImage = null;
            this.QRBox.Location = new System.Drawing.Point(31, 55);
            this.QRBox.Name = "QRBox";
            this.QRBox.Size = new System.Drawing.Size(178, 178);
            this.QRBox.TabIndex = 17;
            this.QRBox.TabStop = false;
            // 
            // DonatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.QRBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.Label);
            this.Name = "DonatBox";
            this.Text = "Donat";
            ((System.ComponentModel.ISupportInitialize)(this.QRBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.PictureBox QRBox;
    }
}