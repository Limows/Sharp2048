using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
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
                case 0: NumberColor = Color.FromArgb(204, 192, 179); break;
                case 2: NumberColor = Color.FromArgb(238, 228, 218); break;
                case 4: NumberColor = Color.FromArgb(237, 224, 200); break;
                case 8: NumberColor = Color.FromArgb(242, 177, 121); break;
                case 16: NumberColor = Color.FromArgb(245, 149, 99); break;
                case 32: NumberColor = Color.FromArgb(246, 124, 95); break;
                case 64: NumberColor = Color.FromArgb(246, 94, 59); break;
                case 128: NumberColor = Color.FromArgb(237, 207, 114); break;
                case 256: NumberColor = Color.FromArgb(237, 204, 97); break;
                case 512: NumberColor = Color.FromArgb(237, 200, 80); break;
                case 1024: NumberColor = Color.FromArgb(237, 197, 63); break;
                case 2048: NumberColor = Color.FromArgb(237, 194, 46); break;
                default: NumberColor = Color.FromArgb(204, 192, 179); break;
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

        public void DrawGame(int[,] GameMatrix)
        {
            GameFieldBox.Image = Parameters.GameField;
            Pen FieldPen = new Pen(Color.Black, 2);
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
                        SetColor(GameMatrix[i, j]);

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
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            Paint.SmoothingMode = SmoothingMode.AntiAlias;

            if (Parameters.Pallete == Parameters.PalleteType.Rounded)
            {
                //using (GraphicsPath path = Drawing.RoundedRect(NumberRect, 6))
                //{
                //    Paint.FillPath(Parameters.NumberBrush, path);
                //}
                Paint.FillRectangle(Parameters.NumberBrush, NumberRect);
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

        public void UpdateScore(int Points)
        {
            Parameters.Score += Points;

            ScoreBar.Text = "Score: " + Parameters.Score;
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

        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Parameters.IsMove = false;

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Left:
                    SlideLeft();
                    break;
                case System.Windows.Forms.Keys.Right:
                    SlideRight();
                    break;
                case System.Windows.Forms.Keys.Down:
                    SlideDown();
                    break;
                case System.Windows.Forms.Keys.Up:
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

        private void NewGameMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            IOHelper.WriteGame(Parameters.GameMatrix, Parameters.Score, "Save.dat");
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            Init(out Parameters.GameMatrix, 4);
            IOHelper.ReadGame(ref Parameters.GameMatrix, ref Parameters.Score, "Save.dat");

            DrawGame(Parameters.GameMatrix);
            UpdateScore(0);
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
            Parameters.IsMove = false;

            if (Math.Abs(Parameters.StartX - StopX) > 50 || Math.Abs(Parameters.StartY - StopY) > 50)
            {
                if (Math.Abs(Parameters.StartX - StopX) < Math.Abs(Parameters.StartY - StopY))
                {
                    if (Parameters.StartY > StopY)
                    {
                        SlideUp();
                    }
                    else
                    {
                        SlideDown();
                    }
                }
                else
                {
                    if (Parameters.StartX > StopX)
                    {
                        SlideLeft();
                    }
                    else
                    {
                        SlideRight();
                    }
                }
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
    }
}