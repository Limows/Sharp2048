namespace Sharp2048
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            OptionsPanel = new System.Windows.Forms.Panel();
            CancelButton = new System.Windows.Forms.Button();
            OkButton = new System.Windows.Forms.Button();
            FieldSizeUpDown = new System.Windows.Forms.NumericUpDown();
            SizeLabel = new System.Windows.Forms.Label();
            RoundedButton = new System.Windows.Forms.RadioButton();
            SquareButton = new System.Windows.Forms.RadioButton();
            ShapeLabel = new System.Windows.Forms.Label();
            OptionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FieldSizeUpDown).BeginInit();
            SuspendLayout();
            // 
            // OptionsPanel
            // 
            OptionsPanel.AutoScroll = true;
            OptionsPanel.BackColor = System.Drawing.Color.FromArgb(187, 173, 160);
            OptionsPanel.Controls.Add(CancelButton);
            OptionsPanel.Controls.Add(OkButton);
            OptionsPanel.Controls.Add(FieldSizeUpDown);
            OptionsPanel.Controls.Add(SizeLabel);
            OptionsPanel.Controls.Add(RoundedButton);
            OptionsPanel.Controls.Add(SquareButton);
            OptionsPanel.Controls.Add(ShapeLabel);
            OptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            OptionsPanel.Location = new System.Drawing.Point(0, 0);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new System.Drawing.Size(240, 268);
            OptionsPanel.TabIndex = 0;
            // 
            // CancelButton
            // 
            CancelButton.Location = new System.Drawing.Point(153, 233);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new System.Drawing.Size(75, 23);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OkButton
            // 
            OkButton.Location = new System.Drawing.Point(72, 233);
            OkButton.Name = "OkButton";
            OkButton.Size = new System.Drawing.Size(75, 23);
            OkButton.TabIndex = 7;
            OkButton.Text = "OK";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // FieldSizeUpDown
            // 
            FieldSizeUpDown.Location = new System.Drawing.Point(3, 116);
            FieldSizeUpDown.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            FieldSizeUpDown.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            FieldSizeUpDown.Name = "FieldSizeUpDown";
            FieldSizeUpDown.Size = new System.Drawing.Size(61, 23);
            FieldSizeUpDown.TabIndex = 4;
            FieldSizeUpDown.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // SizeLabel
            // 
            SizeLabel.Location = new System.Drawing.Point(3, 93);
            SizeLabel.Name = "SizeLabel";
            SizeLabel.Size = new System.Drawing.Size(100, 20);
            SizeLabel.TabIndex = 5;
            SizeLabel.Text = "Field Size (beta):";
            // 
            // RoundedButton
            // 
            RoundedButton.Location = new System.Drawing.Point(3, 60);
            RoundedButton.Name = "RoundedButton";
            RoundedButton.Size = new System.Drawing.Size(100, 20);
            RoundedButton.TabIndex = 2;
            RoundedButton.Text = "Rounded";
            // 
            // SquareButton
            // 
            SquareButton.Location = new System.Drawing.Point(3, 34);
            SquareButton.Name = "SquareButton";
            SquareButton.Size = new System.Drawing.Size(100, 20);
            SquareButton.TabIndex = 1;
            SquareButton.Text = "Square";
            // 
            // ShapeLabel
            // 
            ShapeLabel.Location = new System.Drawing.Point(3, 11);
            ShapeLabel.Name = "ShapeLabel";
            ShapeLabel.Size = new System.Drawing.Size(100, 20);
            ShapeLabel.TabIndex = 6;
            ShapeLabel.Text = "Palletes Shape:";
            // 
            // OptionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(187, 173, 160);
            ClientSize = new System.Drawing.Size(240, 268);
            Controls.Add(OptionsPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "OptionsForm";
            Text = "Options";
            Closing += OptionsForm_Closing;
            Load += OptionsForm_Load;
            OptionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)FieldSizeUpDown).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.RadioButton RoundedButton;
        private System.Windows.Forms.RadioButton SquareButton;
        private System.Windows.Forms.Label ShapeLabel;
        private System.Windows.Forms.NumericUpDown FieldSizeUpDown;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
    }
}