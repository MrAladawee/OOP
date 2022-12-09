using System.Collections;


namespace TaskWithRazrMatrix
{
    internal class DischargedMatrix<T> : IEnumerable
    {

        public int n;
        public int m;
        public Dictionary<int[], T> matrix = new Dictionary<int[], T>(new NewCompare());

        public IEnumerator GetEnumerator() => matrix.Values.GetEnumerator();

        internal void ContainsKey(int[] vs)
        {
            throw new NotImplementedException();
        }

        public DischargedMatrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            this.matrix = new Dictionary<int[], T>(new NewCompare());

        }

        public T? this[int index1, int index2]
        {
            get
            {
                if (this.matrix.ContainsKey(new int[] { index1, index2 }))
                {
                    return this.matrix[new int[] { index1, index2 }];  // возвращаем полученное значение
                }
                else
                {
                    return default(T); // возвращаем дефолтное значение типа (int = 0, double 0.0 etc..)
                }
            }
            set
            {
                if (value != null && !value.Equals(default(T)) && (index1 < n && index2 < m)) // 1. Передается не пустое значение
                                                                                              // 2.  Значение  не является дефолтным значением передаваемого типа параметра
                                                                                              // 3. Индексы меньше размерности
                {
                    this.matrix[new int[] { index1, index2 }] = value;
                }
            }
        }

        public void show()
        {
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    Console.Write("{0} ", this[i, j]);
                }
                Console.WriteLine();
            }
        }

        public DischargedMatrix<T> sq(int x, int y)
        {
            DischargedMatrix<T> result = new DischargedMatrix<T>(3, 3);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int h = (i + x) % this.n;
                    int w = (j + y) % this.m;
                    if (h < 0) { h += this.n; }
                    if (w < 0) { w += this.m; }
                    result[i + 1, j + 1] = this[h, w];
                }
            }
            return result;
        }

        ~DischargedMatrix()
        {
            Console.WriteLine("Freesing up memory");
        }

    }

    public class NewCompare : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }

}
