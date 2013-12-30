using System;

class BitsExchanger
{
    static void Main()
    {
        //input
        Console.WriteLine("The Number is -> ");
        uint theNumber = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine("The number is                          " + Convert.ToString(theNumber, 2).PadLeft(32, '0'));
        Console.WriteLine("From which bit to beguin the exchange?(start count from 0!)");
        int bitA = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("To which bit do I start the exchange?(start count from 0!)");
        int bitB = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many bits do I change with the first bits?(number must be lower than the position gap");
        int k = Convert.ToInt32(Console.ReadLine());
        if (k > (Math.Max(bitA,bitB)-Math.Min(bitA,bitB)))
        {
            Console.WriteLine("Sorry the gap is bigger than the position of bits");
            Environment.Exit(1); // Ends the program
        }

        //We copy the first wanted Bits
        string maskAString = new string('1',k).PadLeft(32, '0');
        uint maskAnum = Convert.ToUInt32(maskAString,2);
        uint maskAReady = maskAnum << bitA;         
        Console.WriteLine("The number is                           " + Convert.ToString(theNumber, 2).PadLeft(32, '0'));
        Console.WriteLine("the mask is                             " + Convert.ToString(maskAReady, 2).PadLeft(32, '0'));
        uint bitsForAReady = maskAReady & theNumber;
        Console.WriteLine("The copyed bits are                     " + Convert.ToString(bitsForAReady, 2).PadLeft(32, '0'));
        Console.WriteLine("The copyed bits are                     " + new string (' ',(32-bitA-k)) + new string ('|',k));
        Console.WriteLine();

        //We copy the second wanted Bits
        string maskBString = new string('1', k).PadLeft(32, '0');
        uint maskBnum = Convert.ToUInt32(maskBString, 2);
        uint maskBReady = maskBnum << bitB;
        Console.WriteLine("The number is                           " + Convert.ToString(theNumber, 2).PadLeft(32, '0'));
        Console.WriteLine("the mask is                             " + Convert.ToString(maskBReady, 2).PadLeft(32, '0'));
        uint bitsForBReady = maskBReady & theNumber;
        Console.WriteLine("The copyed bits are                     " + Convert.ToString(bitsForBReady, 2).PadLeft(32, '0'));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitB - k)) + new string('|', k));
        Console.WriteLine();

        //the rotation
        uint theFinalMask = 0;
        if (bitA < bitB)
        {
            uint finalMaskA = bitsForAReady << bitB-bitA;
            uint finalMaskB = bitsForBReady >> bitB - bitA;
            Console.WriteLine();
            Console.WriteLine("The shifted bits A are                  " + Convert.ToString(finalMaskA, 2).PadLeft(32, '0'));
            Console.WriteLine("The shifted bits B are                  " + Convert.ToString(finalMaskB, 2).PadLeft(32, '0'));
            theFinalMask = finalMaskA | finalMaskB;                   
            Console.WriteLine("The final mask is                       " + Convert.ToString(theFinalMask, 2).PadLeft(32, '0'));
        }
        else
        {
            uint finalMaskA = bitsForAReady >> bitA-bitB;
            uint finalMaskB = bitsForBReady << bitA-bitB;
            Console.WriteLine();                                       
            Console.WriteLine("The shifted bits A are                  " + Convert.ToString(finalMaskA, 2).PadLeft(32, '0'));
            Console.WriteLine("The shifted bits B are                  " + Convert.ToString(finalMaskB, 2).PadLeft(32, '0'));
            theFinalMask = finalMaskA | finalMaskB;                   
            Console.WriteLine("The final mask is                       " + Convert.ToString(theFinalMask, 2).PadLeft(32, '0'));
        }
            
        //preparing the number
        uint deleteCreator = maskAReady | maskBReady;
        deleteCreator = ~deleteCreator;
        Console.WriteLine();
        Console.WriteLine("The deleter is                          " + Convert.ToString(deleteCreator, 2).PadLeft(32, '0'));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitA - k)) + new string('|', k));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitB - k)) + new string('|', k));

        //the magic (final transformation)
        uint helpNumber = theNumber & deleteCreator;
            
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitA - k)) + new string('|', k));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitB - k)) + new string('|', k));
        Console.WriteLine("The deleted number is                   " + Convert.ToString(helpNumber, 2).PadLeft(32, '0'));
        uint finalNumber = helpNumber | theFinalMask;
            
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitA - k)) + new string('|', k));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitB - k)) + new string('|', k));
        Console.WriteLine("The number W A S   -------------------->" + Convert.ToString(theNumber, 2).PadLeft(32, '0'));
        Console.WriteLine("The Final number is-------------------->" + Convert.ToString(finalNumber, 2).PadLeft(32, '0'));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitA - k)) + new string('|', k));
        Console.WriteLine("The copyed bits are                     " + new string(' ', (32 - bitB - k)) + new string('|', k));

        //some order in the console output
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("The original number was (IN DECIMAL)    " + theNumber);
        Console.WriteLine("The final number is (IN DECIMAL)        " + finalNumber);           
    }
}

