using System;
using System.Collections.Generic;
using System.Text;

namespace Sharp2048
{
    class Drawing
    {
        public static void SetColor(int Number)
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

        public static void DrawMatrix(ref int[,] GameField)
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
    }
}
