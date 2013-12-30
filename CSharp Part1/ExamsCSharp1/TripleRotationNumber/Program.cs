using System;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < 3; i++)
        {
            if (number > 9)
            {
                int lastDigit = number % 10;
                number /= 10;

                string result = lastDigit.ToString() + number.ToString();

                number = int.Parse(result);
            }
        }
        Console.WriteLine(number);
    }
}

