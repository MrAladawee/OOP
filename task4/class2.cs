using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SqMatrix : Matrix
    {

        // Random initialization
        public SqMatrix(int n = 0, bool Zero = false)
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

            this.matr = matr;
        }

        public static void SwapRow(SqMatrix A, int row_1, int row_2)
        {

            double[] rowTemp = new double[A.n];

            for (int col = 0; col < A.n; col++)
            {
                rowTemp[col] = A.matr[row_2, col];

                A.matr[row_2, col] = A.matr[row_1, col];
                A.matr[row_1, col] = rowTemp[col];

            }

        }

        // Determinant
        public static double Det(SqMatrix A)
        {
            int countOfSwap = 0;
            SqMatrix Acopy = new SqMatrix(A.n);
            MatrixCopy(A.matr, Acopy.matr, A.n, A.n);

            int row_step = 0; // используется как ID строки относительно которой ведутся преобразования

            for (int col = 0; col < Acopy.n - 1; col++) // перебор всех колонок
            {

                for (int row = row_step + 1; row < Acopy.n; row++)
                {

                    if (Acopy.matr[row_step,col] == 0 && Acopy.matr[row, col] != 0)
                    {
                        SwapRow(Acopy, row_step, row);
                        countOfSwap++;
                    }

                    // a[row_step, col] * X - a[row, col] = 0    => a[row_step, col] * X = a[row, col]     x = a[row, col] / a[row_step, col]
                    double X = Acopy.matr[row, col] / Acopy.matr[row_step, col];

                    for (int col_step = col; col_step < Acopy.n; col_step++)
                    {
                        //A.matr[row, col_step] = Math.Round(A.matr[row, col_step] - X * A.matr[row_step, col_step]);
                        //A.matr[row, col_step] = Math.Round(A.matr[row, col_step] - X * A.matr[row_step, col_step],2);
                        Acopy.matr[row, col_step] = Acopy.matr[row, col_step] - X * Acopy.matr[row_step, col_step];
                    }

                    // Процесс Гаусса поэтапно
                    //
                    //Acopy.show();
                    //Console.WriteLine();

                }
                row_step++;

            }

            double result = 1;

            for (int i = 0; i < A.n; i++)
            {
                result *= Acopy.matr[i, i];
            }

            return result * Math.Pow(-1,countOfSwap);

        }

        //public static double DetRecur(SqMatrix A)
        //{
        //    SqMatrix Acopy = new SqMatrix(A.n);
        //    MatrixCopy(A.matr, Acopy.matr, A.n, A.n);

        //    if (A.n == 1) { return Acopy.matr[0, 0]; }

        //    else if (A.n == 2)
        //    {
        //        return ((Acopy.matr[0, 0] * Acopy.matr[1, 1]) - (Acopy.matr[0, 1] * Acopy.matr[1, 0]));
        //    }

        //    else if (A.n == 3)
        //    {
        //        return (
        //            (Acopy.matr[0, 0] * Acopy.matr[1, 1] * Acopy.matr[2, 2]) + (Acopy.matr[0, 1] * Acopy.matr[1, 2] * Acopy.matr[2, 0]) + (Acopy.matr[0, 2] * Acopy.matr[1, 0] * Acopy.matr[2, 1]) -
        //            (Acopy.matr[0, 2] * Acopy.matr[1, 1] * Acopy.matr[2, 0]) - (Acopy.matr[0, 0] * Acopy.matr[1, 2] * Acopy.matr[2, 1]) - (Acopy.matr[0, 1] * Acopy.matr[1, 0] * Acopy.matr[2, 2])
        //            );
        //    }

        //    else
        //    {

        //        double result = 1;

        //        for (int i = 0; i < A.n; i++)
        //        {
        //            result *= Math.Pow(-1, (i + 0))
        //        }

        //    }
        //}


        // В этой функции нет необходимости, т.к можно
        // испольщовать только её, без вышестоящей, но
        // я её создал лишь для работы без участия
        public static double Det(double[,] A, int n)
        {

            double[,] ArrayTemp = new double[n, n];
            MatrixCopy(A, ArrayTemp, n, n);

            int row_step = 0; // используется как ID строки относительно которой ведутся преобразования

            for (int col = 0; col < n - 1; col++) // перебор всех колонок
            {

                for (int row = row_step + 1; row < n; row++)
                {

                    // a[row_step, col] * X - a[row, col] = 0    => a[row_step, col] * X = a[row, col]     x = a[row, col] / a[row_step, col]
                    double X = ArrayTemp[row, col] / ArrayTemp[row_step, col];

                    for (int col_step = col; col_step < n; col_step++)
                    {
                        //A.matr[row, col_step] = Math.Round(A.matr[row, col_step] - X * A.matr[row_step, col_step]);
                        //A.matr[row, col_step] = Math.Round(A.matr[row, col_step] - X * A.matr[row_step, col_step],2);
                        ArrayTemp[row, col_step] = ArrayTemp[row, col_step] - X * ArrayTemp[row_step, col_step];
                    }

                    // Процесс Гаусса поэтапно
                    //
                    //A.show();
                    //Console.WriteLine();

                }
                row_step++;

            }

            double result = 1;

            for (int i = 0; i < n; i++)
            {
                result *= ArrayTemp[i, i];
            }

            return result;
        }

        public static bool ArrayZero(double[] Array)
        {
            int flag = 0;

            for (int index = 0; index < Array.Length; index++)
            {
                if (Array[index] != 0)
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 0)
            {
                return true;
            }

            else { return false; }

        }


        public static bool LinearLists(double[] Array1, double[] Array2)
        {
            int index_subtraction = 0;
            double coef_subtraction = 0;

            if (ArrayZero(Array1) == true || ArrayZero(Array2) == true)
            {

                // Если присутствует хотя бы 1 нулевая строка,
                // то две строки являются линейными

                return true;

            }

            else
            { 

                // Если отсутствуют нулевые строки,
                // то выполняем проверку линейности
                // по определению

                for (int index = 0; index < Array1.Length; index++)
                {
                    if (Array1[index] != 0)
                    {
                        index_subtraction = index;
                    }
                }

                coef_subtraction = Array2[index_subtraction] / Array1[index_subtraction];

                int flag = 0;

                for (int index = 0; index < Array1.Length; index++)
                {
                    
                    // Если встретится хотя бы 1 раз результат
                    // вычитания одной строки из другой * коэф
                    // не равный нулю (не линейно)
                    // поднимаем флажок и идем к if/else

                    if (Array2[index] - Array1[index] * coef_subtraction != 0)
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0)
                {
                    return true;
                }

                else { return false; }

            }

        }

        // Так как в двумерном массиве невозможно обратиться к строке
        // то достаточно сделать функцию создающую строку по исходному двумерному массиву.
        // Многомерный хранится как одномерный, поэтому обращение доступно только к конкретной позиции
        // Через [x,y,z,..]
        // Альтернатива этому - создание в исходном варианте не двумерный массив, а рваный.
        public static double[] CreateArray(SqMatrix A, int row)
        {
            double[] array = new double[A.n];

            for (int index = 0; index < A.n; index++)
            {
                array[index] = A.matr[row,index];
            }

            return array;
        }

        public static double[] CreateArray(double[,] A, int size, int row)
        {
            double[] array = new double[size];

            for (int index = 0; index < size; index++)
            {
                array[index] = A[row, index];
            }

            return array;
        }

        public static SqMatrix Lin(SqMatrix A)
        {

            double[] Array1 = CreateArray(A, 0);

            if (ArrayZero(Array1) == true)
            {
                //A.matr[0, 0] += 0.1;
                A.matr[0, 0] += 1;
            }

            double pluser = 2;

            for (int row = 0; row < A.n - 1; row++)
            {
                Array1 = CreateArray(A, row);

                for (int row_second = row + 1; row_second < A.n; row_second++)
                {
                    double[] Array2 = CreateArray(A, row_second);

                    if (LinearLists(Array1, Array2) == true)
                    {
                        //A.matr[row_second, 0] = Math.Round(A.matr[row_second, 0] + pluser, 2);
                        A.matr[row_second, 0] = Math.Round(A.matr[row_second, 0] + pluser);
                        //pluser += 0.1;
                        pluser += 1;
                    }

                }

            }

            return A;

        }

        public static double[,] Lin(double[,] A, int size)
        {

            double[] Array1 = CreateArray(A, size, 0);

            if (ArrayZero(Array1) == true)
            {
                //A.matr[0, 0] += 0.1;
                A[0, 0] += 1;
            }

            double pluser = 2;

            for (int row = 0; row < size - 1; row++)
            {
                Array1 = CreateArray(A, size, row);

                for (int row_second = row + 1; row_second < size; row_second++)
                {
                    double[] Array2 = CreateArray(A, size, row_second);

                    if (LinearLists(Array1, Array2) == true)
                    {
                        //A.matr[row_second, 0] = Math.Round(A.matr[row_second, 0] + pluser, 2);
                        A[row_second, 0] = Math.Round(A[row_second, 0] + pluser);
                        //pluser += 0.1;
                        pluser += 1;
                    }

                }

            }

            return A;

        }

    }
}
