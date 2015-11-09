using System;

namespace BSU.ASP._1501.Day8.Puchkov
{
    public class SquareMatrix<T>
    {
        public int Length => _matrix.GetLength(0);

        public delegate void ElementChangedEventHandler(object sender, MatrixEventArgs args);

        public event ElementChangedEventHandler ElementChangedEvent = delegate { };

        public void OnElementChanged(int i, int j)
        {
            ElementChangedEvent(this,new MatrixEventArgs(i,j));
        }

        private readonly T[,] _matrix;

        public SquareMatrix(int length)
        {
            _matrix=new T[length,length];
        }

        public virtual T this[int i, int j]
        {
            get
            {
                try
                {
                    return _matrix[i, j];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                try
                {
                    _matrix[i, j]=value;
                    OnElementChanged(i,j);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

        } 
    }
}
