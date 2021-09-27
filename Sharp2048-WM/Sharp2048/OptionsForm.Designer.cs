namespace Sharp2048
{
    partial class OptionsForm
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
            this.OkMenuItem = new System.Windows.Forms.MenuItem();
            this.CancelMenuItem = new System.Windows.Forms.MenuItem();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.FieldSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.RoundedButton = new System.Windows.Forms.RadioButton();
            this.SquareButton = new System.Windows.Forms.RadioButton();
            this.ShapeLabel = new System.Windows.Forms.Label();
            this.OptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.Add(this.OkMenuItem);
            this.MainMenu.MenuItems.Add(this.CancelMenuItem);
            // 
            // OkMenuItem
            // 
            this.OkMenuItem.Text = "OK";
            this.OkMenuItem.Click += new System.EventHandler(this.OkMenuItem_Click);
            // 
            // CancelMenuItem
            // 
            this.CancelMenuItem.Text = "Cancel";
            this.CancelMenuItem.Click += new System.EventHandler(this.CancelMenuItem_Click);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.AutoScroll = true;
            this.OptionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.OptionsPanel.Controls.Add(this.FieldSizeUpDown);
            this.OptionsPanel.Controls.Add(this.SizeLabel);
            this.OptionsPanel.Controls.Add(this.RoundedButton);
            this.OptionsPanel.Controls.Add(this.SquareButton);
            this.OptionsPanel.Controls.Add(this.ShapeLabel);
            this.OptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsPanel.Location = new System.Drawing.Point(0, 0);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(240, 268);
            // 
            // FieldSizeUpDown
            // 
            this.FieldSizeUpDown.Location = new System.Drawing.Point(3, 116);
            this.FieldSizeUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.FieldSizeUpDown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.FieldSizeUpDown.Name = "FieldSizeUpDown";
            this.FieldSizeUpDown.Size = new System.Drawing.Size(61, 22);
            this.FieldSizeUpDown.TabIndex = 4;
            this.FieldSizeUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // SizeLabel
            // 
            this.SizeLabel.Location = new System.Drawing.Point(3, 93);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(100, 20);
            this.SizeLabel.Text = "Field Size (beta):";
            // 
            // RoundedButton
            // 
            this.RoundedButton.Location = new System.Drawing.Point(3, 60);
            this.RoundedButton.Name = "RoundedButton";
            this.RoundedButton.Size = new System.Drawing.Size(100, 20);
            this.RoundedButton.TabIndex = 2;
            this.RoundedButton.Text = "Rounded";
            // 
            // SquareButton
            // 
            this.SquareButton.Location = new System.Drawing.Point(3, 34);
            this.SquareButton.Name = "SquareButton";
            this.SquareButton.Size = new System.Drawing.Size(100, 20);
            this.SquareButton.TabIndex = 1;
            this.SquareButton.Text = "Square";
            // 
            // ShapeLabel
            // 
            this.ShapeLabel.Location = new System.Drawing.Point(3, 11);
            this.ShapeLabel.Name = "ShapeLabel";
            this.ShapeLabel.Size = new System.Drawing.Size(100, 20);
            this.ShapeLabel.Text = "Palletes Shape:";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(173)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.OptionsPanel);
            this.Menu = this.MainMenu;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OptionsForm_Closing);
            this.OptionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem OkMenuItem;
        private System.Windows.Forms.MenuItem CancelMenuItem;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.RadioButton RoundedButton;
        private System.Windows.Forms.RadioButton SquareButton;
        private System.Windows.Forms.Label ShapeLabel;
        private System.Windows.Forms.NumericUpDown FieldSizeUpDown;
        private System.Windows.Forms.Label SizeLabel;
    }
}