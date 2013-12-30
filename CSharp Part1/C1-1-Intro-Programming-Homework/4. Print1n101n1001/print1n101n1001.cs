using System;

class print1n101n1001
{
    static void Main()
    {
        var number = 1;
        Console.WriteLine(number);
        for (int i = 2; i < 4; i++) // 10 to the power of 1 is 10 wich will give 11 as a result so we begin at i = 2
        {
            Console.WriteLine(number + Math.Pow(10,i)); 
        }
    }
}

