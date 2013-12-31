using System;

class BitArray64Testing
{
    static void Main()
    {
        BitArray test = new BitArray();

        test[14] = 1;
        test[4] = 1;
        test[1] = 1;
        Console.WriteLine(test);

        test[31] = 1;
        Console.WriteLine(test);

        test[63] = 1;
        Console.WriteLine(test);
    }
}

