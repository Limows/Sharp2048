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
            this.components = new System.ComponentModel.Container();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.Location = new System.Drawing.Point(7, 10);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(143, 20);
            this.labelProductName.TabIndex = 16;
            this.labelProductName.Text = "Имя программы";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(7, 32);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(143, 20);
            this.labelVersion.TabIndex = 15;
            this.labelVersion.Text = "Версия";
            // 
            // labelBuild
            // 
            this.labelBuild.Location = new System.Drawing.Point(7, 55);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(143, 20);
            this.labelBuild.TabIndex = 14;
            this.labelBuild.Text = "Билд";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Location = new System.Drawing.Point(7, 77);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(143, 20);
            this.labelCompanyName.TabIndex = 13;
            this.labelCompanyName.Text = "Имя компании";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AcceptsReturn = true;
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.Location = new System.Drawing.Point(7, 100);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(226, 133);
            this.textBoxDescription.TabIndex = 7;
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(87, 239);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(72, 20);
            this.OKButton.TabIndex = 12;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelBuild);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Menu = this.MainMenu;
            this.Name = "AboutBox";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.MainMenu MainMenu;
    }
}