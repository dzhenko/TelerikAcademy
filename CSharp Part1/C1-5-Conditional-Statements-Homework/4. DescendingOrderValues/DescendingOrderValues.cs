//Sort 3 real values in descending order using nested if statements.


using System;

class DescendingOrderValues
{
    static void Main()
    {
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
                if (b > c)
                {
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(b);
                }
            }
            else
            {
                Console.WriteLine(c);
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }
        else
        {
            if (b > c)
            {
                Console.WriteLine(b);
                if (c > a)
                {
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                }
            }
            else
            {
                Console.WriteLine(c);
                Console.WriteLine(b);
                Console.WriteLine(a);
            }
        }
    }
}

