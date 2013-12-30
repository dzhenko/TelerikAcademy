using System;

class ArrayReverser
{
    public static T[,] ArrayReverserByGivvenMirrorPlane<T>(T[,] sourceArray, string mirrorPlane)
    {
        T[,] answer = new T[sourceArray.GetLength(0), sourceArray.GetLength(1)];

        if (mirrorPlane=="V")//vertical MirrorPlane
        {
            for (int row = 0; row < sourceArray.GetLength(0); row++)
            {
                for (int col = 0; col < sourceArray.GetLength(1); col++)
                {
                    answer[row, col] = sourceArray[row, sourceArray.GetLength(1) - 1 - col];
                }
            }
        }

        else if (mirrorPlane=="H")
        {
            for (int col = 0; col < sourceArray.GetLength(0); col++)
            {
                for (int row = 0; row < sourceArray.GetLength(1); row++)
                {
                    answer[row, col] = sourceArray[sourceArray.GetLength(0) - 1 - row , col];
                }
            }
        }

        else
        {
            throw new ArgumentException("The mirror plane should be only V for Vertical or H for Horizontal!");
        }

        return answer;
    }
    static void Main(string[] args)
    {
        int[,] testmatrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        var vert = ArrayReverserByGivvenMirrorPlane(testmatrix, "V");

        var hor = ArrayReverserByGivvenMirrorPlane(testmatrix, "H");

           
        for (int i = 0; i < testmatrix.GetLength(0); i++)
        {
            for (int j = 0; j < testmatrix.GetLength(1); j++)
            {
                Console.Write(testmatrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();


        for (int i = 0; i < vert.GetLength(0); i++)
        {
            for (int j = 0; j < vert.GetLength(1); j++)
            {
                Console.Write(vert[i, j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        for (int i = 0; i < hor.GetLength(0); i++)
        {
            for (int j = 0; j < hor.GetLength(1); j++)
            {
                Console.Write(hor[i, j]);
            }
            Console.WriteLine();
        }

            
    }
}

