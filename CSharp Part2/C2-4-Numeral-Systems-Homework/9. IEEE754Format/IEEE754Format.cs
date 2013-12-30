//* Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format 
//(the C# type float). Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
//**https://www.youtube.com/watch?v=H79PNQ4Z9HE

using System;

class IEEE754Format
{
    static void Main()
    {
        string input = Console.ReadLine();

        string sighn = "0"; //if it is positive it will remain 0
        int powOfTwo = 0; 
        string mantisa = string.Empty;
        string exponent = string.Empty;

        double rawMantissa = 0.0d;

        if (input[0] == '-')
        {
            sighn = "1"; // generating sighn bit
        }

        exponent = GenerateExponent(input, ref rawMantissa, ref powOfTwo);
        mantisa = GenerateMantissa(input, rawMantissa);

        string answer = sighn + "   " + exponent + "   " + mantisa;

        Console.WriteLine();
        Console.WriteLine(answer);
        Console.WriteLine("-   --------   -----------------------");
        Console.WriteLine("s   exponent          mantissa");
        Console.WriteLine();
    }

    private static string GenerateMantissa(string input, double rawMantissa)
    {
        string mantisaToReturn = null;

        rawMantissa -= 1; 

        while (rawMantissa != 0)
        {
            rawMantissa *= 2;
            if (rawMantissa < 1 )
            {
                mantisaToReturn += "0";
            }
            else
            {
                mantisaToReturn += "1";
                rawMantissa -= 1;
            }
            if (mantisaToReturn.Length == 23)
            {
                return mantisaToReturn;
            }
        }
        if (mantisaToReturn == null)
        {
            mantisaToReturn = new string('0', 23);
        }
        return mantisaToReturn.PadRight(23, '0');
    }

    private static string GenerateExponent(string input, ref double rawMantissa, ref int powOfTwo)
    {
        string exponentToReturn = null;
        int sighn = 1;
        if (input[0] == '-')
        {
            sighn = -1;
        }
        int exponentInDecimal = 127;
        double givvenInput = double.Parse(input);
        givvenInput *= sighn;

        if (givvenInput < 1)
        {
            powOfTwo = 1;
            givvenInput *= 2;
            while (givvenInput<1)
            {
                givvenInput *= 2;
                powOfTwo++;
            }
            exponentInDecimal -= powOfTwo;
        }
        else
        {
            powOfTwo = (int)Math.Log(givvenInput, 2);
            exponentInDecimal += powOfTwo;
            for (int i = 0; i < powOfTwo; i++)
            {
                givvenInput /= 2;
            }
        }
        
        rawMantissa = givvenInput;


        exponentToReturn = Convert.ToString(exponentInDecimal, 2).PadLeft(8,'0');//the padding is not actually needed - just for
                                                                                // cleaner code views
        return exponentToReturn;

    }

    
}

