using System;

class Program
{
    static void Main()
    {
        here:
        Random generator = new Random();
        int theNumber = generator.Next(1,1000);
        Console.WriteLine("Guess the number");
        int counter = 1;
        int guess;
        while (counter !=0)
        {
            Console.Write("Enter your guess  ");
            guess = int.Parse(Console.ReadLine());
            if (guess > theNumber)
            {
                Console.WriteLine("---------");
                Console.WriteLine("Go down");
                Console.WriteLine("---------");
            }
            else if (guess < theNumber)
            {
                Console.WriteLine("---------");
                Console.WriteLine("Go up");
                Console.WriteLine("---------");
            }
            else
            {
                counter = 0;
            }
        }
        Console.WriteLine("---------");
        Console.WriteLine("You guessed it correctly !!");
        Console.WriteLine("---------");
        Console.WriteLine("It was indeed  "+theNumber);
        Console.WriteLine("---------");
        Console.WriteLine("Y O U    W I N");
        Console.WriteLine("---------");
        Console.WriteLine("Press 1 to start again");
        Console.WriteLine("---------");
        if (int.Parse(Console.ReadLine())==1)
        {
            goto here;
        }
    }
}

