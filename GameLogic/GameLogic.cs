using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    public class GameLogic
    {
        public static bool SlideRight(ref int[,] GameMatrix, ref int Score)
        {
            int n = GameMatrix.GetLength(0);
            bool IsMove = false;

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
                                    GameMatrix[i + k, j] = GameMatrix[i + k - 1, j] * 2;
                                    GameMatrix[i + k - 1, j] = 0;

                                    IsMove = true;

                                    Score += GameMatrix[i + k, j];
                                }

                                break;
                            }
                        }

                    }
                }
            }

            return IsMove;
        }

        public static bool SlideDown(ref int[,] GameMatrix, ref int Score)
        {
            bool IsMove = false;

            Rotate(90, ref GameMatrix);
            IsMove = SlideRight(ref GameMatrix, ref Score);
            Rotate(270, ref GameMatrix);

            return IsMove;
        }

        public static bool SlideUp(ref int[,] GameMatrix, ref int Score)
        {
            bool IsMove = false;

            Rotate(270, ref GameMatrix);
            IsMove = SlideRight(ref GameMatrix, ref Score);
            Rotate(90, ref GameMatrix);

            return IsMove;
        }

        public static bool SlideLeft(ref int[,] GameMatrix, ref int Score)
        {
            bool IsMove = false;

            Rotate(180, ref GameMatrix);
            IsMove = SlideRight(ref GameMatrix, ref Score);
            Rotate(180, ref GameMatrix);

            return IsMove;
        }

        private static void Rotate(int Degree, ref int[,] GameMatrix)
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

        public static void Init(out int[,] GameMatrix, out int Score, int n)
        {
            GameMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GameMatrix[i, j] = 0;
                }
            }

            Score = 0;
        }

        public static void AddNumber(int Number, ref int[,] GameMatrix)
        {
            Random RandomInit = new Random();
            int x;
            int y;
            int n = GameMatrix.GetLength(0);

            do
            {
                Random RandomX = new Random(RandomInit.Next());
                Random RandomY = new Random(RandomInit.Next());
                x = RandomX.Next(n);
                y = RandomY.Next(n);
            }
            while (CheckCollision(x, y, ref GameMatrix));

            GameMatrix[x, y] = Number;
        }

        private static bool CheckCollision(int x, int y, ref int[,] GameMatrix)
        {
            return GameMatrix[x, y] != 0;
        }

        public static void StartGame(ref int[,] GameMatrix)
        {
            int n = GameMatrix.GetLength(0);
            Random RandomX = new Random();
            Random RandomY = new Random();
            int x = RandomX.Next(4);
            int y = RandomY.Next(4);

            GameMatrix[x, y] = 2;

            AddNumber(2, ref GameMatrix);
        }

        public static int CheckEndGame(ref int[,] GameMatrix)
        {
            int n = GameMatrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (GameMatrix[i, j] == 0)
                    {
                        return 0;
                    }

                    if (GameMatrix[i, j] == 2048)
                    {
                        return 1;
                    }

                    if (GameMatrix[i, j] == 2)
                    {
                        if (i < n - 1 && GameMatrix[i + 1, j] == 2)
                            return 0;

                        if (i > 1 && GameMatrix[i - 1, j] == 2)
                            return 0;

                        if (j < n - 1 && GameMatrix[i, j + 1] == 2)
                            return 0;

                        if (j > 1 && GameMatrix[i, j - 1] == 2)
                            return 0;
                    }
                }
            }

            return -1;
        }
    }
}
