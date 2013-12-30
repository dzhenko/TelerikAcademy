//Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

class Program
{
    static void Main()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int shifter = a;
        if (a > b)
        {
            a = b;
            b = shifter;
        }
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}

