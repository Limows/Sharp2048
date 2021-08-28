using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Sharp2048
{
    class Parameters
    {
        public static int FieldSize = 4;
        public static int[,] GameMatrix;
        public static bool IsGame = true;
        public static bool IsMove = false;
        public static Brush NumberBrush;
        public static Brush TextBrush = new SolidBrush(Color.Black);
        public static Font TextFont = new Font("Impact", 13, FontStyle.Regular);
        public static int Score = 0;
        public static Bitmap GameField;
    }
}
