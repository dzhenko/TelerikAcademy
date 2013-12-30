using System;

class Program
{
    static void Main()
    {
        long a = Convert.ToInt64(Console.ReadLine());
        long b = Convert.ToInt64(Console.ReadLine());
        long c = Convert.ToInt64(Console.ReadLine());
        long d = Convert.ToInt64(Console.ReadLine());
        sbyte rows = Convert.ToSByte(Console.ReadLine());
        sbyte columns = Convert.ToSByte(Console.ReadLine());
        long next = a+b+c+d;
        Console.Write(a+" "+b+" "+c+" "+d);
        for (int i = 4; i < columns; i++)
        {
            Console.Write(" ");
            Console.Write(next);                          
            a = b;
            b = c;
            c = d;
            d = next;
            next = a+b+c+d;
        }
        
        Console.WriteLine();
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j <= columns; j++)
            {

                
                Console.Write(next);             
                a = b;
                b = c;
                c = d;
                d = next;
                next = a + b + c + d;
                if (j + 1 <= columns)
                {
                    Console.Write(" ");
                }
            }         
            Console.WriteLine();
        }
    }
}

