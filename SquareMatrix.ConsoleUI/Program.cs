using System;
using BSU.ASP._1501.Day8.Puchkov;

namespace SquareMatrix.ConsoleUI
{
    class MatrixListener
    {
        public void Register<T>(SquareMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            matrix.ElementChangedEvent += MatrixUpdate;
        }

        public void Unregister<T>(SquareMatrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            matrix.ElementChangedEvent -= MatrixUpdate;
        }

        public void MatrixUpdate(object sender, MatrixEventArgs e)
        {
            Console.WriteLine($"Matrix changed on [{e.GetI()},{e.GetJ()}]");
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricMatrix<int> symmetricMatrix=new SymmetricMatrix<int>(5);
            MatrixListener matrixListener=new MatrixListener();
            matrixListener.Register(symmetricMatrix);
            for (int i = 0; i < symmetricMatrix.Length; i++)
                symmetricMatrix[i, i] = i;
            matrixListener.Unregister(symmetricMatrix);
            symmetricMatrix.SumSquareMatrix(symmetricMatrix);
            Console.ReadKey();
        }
    }
}
