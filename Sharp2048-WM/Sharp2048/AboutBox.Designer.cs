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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.OKMenuItem = new System.Windows.Forms.MenuItem();
            this.AboutPanel = new System.Windows.Forms.Panel();
            this.AboutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.Location = new System.Drawing.Point(3, 9);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(143, 20);
            this.labelProductName.Text = "Имя программы";
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(3, 29);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(143, 20);
            this.labelVersion.Text = "Версия";
            // 
            // labelBuild
            // 
            this.labelBuild.Location = new System.Drawing.Point(3, 49);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(143, 20);
            this.labelBuild.Text = "Билд";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Location = new System.Drawing.Point(3, 69);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(143, 20);
            this.labelCompanyName.Text = "Имя компании";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AcceptsReturn = true;
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(0, 94);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(240, 174);
            this.textBoxDescription.TabIndex = 7;
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.OKMenuItem);
            // 
            // OKMenuItem
            // 
            this.OKMenuItem.Text = "OK";
            this.OKMenuItem.Click += new System.EventHandler(this.OKMenuItem_Click);
            // 
            // AboutPanel
            // 
            this.AboutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.AboutPanel.Controls.Add(this.labelProductName);
            this.AboutPanel.Controls.Add(this.labelCompanyName);
            this.AboutPanel.Controls.Add(this.labelVersion);
            this.AboutPanel.Controls.Add(this.labelBuild);
            this.AboutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AboutPanel.Location = new System.Drawing.Point(0, 0);
            this.AboutPanel.Name = "AboutPanel";
            this.AboutPanel.Size = new System.Drawing.Size(240, 94);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.AboutPanel);
            this.Menu = this.MainMenu;
            this.Name = "AboutBox";
            this.Text = "О программе";
            this.AboutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.MainMenu MainMenu;
        private System.Windows.Forms.MenuItem OKMenuItem;
        private System.Windows.Forms.Panel AboutPanel;
    }
}