using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wielowatkowasc
{
    internal class Matrix
    {
        public int[,] Macierz;

        public Matrix(int seed)
        {
            Random random = new Random(seed);
            int n = 500;
            int m = 500;
            Macierz = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Macierz[i, j] = random.Next(1, 5);
                }
            }
        }

        public static Matrix Mnozenie(Matrix matrix1, Matrix matrix2, Matrix result, int num_threads, int thread)
        {

            int row_per_th = matrix1.Macierz.GetLength(0)/num_threads;

                int start_row = thread * row_per_th;
                int end_row;
                if (thread < num_threads - 1)
                {
                    end_row = start_row + row_per_th;
                }
                else
                {
                    end_row = matrix1.Macierz.GetLength(0);
                }
                for (int i = start_row; i < end_row; i++)
                {
                    for (int j = 0; j < matrix2.Macierz.GetLength(1); j++)
                    {
                        int suma = 0;
                        for (int k = 0; k < matrix1.Macierz.GetLength(1); k++)
                        {
                            suma += matrix1.Macierz[i, k] * matrix2.Macierz[k, j];
                        }
                        result.Macierz[i, j] = suma;
                    }

                }
            return result;
        }

        public override string ToString()
        {
            string result = $"Macierz: " + Environment.NewLine;
            for (int i = 0;i<4;i++ ) 
            {
                for (int j = 0;j<4;j++)
                    {
                    result += $"{Macierz[i, j]} ";
                    }
                result += Environment.NewLine;
            }
            return result;
        }
    }
}
