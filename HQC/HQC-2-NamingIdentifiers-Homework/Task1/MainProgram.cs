namespace Task1 // not intended to be smart
{
    using System;

    public static class VariablesOperations
    {
        private const int MAX_COUNT = 6;

        public static void Main()
        {
            var instance = new VariableVisualisator();
            instance.PrintVariableOnConsole(true);
        }

        private class VariableVisualisator
        {
            public void PrintVariableOnConsole(bool inputVariable)
            {
                string inputVariableAsString = inputVariable.ToString();
                Console.WriteLine(inputVariableAsString);
            }
        }
    }
}

// ------ StyleCop completed ------

// ========== Violation Count: 0 ==========

// :)