namespace Sharp2048
{
    partial class DonateBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DonateBox));
            Label = new System.Windows.Forms.Label();
            OKButton = new System.Windows.Forms.Button();
            MainMenu = new System.Windows.Forms.MenuStrip();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Label
            // 
            Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            Label.Location = new System.Drawing.Point(12, 9);
            Label.Name = "Label";
            Label.Size = new System.Drawing.Size(204, 43);
            Label.TabIndex = 16;
            Label.Text = "Use your smartphone";
            Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OKButton
            // 
            OKButton.BackColor = System.Drawing.Color.White;
            OKButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            OKButton.Location = new System.Drawing.Point(80, 240);
            OKButton.Name = "OKButton";
            OKButton.Size = new System.Drawing.Size(72, 25);
            OKButton.TabIndex = 12;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = false;
            OKButton.Click += OKButton_Click;
            // 
            // MainMenu
            // 
            MainMenu.Location = new System.Drawing.Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new System.Drawing.Size(200, 24);
            MainMenu.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.White;
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new System.Drawing.Point(23, 55);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(178, 178);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // DonateBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(187, 173, 160);
            ClientSize = new System.Drawing.Size(224, 281);
            Controls.Add(pictureBox1);
            Controls.Add(OKButton);
            Controls.Add(Label);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "DonateBox";
            Text = "Donate";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}