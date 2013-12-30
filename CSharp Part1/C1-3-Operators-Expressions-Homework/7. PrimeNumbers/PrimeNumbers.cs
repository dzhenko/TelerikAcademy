using System;

class PrimeNumbers
{
    static void Main()
    {
        Console.WriteLine("The Number is -> ");
        int theNumber = Convert.ToInt32(Console.ReadLine());
        if (theNumber % 2 ==0)
        {
            Console.WriteLine("The number is NOT a prime");
        }
        else
        {
            int limit = (int)Math.Pow(theNumber, 0.5);
            bool end = false;
            for (int i = 2; i <= limit+1; i++)
            {
                if (theNumber % i == 0)
                {                    
                    i = 100;
                    end = true;
                }              
            }
            if (end != true)
            {
                Console.WriteLine("The number IS prime");
            }
            else
            {
                Console.WriteLine("The number is NOT prime");
            }
        }
    }
}

