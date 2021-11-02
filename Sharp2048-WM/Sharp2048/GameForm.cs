using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
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

            //IOHelper.ReadSettings();

            try
            {
                LoadGame();
            }
            catch
            {
                NewGame();
            }
        }

        public void NewGame()
        {
            GameLogic.GameLogic.Init(out Parameters.GameMatrix, out Parameters.Score, Parameters.FieldSize);

            GameLogic.GameLogic.StartGame(ref Parameters.GameMatrix);

            UpdateScreen();
        }

        public void LoadGame()
        {
            GameLogic.GameLogic.Init(out Parameters.GameMatrix, out Parameters.Score, Parameters.FieldSize);
            IOHelper.ReadGame(ref Parameters.GameMatrix, ref Parameters.Score, Parameters.SavePath);

            ScoreBar.Text = "Score: " + Parameters.Score;

            UpdateScreen();
        }

        public void UpdateScreen()
        {
            GameFieldBox.Image = Parameters.GameField;

            using (Graphics Paint = Graphics.FromImage(GameFieldBox.Image))
            {
                Drawing.DrawGame(Paint, ref Parameters.GameMatrix, new Rectangle(0, 0, GameFieldBox.Width, GameFieldBox.Height));
            }
        }

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            bool IsMove = false;

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Left:
                    IsMove = GameLogic.GameLogic.SlideLeft(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
                case System.Windows.Forms.Keys.Right:
                    IsMove = GameLogic.GameLogic.SlideRight(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
                case System.Windows.Forms.Keys.Down:
                    IsMove = GameLogic.GameLogic.SlideDown(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
                case System.Windows.Forms.Keys.Up:
                    IsMove = GameLogic.GameLogic.SlideUp(ref Parameters.GameMatrix, ref Parameters.Score);
                    break;
            }

            ScoreBar.Text = "Score: " + Parameters.Score;

            if (IsMove)
            {
                GameLogic.GameLogic.AddNumber(2, ref Parameters.GameMatrix);
            }

            switch (GameLogic.GameLogic.CheckEndGame(ref Parameters.GameMatrix))
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

        private void NewGameMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            IOHelper.WriteGame(Parameters.GameMatrix, Parameters.Score, Parameters.SavePath);
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadGame();
            }
            catch
            {
                MessageBox.Show("No save file :(");
            }
        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            TouchMove_Start(e);
        }

        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            TouchMove_Stop(e);
        }

        private void GameFieldBox_MouseDown(object sender, MouseEventArgs e)
        {
            TouchMove_Start(e);
        }

        private void GameFieldBox_MouseUp(object sender, MouseEventArgs e)
        {
            TouchMove_Stop(e);
        }

        private void TouchMove_Start(MouseEventArgs e)
        {
            Parameters.StartX = e.X;
            Parameters.StartY = e.Y;
        }

        private void TouchMove_Stop(MouseEventArgs e)
        {
            int StopX = e.X;
            int StopY = e.Y;
            bool IsMove = false;

            if (Math.Abs(Parameters.StartX - StopX) > 50 || Math.Abs(Parameters.StartY - StopY) > 50)
            {
                if (Math.Abs(Parameters.StartX - StopX) < Math.Abs(Parameters.StartY - StopY))
                {
                    if (Parameters.StartY > StopY)
                    {
                        IsMove = GameLogic.GameLogic.SlideUp(ref Parameters.GameMatrix, ref Parameters.Score);
                    }
                    else
                    {
                        IsMove = GameLogic.GameLogic.SlideDown(ref Parameters.GameMatrix, ref Parameters.Score);
                    }
                }
                else
                {
                    if (Parameters.StartX > StopX)
                    {
                        IsMove = GameLogic.GameLogic.SlideLeft(ref Parameters.GameMatrix, ref Parameters.Score);
                    }
                    else
                    {
                        IsMove = GameLogic.GameLogic.SlideRight(ref Parameters.GameMatrix, ref Parameters.Score);
                    }
                }
            }

            ScoreBar.Text = "Score: " + Parameters.Score;

            if (IsMove)
            {
                GameLogic.GameLogic.AddNumber(2, ref Parameters.GameMatrix);
            }

            switch (GameLogic.GameLogic.CheckEndGame(ref Parameters.GameMatrix))
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

        private void DonatMenuItem_Click(object sender, EventArgs e)
        {
            DonateBox Donate = new DonateBox();

            Donate.ShowDialog();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox About = new AboutBox();

            About.ShowDialog();
        }

        private void SetupMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm Options = new OptionsForm();

            Options.ShowDialog();

            NewGame();
        }

        private void GameForm_Closing(object sender, CancelEventArgs e)
        {
            IOHelper.WriteSettings();
            IOHelper.WriteGame(Parameters.GameMatrix, Parameters.Score, Parameters.SavePath);
        }
    }
}