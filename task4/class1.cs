using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_space {

    public class Matrix
    {
        private int n;
        private int m;
        private double[,] matr;

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
                        matr[i, j] = Convert.ToInt64(d.NextDouble() * 10000) / 100.0;
                    }
                }
            }
            this.matr = matr;
        }
        
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
            this.matr = new double[0,0];
        }

        public void show()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0} ", this.matr[i,j]);
                }
                Console.WriteLine();
            }
        }


        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.n, A.m, true);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < B.m; j++)
                {
                    C.matr[i,j] = A.matr[i,j] + B.matr[i,j];
                }
            }

            return C;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.n, A.m, true);
            for (int i = 0; i < A.n; i++)
            {
                for (int j = 0; j < B.m; j++)
                {
                    C.matr[i, j] = A.matr[i, j] - B.matr[i, j];
                }
            }

            return C;
        }

    }
}
