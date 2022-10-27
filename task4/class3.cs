using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class InverseMatrix : SqMatrix
    {

        public InverseMatrix(int n = 0, bool Zero = false)
        {
            this.n = n;
            this.m = n;

            double[,] matr = new double[n, n];

            Random r = new Random();
            Random d = new Random();

            if (Zero)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = 0;
                    }
                }
            }

            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        //matr[i, j] = Convert.ToInt64(d.NextDouble() * 10000) / 100.0;
                        matr[i, j] = r.Next(1, 10);
                    }
                }
            }

            //if (SqMatrix.Det(matr,n) == 0)
            //{
            //    matr = SqMatrix.Lin(matr, n);
            //}

            this.matr = matr;
        }

        public static double AttachedMinor(double[,] A, int size, int row_curr, int col_curr)
        {

            double[,] matrTemp = new double[size-1, size-1];
            double additionalMinor = 0;


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == row_curr || j == col_curr)
                    {
                        continue;
                    }

                    else if (i < row_curr && j < col_curr)
                    {
                        matrTemp[i, j] = A[i, j];
                    }

                    else if (i > row_curr && j > col_curr)
                    {
                        matrTemp[i-1, j-1] = A[i, j];
                    }

                    else if (i > row_curr && j < col_curr)
                    {
                        matrTemp[i-1,j] = A[i, j];
                    }

                    else if (i < row_curr && j > col_curr)
                    {
                        matrTemp[i, j - 1] = A[i, j];
                    }
                }
            }

            additionalMinor = SqMatrix.Det(matrTemp, size - 1);

            return (Math.Pow(-1, row_curr + col_curr) * additionalMinor);

        }

        public static InverseMatrix Inverse(InverseMatrix A)
        {
            double determinante = SqMatrix.Det(A);
            double[,] attachedMatr = new double[A.n, A.n];

            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.n; j++)
                {
                    attachedMatr[i, j] = AttachedMinor(A.matr, A.n, i, j);
                }
            }

            Array.Copy(attachedMatr, A.matr, A.n);

            Matrix.Transp(A);

            double coef = 1.0; // determinante;

            A.matr = Matrix.multiplyVal(A.matr, A.n, A.n, coef);

            return A;
        }

    }
}
