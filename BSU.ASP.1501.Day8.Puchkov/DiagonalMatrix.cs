using System;

namespace BSU.ASP._1501.Day8.Puchkov
{
    public class DiagonalMatrix<T>:SquareMatrix<T>
    {
        public DiagonalMatrix(int length) : base(length)
        {
        }

        public override T this[int i, int j]
        {
            set
            {
                if (i!=j) throw new ArgumentException();
                base[i, j] = value;
            }
        }
    }
}
