using System.Drawing;

namespace Sharp2048
{
    class Parameters
    {
        public static int FieldSize = 4;
        public static int[,] GameMatrix;
        public static Brush NumberBrush;
        public static Brush TextBrush = new SolidBrush(Color.Black);
        public static Font TextFont = new Font("Impact", 13, FontStyle.Regular);
        public static int Score = 0;
        public static Bitmap GameField;
        public static string ConfigPath;
        public static string SavePath;
        public static int HighScore;
        public static PalleteType Pallete;

        public enum PalleteType
        {
            Square,
            Rounded
        }
    }
}
