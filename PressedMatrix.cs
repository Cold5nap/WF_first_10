using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_first_10
{
    public class PressedMatrix
    {
        public static int[][] getPressedMatrix(int[][] matrix)
        {
            return getMatrixWithoutColsToErase(getMatrixWithoutRowsToErase(matrix));
        }
        private static int[][] getMatrixWithoutRowsToErase(int[][] matrix)
        {
            //cчет колонок для стирания для выделение памяти
            int rowsToErase = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        counter++;
                    }
                }
                if (counter == matrix[0].Length)
                {
                    rowsToErase++;
                }
            }
            //выделяем память
            int[][] res = new int[matrix.Length - rowsToErase][];
            for (int i = 0; i < matrix.Length - rowsToErase; i++)
            {
                res[i] = new int[matrix[0].Length];
            }
            //присваиваем res незануленные столбцы
            int rowsIndex = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        counter++;
                    }
                }

                if (counter != matrix[0].Length)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        res[rowsIndex][j] = matrix[i][j];
                    }
                    rowsIndex++;
                }
            }
            return res;
        }
        private static int[][] getMatrixWithoutColsToErase(int[][] matrix)
        {
            //cчет колонок для стирания для выделение памяти
            int colsToErase = 0;
            for (int i = 0; i < matrix[0].Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        counter++;
                    }
                }
                if (counter == matrix.Length)
                {
                    colsToErase++;
                }
            }
            //выделяем память
            int[][] res = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                res[i] = new int[matrix[0].Length - colsToErase];
            }
            //присваиваем res незануленные столбцы
            int colsIndex = 0;
            for (int i = 0; i < matrix[0].Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.Length; j++)
                {
                    if (matrix[j][i] == 0)
                    {
                        counter++;
                    }
                }

                if (counter != matrix.Length)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        res[j][colsIndex] = matrix[j][i];
                    }
                    colsIndex++;
                }
            }
            return res;
        }
    }
}
