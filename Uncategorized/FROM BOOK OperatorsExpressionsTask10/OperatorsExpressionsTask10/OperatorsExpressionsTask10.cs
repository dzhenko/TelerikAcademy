using System;

class Task10
{
    static void Main()
    {
        Console.WriteLine("The number is? ");
        int numberInt = Convert.ToInt32(Console.ReadLine());
        int numberCopy = numberInt;
        string Size = Convert.ToString(numberInt);
        int[] digits = new int[Size.Length];
        for (int i = 1; i <= Size.Length; i++)
        {
            digits[i - 1] = numberCopy % 10;
            numberCopy = numberCopy / 10;
        }
        int a = digits[3];
        int b = digits[2];
        int c = digits[1];
        int d = digits[0];
        Console.WriteLine(a+" "+b+" "+c+" "+d);
        Console.WriteLine(a+b+c+d);
        Console.WriteLine(d + " " + c + " " + b + " " + a);
        Console.WriteLine(d + " " + a + " " + b + " " + c);
        Console.WriteLine(a + " " + c + " " + b + " " + d);
    }
}

