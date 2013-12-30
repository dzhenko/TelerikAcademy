using System;

class ChangingBits345
{
    static void Main()          
    {                           
        Console.WriteLine("Enter the number which will have it's bits exchanged -> ");
        int A = Convert.ToInt32(Console.ReadLine());     
        int B = A;        
        int maskcreator1 = 7; //111 number
        int maskA = maskcreator1 << 3;                           //FOR GREATER READABILITY
        Console.WriteLine("A is                                  " + Convert.ToString(A, 2).PadLeft(32, '0'));
        Console.WriteLine("maskA is                              "+Convert.ToString(maskA, 2).PadLeft(32, '0'));
        int firstBitsA = A & maskA;
        Console.WriteLine("first bitsA (A&maskA)                 " + Convert.ToString(firstBitsA, 2).PadLeft(32, '0'));
        int maskB = maskcreator1 << 24;
        Console.WriteLine("B is                                  " + Convert.ToString(B, 2).PadLeft(32, '0'));
        Console.WriteLine("maskB is                              " + Convert.ToString(maskB, 2).PadLeft(32, '0'));
        int firstBitsB = B & maskB;
        Console.WriteLine("first bitsB (B&maskB)                 " + Convert.ToString(firstBitsB, 2).PadLeft(32, '0'));
        int nuller = -117440569; //the number to have 000 only at position 24 25 26 , 3 4 and 5
        Console.WriteLine("nuller                                " + Convert.ToString(nuller, 2).PadLeft(32, '0'));
        int deletednumber = A & nuller;
        Console.WriteLine("A is                                  " + Convert.ToString(A, 2).PadLeft(32, '0'));
        Console.WriteLine("deleted positions 24 25 26 and 3 4 5  " + Convert.ToString(deletednumber, 2).PadLeft(32, '0'));
        var newBitsA = firstBitsA << 21;
        var newBitsB = firstBitsB >> 21;
        var allNewBits = newBitsA | newBitsB;
        Console.WriteLine("A is                                  " + Convert.ToString(A, 2).PadLeft(32, '0'));
        Console.WriteLine("AllNewBits is                         " + Convert.ToString(allNewBits, 2).PadLeft(32, '0'));
        var finalResault = deletednumber | allNewBits;
        Console.WriteLine("positions 3,4,5,24,25,26 are          " + "-----|||" + new string('-', 18) + "|||---");      
        Console.WriteLine("A was ------------------------------->" + Convert.ToString(A, 2).PadLeft(32, '0'));
        Console.WriteLine("Answer------------------------------->" + Convert.ToString(finalResault, 2).PadLeft(32, '0'));
        Console.WriteLine("positions 3,4,5,24,25,26 are          " + "-----|||"+new string ('-',18)+"|||---");
        Console.WriteLine("Decimal numbers were {0} now transformed to {1}",A,finalResault);
        //actually works :)
    }
}

