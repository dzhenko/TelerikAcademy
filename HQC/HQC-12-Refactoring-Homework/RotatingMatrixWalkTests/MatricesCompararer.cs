namespace RotatingMatrixWalkTests
{
    public class MatricesCompararer
    {
        public static bool AreSame(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0))
            {
                return false;
            }

            if (matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                return false;
            }

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    if (matrix1[row,col] != matrix2[row,col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
