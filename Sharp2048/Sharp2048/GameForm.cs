using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Sharp2048
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();

            IOHelper.ReadSettings();

            NewGame();
        }

        public void NewGame()
        {
            Init(out Parameters.GameMatrix, Parameters.FieldSize);

            StartGame();

            DrawGame(Parameters.GameMatrix);
        }

        public void StartGame()
        {
            Random RandomX = new Random();
            Random RandomY = new Random();
            int x = RandomX.Next(Parameters.FieldSize);
            int y = RandomY.Next(Parameters.FieldSize);

            Parameters.GameMatrix[x, y] = 2;

            AddNumber(2);
        }

        public bool CheckCollision(int x, int y)
        {
            return Parameters.GameMatrix[x, y] != 0;
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

        public void AddNumber(int Number)
        {
            Random RandomInit = new Random();
            int x;
            int y;

            do
            {
                Random RandomX = new Random(RandomInit.Next());
                Random RandomY = new Random(RandomInit.Next());
                x = RandomX.Next(Parameters.FieldSize);
                y = RandomY.Next(Parameters.FieldSize);
            }
            while (CheckCollision(x, y));

            Parameters.GameMatrix[x, y] = Number;
        }

        public void Init(out int[,] GameMatrix, int n)
        {
            GameMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GameMatrix[i, j] = 0;
                }
            }

            Parameters.GameField = new Bitmap(GameFieldBox.Width, GameFieldBox.Height);
            Parameters.Score = 0;

            UpdateScore(0);
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
                                    Parameters.GameMatrix[i + k, j] = Parameters.GameMatrix[i + k - 1, j] * 2;
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

        public void DrawGame(int[,] GameMatrix)
        {
            GameFieldBox.Image = Parameters.GameField;
            int n = GameMatrix.GetLength(0);

            using (Graphics Paint = Graphics.FromImage(GameFieldBox.Image))
            {
                Paint.Clear(Color.FromArgb(187, 173, 160));
                this.BackColor = Color.FromArgb(187, 173, 160);

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();

                    for (int j = 0; j < n; j++)
                    {
                        Drawing.SetColor(GameMatrix[i, j]);

                        Rectangle NumberRect = new Rectangle
                        (
                            i * GameFieldBox.Width / Parameters.FieldSize + 3,
                            j * GameFieldBox.Height / Parameters.FieldSize + 3,
                            GameFieldBox.Width / Parameters.FieldSize - 6,
                            GameFieldBox.Height / Parameters.FieldSize - 6
                        );

                        DrawNumber(Paint, GameMatrix[i, j], NumberRect);
                    }
                }
            }
        }

        public void DrawNumber(Graphics Paint, int Number, Rectangle NumberRect)
        {
            RectangleF TextLayout = new RectangleF(NumberRect.X, NumberRect.Y, NumberRect.Width, NumberRect.Height);
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            Paint.SmoothingMode = SmoothingMode.AntiAlias;

            if (Parameters.Pallete == Parameters.PalleteType.Rounded)
            {
                using (GraphicsPath path = Drawing.RoundedRect(NumberRect, 6))
                {
                    Paint.FillPath(Parameters.NumberBrush, path);
                }
            }
            else
            {
                Paint.FillRectangle(Parameters.NumberBrush, NumberRect);
            }

            if (Number > 0)
            {
                Paint.DrawString(Number.ToString(), Parameters.TextFont, Parameters.TextBrush, TextLayout, sf);
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
                    if (Parameters.HighScore < Parameters.Score) Parameters.HighScore = Parameters.Score;
                    NewGame();
                }
            }

            DrawGame(Parameters.GameMatrix);
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
            Init(out Parameters.GameMatrix, 4);
            IOHelper.ReadGame(ref Parameters.GameMatrix, ref Parameters.Score, "Save.dat");

            DrawGame(Parameters.GameMatrix);
            UpdateScore(0);
        }
    }
}