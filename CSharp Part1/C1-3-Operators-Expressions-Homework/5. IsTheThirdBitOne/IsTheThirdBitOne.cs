using System;

class IsTheThirdBitOne
{
    static void Main()
    {
        Console.WriteLine("The Number is -> ");
        int theNumber = Convert.ToInt32(Console.ReadLine());
        int mask = 1 << 3;
        int result = mask & theNumber;
        result = result >> 3;
        Console.WriteLine("The bit is "+result);
        Console.WriteLine("The number is " + Convert.ToString(theNumber, 2).PadLeft(32, '0')); //just to check
    }
}

