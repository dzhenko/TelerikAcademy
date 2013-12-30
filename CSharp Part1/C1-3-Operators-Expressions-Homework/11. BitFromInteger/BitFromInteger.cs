using System;

class BitFromInteger
{
    static void Main()
    {
        Console.WriteLine("The Number is ? ");
        int number = Convert.ToInt32(Console.ReadLine());       
        Console.WriteLine("The Position is ? ");
        int position = Convert.ToInt32(Console.ReadLine());
        int mask = 1 << position;
        int bit = mask & number;
        int result = bit >> position;
        Console.WriteLine("The bit in position "+position+" is exactly "+result);
    }
}

