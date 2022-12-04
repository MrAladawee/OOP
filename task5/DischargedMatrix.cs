using System.Collections;


namespace TaskWithRazrMatrix
{
    internal class DischargedMatrix<T> : IEnumerable
    {

        private int n;
        private int m;
        private Dictionary<int[], T> matrix = new Dictionary<int[], T>();

        public IEnumerator GetEnumerator() => matrix.Values.GetEnumerator();

        public DischargedMatrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            this.matrix = new Dictionary<int[], T>();
            
        }
        ~DischargedMatrix()
        {
            Console.WriteLine("Freesing up memory");
        }
    }
}
