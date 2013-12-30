//Write a program that reads two positive integer numbers and prints how many numbers p exist 
//between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.


using System;

class BetweenIntNumbersDivFive
{
    static void Main()
    {
        Console.WriteLine("Enter First Number : ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Second Number : ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Do you want to see details ? (Which the numbers are exactly)  y / n ");
        string det = Console.ReadLine();
        bool details = false;
        if (det == "y")
        {
            details = true;
        }
        if (a>b)
        {
            Console.WriteLine("--> "+((a-b)/5)+" <--- numbers exist between "+ b+" and "
                                        +a+" that can be divided by 5 exactly and those numbers are : " );
            if (details)
            {
                for (int i = b; i <= a; i++)
                {
                    if (i % 5 == 0)
                    {
                        Console.Write(i);
                        Console.Write(", ");
                    }
                }
            }           
        }
        if (a<b)
        {
            Console.WriteLine("--> " + ((b - a) / 5) + " <--- numbers exist between " + a + " and "
                                        + b + " that can be divided by 5 exactly and those numbers are : ");
            if (details)
            {
                for (int i = a; i <= b; i++)
            {
                if (i % 5 == 0)
                {
                    Console.Write(i);
                    Console.Write(", ");
                }
            }
            }
        }
        if (a==b)
        {
            Console.WriteLine("Those numbers are the same ......");
        }
    }
}

