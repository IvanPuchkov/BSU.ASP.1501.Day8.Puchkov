using System;


namespace BSU.ASP._1501.Day8.Puchkov
{
    public class MatrixEventArgs:EventArgs
    {
        private int _i;
        private int _j;

        public MatrixEventArgs(int i, int j)
        {
            _i = i;
            _j = j;
        }

        public int GetI() => _i;
        public int GetJ() => _j;
    }
}
