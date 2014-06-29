namespace RotatingMatrixWalkTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RotatingMatrixWalk;

    [TestClass]
    public class RotatingMatrixWalkTests
    {
        public int[,] matrix1;
        public int[,] matrix2;
        public int[,] matrix3;
        public int[,] matrix4;
        public int[,] matrix5;
        public int[,] matrix6;
        public int[,] matrix7;
        public int[,] matrix8;
        public int[,] matrix9;
        public int[,] matrix10;

        [TestInitialize]
        public void InitializeRealAnswers()
        {
            matrix1 = new int[,] {{1}};

            matrix2 = new int[,] {{1, 4},
                                  {3, 2}};

            matrix3 = new int[,] {{1, 7, 8},
                                  {6, 2, 9},
                                  {5, 4, 3}};

            matrix4 = new int[,] {{1,10, 11, 12},
                                  {9, 2, 15, 13},
                                  {8, 16, 3, 14},
                                  {7, 6, 5, 4}};

            matrix5 = new int[,] {{1,13,14,15,16},
                                  {12,2,21,22,17},
                                  {11,23,3,20,18},
                                  {10,25,24,4,19},
                                  {9,8,7,6,5}};

            matrix6 = new int[,] {{1,16,17,18,19,20},
                                  {15,2,27,28,29,21},
                                  {14,31,3,26,30,22},
                                  {13,36,32,4,25,23},
                                  {12,35,34,33,5,24},
                                  {11,10,9,8,7,6}};

            matrix7 = new int[,] {{1,19,20,21,22,23,24},
                                  {18,2,33,34,35,36,25},
                                  {17,40,3,32,39,37,26},
                                  {16,48,41,4,31,38,27},
                                  {15,47,49,42,5,30,28},
                                  {14,46,45,44,43,6,29},
                                  {13,12,11,10,9,8,7}};

            matrix8 = new int[,] {{1,22,23,24,25,26,27,28 },
                                  {21,2,39,40,41,42,43,29},
                                  {20,50,3,38,48,49,44,30},
                                  {19,61,51,4,37,47,45,31},
                                  {18,60,62,52,5,36,46,32 },
                                  {17,59,64,63,53,6,35,33 },
                                  {16,58,57,56,55,54,7,34 },
                                  {15,14,13,12,11,10,9,8  }};

            matrix9 = new int[,] {{1,25,26,27,28,29,30,31,32},
                                  {24,2,45,46,47,48,49,50,33},
                                  {23,61,3,44,57,58,59,51,34},
                                  {22,75,62,4,43,56,60,52,35},
                                  {21,74,76,63,5,42,55,53,36},
                                  {20,73,81,77,64,6,41,54,37},
                                  {19,72,80,79,78,65,7,40,38},
                                  {18,71,70,69,68,67,66,8,39},
                                  {17,16,15,14,13,12,11,10,9}};

            matrix10 = new int[,] {{1,28,29,30,31,32,33,34,35,36},
                                  {27,2,51,52,53,54,55,56,57,37},
                                  {26,73,3,50,66,67,68,69,58,38},
                                  {25,90,74,4,49,65,72,70,59,39},
                                  {24,89,91,75,5,48,64,71,60,40},
                                  {23,88,99,92,76,6,47,63,61,41},
                                  {22,87,98,100,93,77,7,46,62,42},
                                  {21,86,97,96,95,94,78,8,45,43},
                                  {20,85,84,83,82,81,80,79,9,44},
                                  {19,18,17,16,15,14,13,12,11,10}};
        }

        [TestMethod]
        public void TestMatrixLenght1()
        {
            var testMatrix = new int[1, 1];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix1));
        }

        [TestMethod]
        public void TestMatrixLenght2()
        {
            var testMatrix = new int[2, 2];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix2));
        }

        [TestMethod]
        public void TestMatrixLenght3()
        {
            var testMatrix = new int[3, 3];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix3));
        }

        [TestMethod]
        public void TestMatrixLenght4()
        {
            var testMatrix = new int[4, 4];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix4));
        }

        [TestMethod]
        public void TestMatrixLenght5()
        {
            var testMatrix = new int[5, 5];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix5));
        }

        [TestMethod]
        public void TestMatrixLenght6()
        {
            var testMatrix = new int[6, 6];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix6));
        }

        [TestMethod]
        public void TestMatrixLenght7()
        {
            var testMatrix = new int[7, 7];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix7));
        }

        [TestMethod]
        public void TestMatrixLenght8()
        {
            var testMatrix = new int[8, 8];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix8));
        }

        [TestMethod]
        public void TestMatrixLenght9()
        {
            var testMatrix = new int[9, 9];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix9));
        }

        [TestMethod]
        public void TestMatrixLenght10()
        {
            var testMatrix = new int[10, 10];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(testMatrix);

            Assert.IsTrue(MatricesCompararer.AreSame(testMatrix, matrix10));
        }
    }
}
