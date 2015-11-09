using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BSU.ASP._1501.Day8.Puchkov
{
    public class SymmetricMatrix<T>:SquareMatrix<T>
    {
        public SymmetricMatrix(int length) : base(length)
        {
        }

        public override T this[int i, int j]
        {
            set
            {
                base[i, j] = value;
                if (i!=j)
                    base[j, i] = value;
            }
        }
    }
}
