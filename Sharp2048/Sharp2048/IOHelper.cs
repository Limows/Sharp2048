using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sharp2048
{
    class IOHelper
    {
        public static void WriteMatrix(int[,] Matrix, string FilePath)
        {
            int n = Matrix.GetLength(0);
            StringBuilder StringMatrix = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    StringMatrix.Append(Matrix[i, j]);
                    StringMatrix.Append(",");
                }
                StringMatrix.Append(";");
            }

            using (FileStream Stream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(StringMatrix.ToString());

                Stream.Write(array, 0, array.Length);
            }
        }

        public static void ReadMatrix(ref int[,] Matrix, string FilePath)
        {
            string[] MatrixRows = new string[4];
            int n = Matrix.GetLength(0);

            using (FileStream Stream = File.OpenRead(FilePath))
            {
                byte[] array = new byte[Stream.Length];

                Stream.Read(array, 0, array.Length);
                string MatrixString = System.Text.Encoding.Default.GetString(array);

                MatrixRows = MatrixString.Split(';');
            }

            for (int i = 0; i < n; i++)
            {
                string Numbers = MatrixRows[i];

                for (int j = 0; j < n; j++)
                {
                    Matrix[i, j] = Numbers[j];
                }
            }
        }
    }
}
