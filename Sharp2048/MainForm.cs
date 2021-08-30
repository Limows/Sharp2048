using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sharp2048
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            SetupGame(4);

            NewGame();
        }

        public void SetupGame(int FieldSize)
        {
            Parameters.FieldSize = FieldSize;
        }

        public void NewGame()
        {
            Parameters.IsGame = true;

            InitMatrix(out Parameters.GameMatrix, Parameters.FieldSize);

            StartGame();

            DrawGame(Parameters.GameMatrix);
        }

        public void StartGame()
        {
            Random RandomX = new Random();
            Random RandomY = new Random();
            int x = RandomX.Next(4);
            int y = RandomY.Next(4);

            Parameters.GameMatrix[x, y] = 2;

            AddNumber(2);
        }

        public bool CheckCollision(int x, int y)
        {
            return Parameters.GameMatrix[x, y] == 0 ? false : true;
        }

        public bool CheckEndGame()
        {
            int n = Parameters.GameMatrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Parameters.GameMatrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void SetColor(int Number)
        {
            Color NumberColor;

            switch (Number)
            {
                case 0: NumberColor = Color.DarkGray; break;
                case 2: NumberColor = Color.Ivory; break;
                case 4: NumberColor = Color.Beige; break;
                case 8: NumberColor = Color.Coral; break;
                case 16: NumberColor = Color.Orange; break;
                case 32: NumberColor = Color.DarkOrange; break;
                case 64: NumberColor = Color.Red; break;
                case 128: NumberColor = Color.BlanchedAlmond; break;
                case 256: NumberColor = Color.Khaki; break;
                case 512: NumberColor = Color.Yellow; break;
                case 1024: NumberColor = Color.Gold; break;
                case 2048: NumberColor = Color.Gold; break;
                default: NumberColor = Color.Gray; break;
            }

            Parameters.NumberBrush = new SolidBrush(NumberColor);
        }

        public void AddNumber(int Number)
        {
            Random RandomInit = new Random();
            int x;
            int y;

            do
            {
                Random RandomX = new Random(RandomInit.Next());
                Random RandomY = new Random(RandomInit.Next());
                x = RandomX.Next(4);
                y = RandomY.Next(4);
            }
            while (CheckCollision(x, y));

            Parameters.GameMatrix[x, y] = Number;
        }

        public void InitMatrix(out int[,] GameMatrix, int n)
        {
            GameMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GameMatrix[i, j] = 0;
                }
            }
        }

        public void DrawGame(int[,] GameMatrix)
        {
            GameFieldBox.Image = new Bitmap(GameFieldBox.Width, GameFieldBox.Height);
            Pen FieldPen = new Pen(Color.Black, 2);
            int n = GameMatrix.GetLength(0);

            using (Graphics Paint = Graphics.FromImage(GameFieldBox.Image))
            {
                Paint.Clear(Color.Gray);

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();

                    for (int j = 0; j < n; j++)
                    {
                        SetColor(GameMatrix[i, j]);

                        Rectangle NumberRect = new Rectangle(i * GameFieldBox.Width / 4 + 3, j * GameFieldBox.Height / 4 + 3, GameFieldBox.Width / 4 - 6, GameFieldBox.Height / 4 - 6);

                        DrawNumber(Paint, GameMatrix[i, j], NumberRect);
                    }
                }
            }
        }

        public void DrawNumber(Graphics Paint, int Number, Rectangle NumberRect)
        {
            RectangleF TextLayout = new RectangleF(NumberRect.X, NumberRect.Y, NumberRect.Width, NumberRect.Height);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            Paint.FillRectangle(Parameters.NumberBrush, NumberRect);

            if (Number > 0)
            {
                Paint.DrawString(Number.ToString(), Parameters.TextFont, Parameters.TextBrush, TextLayout, sf);
            }
        }

        public void UpdateScore(int Points)
        {
            Parameters.Score += Points;

            ScoreLabel.Text = "Score: " + Parameters.Score;
        }

        public void SlideRight()
        {
            int n = Parameters.GameMatrix.GetLength(0);

            for (int j = 0; j < n; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (Parameters.GameMatrix[i, j] > 0) 
                    {

                        for (int k = 1; k < n - i; k++)
                        {
                            if (Parameters.GameMatrix[i + k, j] == 0)
                            {
                                Parameters.GameMatrix[i + k, j] = Parameters.GameMatrix[i + k - 1, j];
                                Parameters.GameMatrix[i + k - 1, j] = 0;
                                Parameters.IsMove = true;
                            }
                            else
                            {
                                if (Parameters.GameMatrix[i + k, j] == Parameters.GameMatrix[i + k - 1, j])
                                {
                                    Parameters.GameMatrix[i + k, j] = Parameters.GameMatrix[i + k - 1, j]*2;
                                    Parameters.GameMatrix[i + k - 1, j] = 0;
                                    Parameters.IsMove = true;

                                    UpdateScore(Parameters.GameMatrix[i + k, j]);

                                    if (Parameters.GameMatrix[i + k, j] == 2048)
                                    {
                                        MessageBox.Show("You Win!");
                                        NewGame();
                                    }
                                }

                                break;
                            }
                        }

                        
                    }
                }
            }
        }

        public void SlideDown()
        {
            Rotate(90);
            SlideRight();
            Rotate(270);
        }

        public void SlideUp()
        {
            Rotate(270);
            SlideRight();
            Rotate(90);
        }

        public void SlideLeft()
        {
            Rotate(180);
            SlideRight();
            Rotate(180);
        }

        public void Rotate(int Degree)
        {
            int n = Parameters.GameMatrix.GetLength(0);

            if (Degree == 360) return;

            for (; Degree >= 90; Degree -= 90)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = i; j < n - i - 1; j++)
                    {
                        int Temp = Parameters.GameMatrix[i, j];
                        Parameters.GameMatrix[i, j] = Parameters.GameMatrix[n - 1 - j, i];
                        Parameters.GameMatrix[n - 1 - j, i] = Parameters.GameMatrix[n - 1 - i, n - 1 - j];
                        Parameters.GameMatrix[n - i - 1, n - j - 1] = Parameters.GameMatrix[j, n - i - 1];
                        Parameters.GameMatrix[j, n - i - 1] = Temp;
                    }
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Parameters.IsMove = false;

            switch (e.KeyCode.ToString())
            {
                case "Left":
                    SlideLeft();
                    break;
                case "Right":
                    SlideRight();
                    break;
                case "Down":
                    SlideDown();
                    break;
                case "Up":
                    SlideUp();
                    break;
            }

            if (Parameters.IsMove)
            {
                AddNumber(2);
            }
            else
            {
                if (CheckEndGame())
                {   
                    MessageBox.Show("Game Over!");
                    NewGame();
                }
            }

            DrawGame(Parameters.GameMatrix);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}