using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _2048_cli
{
    class Program
    {
        static public int[,] GameMatrix;
        static public bool IsMove;
        static void Main(string[] args)
        {
            int n = 4;
            bool IsGame = true;

            NewGame(n);

            while (IsGame)
            {
                WaitKey();
            }
        }

        static void NewGame(int FieldSize)
        {
            Init(out GameMatrix, FieldSize);
            StartGame();
            DrawMatrix(GameMatrix);
        }

        static void SetColor(int Number)
        {
            ConsoleColor Color = ConsoleColor.Black;

            switch (Number)
            {
                case 0: Color = ConsoleColor.DarkGray; break;
                case 2: Color = ConsoleColor.Green; break;
                case 4: Color = ConsoleColor.Cyan; break;
                case 8: Color = ConsoleColor.Yellow; break;
                case 16: Color = ConsoleColor.Green; break;
                case 32: Color = ConsoleColor.Cyan; break;
                case 64: Color = ConsoleColor.Yellow; break;
                case 128: Color = ConsoleColor.Green; break;
                case 256: Color = ConsoleColor.Cyan; break;
                case 1024: Color = ConsoleColor.Yellow; break;
                default: Color = ConsoleColor.Black; break;
            }

            Console.BackgroundColor = Color;
        }

        static void Init(out int [,] GameField, int n)
        {
            GameField = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GameField[i, j] = 0;
                }
            }
        }

        static void StartGame()
        {
            Random RandomX = new Random();
            Random RandomY = new Random();
            int x = RandomX.Next(4);
            int y = RandomY.Next(4);

            GameMatrix[x, y] = 2;

            AddNumber(2);
        }

        static bool CheckCollision(int x, int y)
        {
            return GameMatrix[x, y] == 0 ? false : true;
        }

        static void AddNumber(int Number)
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

            GameMatrix[x, y] = Number;
        }

        static void WaitKey()
        {
            ConsoleKeyInfo Key = Console.ReadKey();

            switch(Key.Key.ToString())
            {
                case "LeftArrow":
                    SlideUp();
                    break;
                case "RightArrow":
                    SlideDown();
                    break;
                case "DownArrow":
                    SlideRight();
                    break;
                case "UpArrow":
                    SlideLeft();
                    break;
            }

            AddNumber(2);

            DrawMatrix(GameMatrix);
        }

        static void DrawMatrix(int[,] GameField)
        {
            int n = GameField.GetLength(0);
            Console.Clear();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < n; j++)
                {
                    SetColor(GameField[i, j]);

                    if (GameField[i, j] == 0)
                    {
                        Console.Write("   ");
                    }
                    else Console.Write(" " + GameField[i, j] + " ");
                }
            }

            SetColor(-1);
        }

        static void SlideRight()
        {
            int n = GameMatrix.GetLength(0);

            for (int j = 0; j < n; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (GameMatrix[i, j] > 0) 
                    {

                        for (int k = 1; k < n - i; k++)
                        {
                            if (GameMatrix[i + k, j] == 0)
                            {
                                GameMatrix[i + k, j] = GameMatrix[i + k - 1, j];
                                GameMatrix[i + k - 1, j] = 0;
                                IsMove = true;
                            }
                            else
                            {
                                if (GameMatrix[i + k, j] == GameMatrix[i + k - 1, j])
                                {
                                    GameMatrix[i + k, j] = GameMatrix[i + k - 1, j]*2;
                                    GameMatrix[i + k - 1, j] = 0;
                                    IsMove = true;

                                    //UpdateScore(Parameters.GameMatrix[i + k, j]);

                                    if (GameMatrix[i + k, j] == 2048)
                                    {
                                        //MessageBox.Show("You Win!");
                                        NewGame(4);
                                    }
                                }

                                break;
                            }
                        }

                        
                    }
                }
            }
        }

        static void SlideDown()
        {
            Rotate(90);
            SlideRight();
            Rotate(270);
        }

        static void SlideUp()
        {
            Rotate(270);
            SlideRight();
            Rotate(90);
        }

        static void SlideLeft()
        {
            Rotate(180);
            SlideRight();
            Rotate(180);
        }

        static void Rotate(int Degree)
        {
            int n = GameMatrix.GetLength(0);

            if (Degree == 360) return;

            for (; Degree >= 90; Degree -= 90)
            {
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = i; j < n - i - 1; j++)
                    {
                        int Temp = GameMatrix[i, j];
                        GameMatrix[i, j] = GameMatrix[n - 1 - j, i];
                        GameMatrix[n - 1 - j, i] = GameMatrix[n - 1 - i, n - 1 - j];
                        GameMatrix[n - i - 1, n - j - 1] = GameMatrix[j, n - i - 1];
                        GameMatrix[j, n - i - 1] = Temp;
                    }
                }
            }
        }
    }
}
