using System;

class TrapezoidsArea
{
    static void Main()
    {
        Console.WriteLine("a -> ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("b -> ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("h -> ");
        int h = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The area is "+((a+b)/2)*h);
    }
}

