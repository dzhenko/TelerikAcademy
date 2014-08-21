namespace _02.MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EditDistance
    {
        public static string start = "developer"; //this is our row
        public static string target = "enveloped";//this is our col

        public const decimal costReplace = 1.0m;
        public const decimal costDelete = 0.9m;
        public const decimal costInsert = 0.8m;
                                                    //target is our col so the number of rows are the length of target + 1
                                                    //start is row so the number of cols are the length of start + 1
        public static decimal[,] table = new decimal[target.Length + 1, start.Length + 1];

        /// <summary>
        /// Idea is following : if we have some string and want to produce empty string as an answer we delete each char.
        ///                     if we have empty string and we want to produce some string as an answer we insert each char.
        /// if we have A and A it costs us nothing to replace them
        /// if we have A and B it costs us replace cost to replace them
        /// 
        /// we start from the begining of each of the two strings
        /// we can do one of 3 operations
        /// if we replace the current char, we move forward one index on each string
        /// if we delete a char from the start we move forward one index on start
        /// if we insert a char in the start it is like deleting a char from the target and so we move one index on target
        /// 
        /// we start solving from a table (of costs) at position 0 0.
        /// 
        /// we always choose the most cheap operation - which is the following of 3:
        ///     1. Delete a current char in start - meaning getting the already found solution from the left cell
        ///         (start is on the row that is why it is left) + the price it costs us to perform a delete operation
        ///     2. Insert a current char in start - meaning getting the already found solution from the up cell
        ///         (inserting in start is like deleting in target that is why it is up) + the price for insert operation
        ///     3. Replace a current char in start - meaning getting the alredy found solution from the diagonal up-left
        ///         (it is like the current problem is solved so we take the problem if both start and target are 1 char shorter)
        ///         + replace cost operation (which is 0 if the two chars are the same)
        /// See minimum edit distance for more information.
        /// </summary>
        public static void Main()
        {
            //base case - from empty string to empty string it cost us nothing
            table[0, 0] = 0;

            //setting the 0 row - deleting operation - from full start to produce empty string   //meaning delete - get LEFT
            for (int i = 0; i < table.GetLength(1); i++)
            {
                table[0, i] = i * costDelete;
            }

            //setting the 0 col - inserting operation - from empty start to produce full string   //meaning insert - get TOP
            for (int i = 0; i < table.GetLength(0); i++)
            {
                table[i, 0] = i * costInsert;
            }

            for (int row = 0; row < target.Length; row++)
			{
                for (int col = 0; col < start.Length; col++)
                {
                    var replaceCost = target[row] == start[col] ? 0 : costReplace;

                    //get current cell
                    var replace = table[row, col] + replaceCost;

                    //get LEFT (from position row+1,col+1 LEFT is row+1,col)
                    var delete = table[row+1, col] + costDelete;

                    //get TOP (from position row+1,col+1 TOP is row,col+1)
                    var insert = table[row, col+1] + costInsert;

                    table[row + 1, col + 1] = Math.Min(Math.Min(replace,delete),insert);
                }
			}

            PrintCostTable();

            PrintOperationsPerformed();
        }

        private static void PrintOperationsPerformed()
        {
            List<string> operations = new List<string>();

            int row = table.GetLength(0) - 1;
            int col = table.GetLength(1) - 1;

            decimal cost = table[row, col];

            while (cost > 0)
            {
                var left = cost;
                var top = cost;
                var diag = cost;

                if (row > 0 && col > 0)
                {
                    left = table[row, col - 1];
                    top = table[row - 1, col];
                    diag = table[row - 1, col - 1];
                }
                else if (col > 0)
                {
                    left = table[row, col - 1];
                }
                else if (row > 0)
                {
                    top = table[row - 1, col];
                }

                if (diag < top && diag < left)
                {
                    row--;
                    col--;
                    if (cost != diag)
                    {
                        operations.Add(string.Format("Replace {0} with {1}",start[row],target[col]));
                        cost = diag;
                    }
                }
                else if (top < diag && top < left)
                {
                    row--;
                    if (cost != top)
                    {
                        operations.Add(string.Format("Delete {0}",start[row]));
                        cost = top;
                    }
                }
                else
                {
                    col--;
                    if (cost != left)
                    {
                        operations.Add(string.Format("Insert {0}", target[col]));
                        cost = left;
                    }
                }
            }

            operations.Reverse();
            Console.WriteLine("Operations:");
            foreach (var oper in operations)
            {
                Console.WriteLine(oper);
            }
        }
  
        private static void PrintCostTable()
        {
            for (int col = 0; col < table.GetLength(1); col++)
            {
                if (col == 0)
                {
                    Console.Write("\"\"".PadLeft(6, ' '));
                }
                else
                {
                    Console.Write("{0}".PadLeft(6, ' '), start[col - 1]);
                }
            }
            Console.WriteLine();
            for (int row = 0; row < table.GetLength(0); row++)
            {
                if (row == 0)
                {
                    Console.Write("\"\"".PadLeft(2, ' '));
                }
                else
                {
                    Console.Write("{0}".PadLeft(4, ' '), target[row - 1]);
                }

                for (int col = 0; col < table.GetLength(1); col++)
                {
                    Console.Write("{0}".PadLeft(4, ' '), table[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
