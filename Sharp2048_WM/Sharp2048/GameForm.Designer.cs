namespace Sharp2048
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu MainMenu;

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
            this.MainMenu = new System.Windows.Forms.MainMenu();
            this.GameMenuItem = new System.Windows.Forms.MenuItem();
            this.NewGameMenuItem = new System.Windows.Forms.MenuItem();
            this.SetupMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.SaveMenuItem = new System.Windows.Forms.MenuItem();
            this.LoadMenuItem = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.QuitMenuItem = new System.Windows.Forms.MenuItem();
            this.HelpMenuItem = new System.Windows.Forms.MenuItem();
            this.AboutMenuItem = new System.Windows.Forms.MenuItem();
            this.ScoreBar = new System.Windows.Forms.StatusBar();
            this.GameFieldBox = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.GameMenuItem);
            this.MainMenu.MenuItems.Add(this.HelpMenuItem);
            // 
            // GameMenuItem
            // 
            this.GameMenuItem.MenuItems.Add(this.NewGameMenuItem);
            this.GameMenuItem.MenuItems.Add(this.SetupMenuItem);
            this.GameMenuItem.MenuItems.Add(this.menuItem10);
            this.GameMenuItem.MenuItems.Add(this.SaveMenuItem);
            this.GameMenuItem.MenuItems.Add(this.LoadMenuItem);
            this.GameMenuItem.MenuItems.Add(this.menuItem9);
            this.GameMenuItem.MenuItems.Add(this.QuitMenuItem);
            this.GameMenuItem.Text = "Game";
            // 
            // NewGameMenuItem
            // 
            this.NewGameMenuItem.Text = "New Game";
            this.NewGameMenuItem.Click += new System.EventHandler(this.NewGameMenuItem_Click);
            // 
            // SetupMenuItem
            // 
            this.SetupMenuItem.Text = "Setup";
            // 
            // menuItem10
            // 
            this.menuItem10.Text = "-";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Text = "Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // LoadMenuItem
            // 
            this.LoadMenuItem.Text = "Load";
            this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Text = "-";
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Text = "Quit";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.MenuItems.Add(this.AboutMenuItem);
            this.HelpMenuItem.Text = "Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Text = "About";
            // 
            // ScoreBar
            // 
            this.ScoreBar.Location = new System.Drawing.Point(0, 246);
            this.ScoreBar.Name = "ScoreBar";
            this.ScoreBar.Size = new System.Drawing.Size(240, 22);
            this.ScoreBar.Text = "Score: 0";
            // 
            // GameFieldBox
            // 
            this.GameFieldBox.Location = new System.Drawing.Point(19, 22);
            this.GameFieldBox.Name = "GameFieldBox";
            this.GameFieldBox.Size = new System.Drawing.Size(200, 200);
            this.GameFieldBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFieldBox_MouseDown);
            this.GameFieldBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameFieldBox_MouseUp);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.GameFieldBox);
            this.Controls.Add(this.ScoreBar);
            this.Menu = this.MainMenu;
            this.Name = "GameForm";
            this.Text = "2048";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBar ScoreBar;
        private System.Windows.Forms.MenuItem GameMenuItem;
        private System.Windows.Forms.MenuItem NewGameMenuItem;
        private System.Windows.Forms.MenuItem SetupMenuItem;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem SaveMenuItem;
        private System.Windows.Forms.MenuItem LoadMenuItem;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem QuitMenuItem;
        private System.Windows.Forms.MenuItem HelpMenuItem;
        private System.Windows.Forms.MenuItem AboutMenuItem;
        private System.Windows.Forms.PictureBox GameFieldBox;
    }
}

