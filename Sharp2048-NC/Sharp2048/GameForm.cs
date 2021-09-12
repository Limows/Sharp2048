using System;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace Sharp2048
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();

            Parameters.GameField = new Bitmap(GameFieldBox.Width, GameFieldBox.Height);
            this.BackColor = Color.FromArgb(187, 173, 160);

            IOHelper.ReadSettings();

            NewGame();
        }

        public void NewGame()
        {
            GameLogic.GameLogic.Init(out Parameters.GameMatrix, out Parameters.Score, Parameters.FieldSize);

            GameLogic.GameLogic.StartGame(ref Parameters.GameMatrix);

            UpdateScreen();
        }
     
        public void UpdateScreen()
        {
            GameFieldBox.Image = Parameters.GameField;

            using (Graphics Paint = Graphics.FromImage(GameFieldBox.Image))
            {
                Drawing.DrawGame(Paint, ref Parameters.GameMatrix, new Rectangle(0,0, GameFieldBox.Width, GameFieldBox.Height));
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool IsMove = false;

            switch (e.KeyCode.ToString())
            {
                case "Left":
                    IsMove = GameLogic.GameLogic.SlideLeft(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
                case "Right":
                    IsMove = GameLogic.GameLogic.SlideRight(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
                case "Down":
                    IsMove = GameLogic.GameLogic.SlideDown(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
                case "Up":
                    IsMove = GameLogic.GameLogic.SlideUp(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
            }

            ScoreLabel.Text = "Score: " + Parameters.Score;

            if (IsMove)
            {
                GameLogic.GameLogic.AddNumber(2, ref Parameters.GameMatrix);
            }
            
            switch(GameLogic.GameLogic.CheckEndGame(ref Parameters.GameMatrix))
            {
                case 1:
                    MessageBox.Show("You Win!");
                    break;
                case -1:
                    MessageBox.Show("Game Over!");
                    if (Parameters.HighScore < Parameters.Score) Parameters.HighScore = Parameters.Score;
                    NewGame();
                    break;
            }

            UpdateScreen();
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IOHelper.WriteGame(Parameters.GameMatrix, Parameters.Score, "Save.dat");
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameLogic.GameLogic.Init(out Parameters.GameMatrix, out Parameters.Score, Parameters.FieldSize);
            IOHelper.ReadGame(ref Parameters.GameMatrix, ref Parameters.Score, "Save.dat");

            ScoreLabel.Text = "Score: " + Parameters.Score;

            UpdateScreen();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();

            About.ShowDialog();
        }

        private void DonatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DonatBox Donat = new DonatBox();

            Donat.ShowDialog();
        }
    }
}