using System;

class Hangman
{
    static void Main(string[] args)
    {
        string theWord = "champion";
        int choice = 0;
        int mistakes = 0;
        char guess;
        bool flag = true;
        int counter = 8;
        while (counter!=0)
        {
            flag = true;
            Console.WriteLine("Choose an option - 1 to view your mistakes, 2 to guess a letter, 3 - to exit");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 3)
                {
                    Environment.Exit(0);
                    flag = false;
                }
                else if (choice == 1)
                {
                    Console.WriteLine("You have made " + mistakes + " mistakes");
                    flag = false;
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter a letter");
                    guess = Convert.ToChar(Console.ReadLine());
                    for (int i = 0; i < theWord.Length; i++)
                    {
                        if (guess == theWord[i])
                        {
                            Console.WriteLine("Correct");
                            counter--;
                            Console.Write(counter);
                            Console.WriteLine(" letters left");
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        Console.WriteLine("You didn't guess");
                        mistakes++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a number (1/2/3)");
            }
        }
        Console.WriteLine("Y O U   W I N");
        Console.WriteLine("...and with only "+mistakes);
    }
}

