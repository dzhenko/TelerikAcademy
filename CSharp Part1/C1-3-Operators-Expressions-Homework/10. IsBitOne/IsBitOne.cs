using System;

class IsBitOne
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
        bool answer = (result == 1);
        Console.WriteLine(answer);
        Console.WriteLine("The number is                          " + Convert.ToString(number, 2).PadLeft(32, '0'));
    }
}

