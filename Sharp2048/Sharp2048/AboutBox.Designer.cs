namespace Sharp2048
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            labelProductName = new System.Windows.Forms.Label();
            labelVersion = new System.Windows.Forms.Label();
            labelBuild = new System.Windows.Forms.Label();
            labelCompanyName = new System.Windows.Forms.Label();
            textBoxDescription = new System.Windows.Forms.TextBox();
            OKButton = new System.Windows.Forms.Button();
            MainMenu = new System.Windows.Forms.MenuStrip();
            SuspendLayout();
            // 
            // labelProductName
            // 
            labelProductName.Location = new System.Drawing.Point(7, 10);
            labelProductName.Name = "labelProductName";
            labelProductName.Size = new System.Drawing.Size(143, 20);
            labelProductName.TabIndex = 16;
            labelProductName.Text = "Имя программы";
            // 
            // labelVersion
            // 
            labelVersion.Location = new System.Drawing.Point(7, 32);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(143, 20);
            labelVersion.TabIndex = 15;
            labelVersion.Text = "Версия";
            // 
            // labelBuild
            // 
            labelBuild.Location = new System.Drawing.Point(7, 55);
            labelBuild.Name = "labelBuild";
            labelBuild.Size = new System.Drawing.Size(143, 20);
            labelBuild.TabIndex = 14;
            labelBuild.Text = "Билд";
            // 
            // labelCompanyName
            // 
            labelCompanyName.Location = new System.Drawing.Point(7, 77);
            labelCompanyName.Name = "labelCompanyName";
            labelCompanyName.Size = new System.Drawing.Size(143, 20);
            labelCompanyName.TabIndex = 13;
            labelCompanyName.Text = "Имя компании";
            // 
            // textBoxDescription
            // 
            textBoxDescription.AcceptsReturn = true;
            textBoxDescription.BackColor = System.Drawing.Color.White;
            textBoxDescription.Location = new System.Drawing.Point(7, 100);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.ReadOnly = true;
            textBoxDescription.Size = new System.Drawing.Size(210, 133);
            textBoxDescription.TabIndex = 7;
            // 
            // OKButton
            // 
            OKButton.BackColor = System.Drawing.Color.White;
            OKButton.Location = new System.Drawing.Point(78, 239);
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
            // AboutBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(187, 173, 160);
            ClientSize = new System.Drawing.Size(224, 281);
            Controls.Add(OKButton);
            Controls.Add(textBoxDescription);
            Controls.Add(labelCompanyName);
            Controls.Add(labelBuild);
            Controls.Add(labelVersion);
            Controls.Add(labelProductName);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "AboutBox";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.MenuStrip MainMenu;
    }
}