using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sharp2048
{
    class Drawing
    {

        public static void FillRoundedRectangle(Graphics g, Brush brush, Rectangle rect, int radius)
        {
            if (radius <= 0 || rect.Width <= 0 || rect.Height <= 0)
            {
                g.FillRectangle(brush, rect);
                return;
            }

            // Ограничиваем радиус, чтобы он не превышал половину размеров
            radius = Math.Min(radius, Math.Min(rect.Width, rect.Height) / 2);
            int d = radius * 2;

            // Центральный вертикальный прямоугольник
            g.FillRectangle(brush, rect.X + radius, rect.Y, rect.Width - d, rect.Height);

            // Левая и правая вертикальные полосы
            g.FillRectangle(brush, rect.X, rect.Y + radius, radius, rect.Height - d);
            g.FillRectangle(brush, rect.Right - radius, rect.Y + radius, radius, rect.Height - d);

            // Четыре угла
            g.FillEllipse(brush, rect.X, rect.Y, d, d); // Верхний левый
            g.FillEllipse(brush, rect.Right - d - 1, rect.Y, d, d); // Верхний правый
            g.FillEllipse(brush, rect.X, rect.Bottom - d - 1, d, d); // Нижний левый
            g.FillEllipse(brush, rect.Right - d - 1, rect.Bottom - d - 1, d, d); // Нижний правый

            //g.FillPie(brush, rect.X, rect.Y, d, d, 180, 90);            
            //g.FillPie(brush, rect.Right - d, rect.Y, d, d, 270, 90);    // Верхний правый
            //g.FillPie(brush, rect.X, rect.Bottom - d, d, d, 90, 90);    // Нижний левый
            //g.FillPie(brush, rect.Right - d, rect.Bottom - d, d, d, 0, 90); // Нижний правый
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
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //Paint.SmoothingMode = SmoothingMode.AntiAlias;

            if (Parameters.Pallete == Parameters.PalleteType.Rounded)
            {
                FillRoundedRectangle(Paint, Parameters.NumberBrush, NumberRect, 10);
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
