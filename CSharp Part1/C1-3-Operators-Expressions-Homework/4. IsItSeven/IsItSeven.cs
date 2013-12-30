using System;

class IsItSeven
{
    static void Main()
    {
        Console.WriteLine("The number is? ");
        string number = Convert.ToString(Console.ReadLine());
        int lenght = number.Length;
        int numberInt = Convert.ToInt32(number);
        int position = lenght - 3;
        int digit = (numberInt / (int)Math.Pow(10, 3 - 1)) % 10;  //calculates the digit by dividing by 10^2 (for the third digit)
        Console.WriteLine(digit==7);
    }       
}

