using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_first_10
{
    public class TextMatrix
    {
        public static int[][] getGeneratedRandomMatrix(int row, int col)
        {
            Random random = new Random();
            int[][] matrix = new int[row][];
            for (int i = 0; i < row; i++)
            {
                matrix[i] = new int[col];
                for (int j = 0; j < col; j++)
                {
                    matrix[i][j] = random.Next(2);
                }
            }
            return matrix;
        }
        void PrintSeq(int[][] matrix, int numMatrix, string prefix)
        {
            Console.WriteLine($"{prefix}:Matrix №{numMatrix}");
            PrintMatrix(matrix);
        }
        void PrintMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        public static string getStringMatrix(int[][] matrix)
        {
            string str = "";
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    str+=$"{matrix[i][j]} ";
                }
                str += "\n";
            }
            return str;
        }

        public static int[][] getIntMatrixFromString(string strMatrix)
        {
            //регулярное выражение поиска переходов на новую строчку
            Regex regexNewRow = new Regex(@"\n");
            MatchCollection matchesNewRow = regexNewRow.Matches(strMatrix);
            int[][] matrix = new int[matchesNewRow.Count][];
            string[] strRows = strMatrix.Split('\n');
            //регулярное выражение поиска числа
            Regex regexNumber = new Regex(@"\d{1,}");

            for (int i = 0; i < matrix.Length; i++)
            {
                MatchCollection matchNumbers = regexNumber.Matches(strRows[i]);
                matrix[i] = new int[matchNumbers.Count];
                for (int j = 0; j < matrix[i].Length; j++)
                    matrix[i][j] = int.Parse(matchNumbers[j].Value);
            }
            return matrix;
        }
        public static int[][] getMatrixFromFile(string path)
        {
            int[][] matrix = null;
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    string strMatrix = stream.ReadToEnd();
                    matrix = getIntMatrixFromString(strMatrix);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Процесс прерван с ошибкой: {0}", e.ToString());
            }
            return matrix;
        }

    }
}
