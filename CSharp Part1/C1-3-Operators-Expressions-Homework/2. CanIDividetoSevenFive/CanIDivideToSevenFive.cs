using System;

class CanIDivideToSevenFive
{
    static void Main()
    {
        Console.WriteLine("The number is? ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number % 35 == 0)
        {
            Console.WriteLine(number + " can be divided to 35");
        }
        else
        {
            Console.WriteLine(number + " can NOT be divided to 35");
        }
    }
}