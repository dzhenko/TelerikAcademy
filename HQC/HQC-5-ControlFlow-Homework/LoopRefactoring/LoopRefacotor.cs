namespace LoopRefactoring
{
    using System;

    public class LoopRefacotor
    {
        public static void LoopRefactor(int[] arrayToSearch, int expectedValue)
        {
            bool isFound = false;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    if (arrayToSearch[i] == expectedValue)
                    {
                        isFound = true;
                    }
                }

                // not breaking because every value of the array needs to be shown
                Console.WriteLine(arrayToSearch[i]);
            }

            // More code here
            if (isFound)
            {
                // showing the result only after all the values of the array are shown
                Console.WriteLine("Value Found");
            }
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)