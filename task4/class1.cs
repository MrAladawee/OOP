using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Matrix
    {
        private int n;
        private int m;
        private double[,] matr;

        // Random initialization
        public Matrix(int n = 0, int m = 0, bool Zero = false)
        {
            this.n = n;
            this.m = m;
            double[,] matr = new double[n, m];

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
            this.matr = matr;
        }

        // Initialization through file
        public Matrix(string filename = "")
        {
            int n = Convert.ToInt32(Console.ReadLine());
            this.n = n;
            int m = Convert.ToInt32(Console.ReadLine());
            this.m = m;
        }

        public Matrix()
        {
            this.n = 0;
            this.m = 0;
            this.matr = new double[0, 0];
        }

        // Destucter Matrix
        ~Matrix()
        {
            Console.WriteLine("Freeing up memory");
        }

        // Show-method
        public void show()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0} ", this.matr[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Multiplication matrix A by value
        public static Matrix multiplyVal(Matrix A, int value)
        {
            Matrix Result = new Matrix(A.n, A.m);

            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    Result.matr[i, j] = A.matr[i, j]*value;
                }
            }

            return Result;
        }

        // Multiplication matrix A by matrix B
        public static Matrix multiplyMtx(Matrix A, Matrix B)
        {

            if (A.m != B.n)
            {
                Console.WriteLine("Error #1. The dimensions are incorrect. \n Creating a matrix of the dimension of the matrix A with zeros");
                Matrix Result = new Matrix(A.n, A.m, true);
                return Result;
            }

            else
            {
                Matrix Result = new Matrix(A.n, B.m);

                for (int i = 0; i < A.n; i++)
                {
                    for (int j = 0; j < B.m; j++)
                    {
                        double temp = 0;

                        for (int r = 0; r < A.m; r++)
                        {
                            temp += A.matr[i, r] * B.matr[r, j];
                        }

                        Result.matr[i, j] = temp;

                    }
                }

                return Result;
            }
        }

        // Multiplication Overload
        public static Matrix operator *(Matrix A, Matrix B)
        {
            return Matrix.multiplyMtx(A, B);
        }

        public static Matrix operator *(Matrix A, int B)
        {
            return Matrix.multiplyVal(A, B);
        }

        // Method of subtracting matrix B from matrix A
        public static Matrix Difference(Matrix A, Matrix B)
        {

            Matrix Result = new Matrix(A.n, A.m);

            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    Result.matr[i, j] = A.matr[i, j] - B.matr[i, j];
                }
            }

            return Result;
        }

        // Difference Overload
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.Difference(a, b);
        }

        public static Matrix Sum(Matrix A, Matrix B)
        {
            Matrix Result = new Matrix(A.n, A.m);

            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    Result.matr[i, j] = A.matr[i, j] + B.matr[i, j];
                }
            }

            return Result;
        }

        // Addition Overload
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }

        // Matrix transposition
        public static Matrix Transp(Matrix A)
        {
            Matrix Result = new Matrix(A.m, A.n);

            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < A.m; j++)
                {
                    Result.matr[j, i] = A.matr[i, j];
                }
            }

            return Result;
        }

        // Take elem from matrix
        public static double Recieve(Matrix A, int index_n, int index_m)
        {
            return A.matr[index_n, index_m];
        }

    }
}
