using System;

class OddEven
{
    static void Main()
    {
        Console.WriteLine("The number is? ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine(number + "is an even number");
        }
        else
        {
            Console.WriteLine(number + "is an odd number");
        }
    }
}

