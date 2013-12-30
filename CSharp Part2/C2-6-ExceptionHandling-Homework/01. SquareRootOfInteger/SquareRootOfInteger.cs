//Write a program that reads an integer number and calculates and prints its square root. 
//If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.


namespace _01.SquareRootOfInteger
{
    using System;

    class SquareRootOfInteger
    {
        static void Main()
        {
            int sqroot = 0;
            Console.Write("Enter number: ");
            try
            {
                sqroot = int.Parse(Console.ReadLine());
                if (sqroot < 0)
                {
                    throw new Exception("Invalid number - negative number!");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(sqroot));
                }
            }
            catch (FormatException FE)
            {
                throw new FormatException("Invalid number " + FE.Message);
            }
            catch (OverflowException OE)
            {
                throw new OverflowException("Too big number " + OE.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
