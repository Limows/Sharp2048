using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using IniParser;

namespace Sharp2048
{
    class IOHelper
    {
        public static void WriteGame(int[,] Matrix, int Score, string FileName)
        {
            int n = Matrix.GetLength(0);
            StringBuilder StringMatrix = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    StringMatrix.Append(Matrix[i, j]);

                    if (j < n - 1) StringMatrix.Append(",");
                }
                if (i < n - 1) StringMatrix.Append(";");
            }

            StringMatrix.Append("\n" + Score);

            using (FileStream Stream = new FileStream(GetCurrentDirectory() + "\\" + FileName, FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(StringMatrix.ToString());

                Stream.Write(array, 0, array.Length);
            }
        }

        public static void ReadGame(ref int[,] Matrix, ref int Score, string FileName)
        {
            string[] MatrixRows = new string[4];
            int n = Matrix.GetLength(0);

            using (FileStream Stream = File.OpenRead(GetCurrentDirectory() + "\\" + FileName))
            {
                byte[] array = new byte[Stream.Length];

                Stream.Read(array, 0, array.Length);
                string MatrixString = System.Text.Encoding.Default.GetString(array, 0, array.Length);

                Score = Convert.ToInt32(MatrixString.Split('\n')[1]);

                MatrixRows = MatrixString.Split('\n')[0].Split(';');
            }

            for (int i = 0; i < n; i++)
            {
                string[] Numbers = MatrixRows[i].Split(',');

                for (int j = 0; j < n; j++)
                {
                    Matrix[i, j] = Convert.ToInt32(Numbers[j]);
                }
            }
        }

        public static void WriteSettings()
        {
            if (String.IsNullOrEmpty(Parameters.ConfigPath))
            {
                Parameters.ConfigPath = IOHelper.GetConfigPath();
            }

            var Parser = new FileIniDataParser();
            var Config = new IniParser.Model.IniData();

            Config["Game"]["HighScore"] = Convert.ToString(Parameters.HighScore);
            Config["Field"]["Size"] = Convert.ToString(Parameters.FieldSize);
            Config["Palletes"]["Type"] = Parameters.Pallete == Parameters.PalleteType.Square ? "Square" : "Rounded";

            Parser.WriteFile(Parameters.ConfigPath, Config, Encoding.Default);
        }

        static private string GetConfigPath()
        {
            string[] ConfigFiles = Directory.GetFiles(GetCurrentDirectory(), "*.ini");

            return ConfigFiles[0];
        }

        static public string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        public static void ReadSettings()
        {
            if (String.IsNullOrEmpty(Parameters.ConfigPath))
            {
                Parameters.ConfigPath = IOHelper.GetConfigPath();
            }

            var Parser = new FileIniDataParser();
            var Config = Parser.ReadFile(Parameters.ConfigPath);

            Parameters.HighScore = Convert.ToInt32(Config["Game"]["HighScore"]);
            Parameters.FieldSize = Convert.ToInt32(Config["Field"]["Size"]);
            Parameters.Pallete = Config["Palletes"]["Type"] == "Square" ? Parameters.PalleteType.Square : Parameters.PalleteType.Rounded;
        }
    }
}
