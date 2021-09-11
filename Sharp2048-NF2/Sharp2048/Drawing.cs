using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sharp2048
{
    class Drawing
    {
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public static void SetColor(int Number)
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

        public static void DrawGame(Graphics Paint, ref int[,] GameMatrix, Rectangle FieldRect)
        {
            int n = GameMatrix.GetLength(0);

            Paint.Clear(Color.FromArgb(187, 173, 160));

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        SetColor(GameMatrix[i, j]);

                        Rectangle NumberRect = new Rectangle
                        (   
                            i * FieldRect.Width / Parameters.FieldSize + 3,
                            j * FieldRect.Height / Parameters.FieldSize + 3,
                            FieldRect.Width / Parameters.FieldSize - 6,
                            FieldRect.Height / Parameters.FieldSize - 6
                        );

                        DrawNumber(Paint, GameMatrix[i, j], NumberRect);
                    }
                }
        }
        public static void DrawNumber(Graphics Paint, int Number, Rectangle NumberRect)
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
    }
}
