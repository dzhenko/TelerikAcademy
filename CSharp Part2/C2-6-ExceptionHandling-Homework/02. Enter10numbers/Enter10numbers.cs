//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
//If an invalid number or non-number text is entered, the method should throw an exception. 
//Using this method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

namespace _02.Enter10numbers
{
    using System;

    class Enter10numbers
    {
        public static void ReadNumber(int[] array, int currNum)
        {
            Console.Write("Enter a{0} : ",currNum + 1);
            try
            {
                array[currNum] = int.Parse(Console.ReadLine());
            }
            catch (FormatException FE)
            {
                throw new FormatException("Invalid Number ! " + FE);
            }

            if (currNum == 0)
	        {
		        if (array[currNum] <= 1)
	            {
                    throw new Exception("The first number should be bigger than 1!");
	            }
	        }
            else if (currNum ==9)
            {
                if (array[currNum] >+ 100)
                {
                    throw new Exception("The last number should be smaller than 100!");
                }
            }
            else
            {
                if (array[currNum] < array[currNum-1])
                {
                    throw new Exception("This number should be bigger than the previous one!");
                }
            }
        }

        public static void Main()
        {
            int[] arrayA = new int[10];
            for (int i = 0; i < 10; i++) // we read 10 numbers
            {
                ReadNumber(arrayA, i);
            }
        }
    }
}
