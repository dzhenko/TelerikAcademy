//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.


using System;

class IsSubSetSumZero
{
    static void Main()
    {
        //input
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());
        int d = Convert.ToInt32(Console.ReadLine());
        int e = Convert.ToInt32(Console.ReadLine());
        //5
        if (a+b+c+d+e==0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + c + " " + d + " " + e + " " + "is 0");
        }
        //4
        else if (a+b+c+d ==0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + c + " " + d + " is 0");
        }
        else if (a + b + c + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + c + " " + e + " is 0");
        }
        else if (a + b + d + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + d + " " + e + " is 0");
        }
        else if (a + c + d + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + c + " " + d + " " + e + " is 0");
        }
        else if (b + c + d + e == 0)
        {
            Console.WriteLine("The sum of " + b + " " + c + " " + d + " " + e + " is 0");
        }
        //3
        else if (a + b + c == 0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + c + " is 0");
        }
        else if (a + b + d == 0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + d + " is 0");
        }
        else if (a + b + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " " + e + " is 0");
        }
        else if (a + c + d == 0)
        {
            Console.WriteLine("The sum of " + a + " " + c + " " + d + " is 0");
        }
        else if (a + c + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + c + " " + e + " is 0");
        }
        else if (a + d + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + d + " " + e + " is 0");
        }
        else if (b + c + d == 0)
        {
            Console.WriteLine("The sum of " + b + " " + c + " " + d + " is 0");
        }
        else if (b + c + e == 0)
        {
            Console.WriteLine("The sum of " + b + " " + c + " " + e + " is 0");
        }
        else if (b + d + e == 0)
        {
            Console.WriteLine("The sum of " + b + " " + d + " " + e + " is 0");
        }
        else if (c + d + e == 0)
        {
            Console.WriteLine("The sum of " + c + " " + d + " " + e + " is 0");
        }
        //2
        else if (a + b  == 0)
        {
            Console.WriteLine("The sum of " + a + " " + b + " is 0");
        }
        else if (a + c == 0)
        {
            Console.WriteLine("The sum of " + a + " " + c + " is 0");
        }
        else if (a + d == 0)
        {
            Console.WriteLine("The sum of " + a + " " + d + " is 0");
        }
        else if (a + e == 0)
        {
            Console.WriteLine("The sum of " + a + " " + e + " is 0");
        }
        else if (b + c == 0)
        {
            Console.WriteLine("The sum of " + b + " " + c + " is 0");
        }
        else if (b + d == 0)
        {
            Console.WriteLine("The sum of " + b + " " + d + " is 0");
        }
        else if (b + e == 0)
        {
            Console.WriteLine("The sum of " + b + " " + e + " is 0");
        }
        else if (c + d == 0)
        {
            Console.WriteLine("The sum of " + c + " " + d + " is 0");
        }
        else if (c + e == 0)
        {
            Console.WriteLine("The sum of " + c + " " + e + " is 0");
        }
        else if (d + e == 0)
        {
            Console.WriteLine("The sum of " + d + " " + e + " is 0");
        }
    }
}

