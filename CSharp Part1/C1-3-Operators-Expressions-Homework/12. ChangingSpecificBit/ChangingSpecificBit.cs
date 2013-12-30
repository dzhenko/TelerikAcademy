using System;

class ChangingSpecificBit
{
    static void Main()
    {
        Console.WriteLine("The Number is ? ");
        int number = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The number is                          " + Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("The Position is ? ");
        int position = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The Value is (0 ir 1) ? ");
        int value = Convert.ToInt32(Console.ReadLine());
        while (value != 0 && value !=1)
        {
            Console.WriteLine("The value MUST be 0 or 1 ? ");
            value = Convert.ToInt32(Console.ReadLine());
        }
        if (value == 1)
        {
            int mask = 1 << position;
            number = number | mask;
        }
        else
        {
            int mask = 1 << position;
            mask = ~mask;
            number = number & mask;
        }
        Console.WriteLine("The newnumber is                       " + Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(number);
    }
}

