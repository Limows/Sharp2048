using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using GameLogic;

namespace Sharp2048
{
    class Program
    {
        static public int[,] GameMatrix;
        static public int Score = 0;
        static public int HighScore = 0;
        static public int FieldSize = 4;

        static void Main(string[] args)
        {
            bool IsGame = true;

            NewGame();

            while (IsGame)
            {
                WaitKey();
            }
        }

        static void NewGame()
        {
            GameLogic.GameLogic.Init(out GameMatrix, out Score, FieldSize);
            GameLogic.GameLogic.StartGame(ref GameMatrix);
            Drawing.DrawMatrix(ref GameMatrix);
        }

        static void WaitKey()
        {
            ConsoleKeyInfo Key = Console.ReadKey();
            bool IsMove = false;

            switch (Key.Key.ToString())
            {
                case "LeftArrow":
                    IsMove = GameLogic.GameLogic.SlideUp(ref GameMatrix, ref Score);
                    break;
                case "RightArrow":
                    IsMove = GameLogic.GameLogic.SlideDown(ref GameMatrix, ref Score);
                    break;
                case "DownArrow":
                    IsMove = GameLogic.GameLogic.SlideRight(ref GameMatrix, ref Score);
                    break;
                case "UpArrow":
                    IsMove = GameLogic.GameLogic.SlideLeft(ref GameMatrix, ref Score);
                    break;
            }

            if (IsMove)
            {
                GameLogic.GameLogic.AddNumber(2, ref GameMatrix);
            }

            switch (GameLogic.GameLogic.CheckEndGame(ref GameMatrix))
            {
                case 1:
                    //MessageBox.Show("You Win!");
                    break;
                case -1:
                    //MessageBox.Show("Game Over!");
                    if (HighScore < Score) HighScore = Score;
                    NewGame();
                    break;
            }

            Drawing.DrawMatrix(ref GameMatrix);
        }

    }
}
