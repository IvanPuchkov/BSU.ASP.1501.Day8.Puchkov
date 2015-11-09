using System;
using System.Linq.Expressions;

namespace BSU.ASP._1501.Day8.Puchkov
{
    public static class SquareMatrixExtensions
    {
        public static SquareMatrix<T> SumSquareMatrix<T>(this SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            if(matrixA.Length!=matrixB.Length)
                throw new ArgumentException();
            int n = matrixA.Length;
            SquareMatrix<T> result=new SquareMatrix<T>(n);
            try
            {
                Func<T, T, T> sumDelegate = CompileSumDelegate<T>();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        result[i, j] = sumDelegate(matrixA[i, j], matrixB[i, j]);
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return result;
        }

        public static DiagonalMatrix<T> SumDiagonalMatrix<T>(this DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            if (matrixA.Length != matrixB.Length)
                throw new ArgumentException();
            int n = matrixA.Length;
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(n);
            try
            {
                Func<T, T, T> sumDelegate = CompileSumDelegate<T>();
                for (int i = 0; i < n; i++)
                {
                    result[i, i] = sumDelegate(matrixA[i, i], matrixB[i, i]);
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return result;
        }

        public static SymmetricMatrix<T> SumSymmetricMatrix<T>(this SymmetricMatrix<T> matrixA, SymmetricMatrix<T> matrixB)
        {
            if (matrixA.Length != matrixB.Length)
                throw new ArgumentException();
            int n = matrixA.Length;
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(n);
            try
            {
                Func<T, T, T> sumDelegate = CompileSumDelegate<T>();
                for (int i = 0; i < n; i++)
                {
                    for (int j=0;j<=i;j++)
                        result[i, i] = sumDelegate(matrixA[i, i], matrixB[i, i]);
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return result;
        }

        private static Func<T, T, T> CompileSumDelegate<T>()
        {
            ParameterExpression a = Expression.Parameter(typeof (T), "lhs");
            ParameterExpression b = Expression.Parameter(typeof (T), "rhs");
            BinaryExpression body = Expression.Add(a, b);
            return Expression.Lambda<Func<T, T, T>>(body, a, b).Compile();
        }
    }
}
