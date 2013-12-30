using System;

class Ageafter10years
{
    static void Main()
    {
        int age;
        Console.WriteLine("What is your current age? (please enter a number)");
        string input1 = Console.ReadLine();  
        if (Int32.TryParse(input1, out age))     //checks if the entered value is a number or sth else
        {       
            Console.WriteLine("You will be exactly " + (age+10) + " years old after 10 years");
        }
        else
        {
            Console.WriteLine("You have to enter a number - this is your last attempt!");   //repetition of the program
            string input2 = Console.ReadLine();
            if (Int32.TryParse(input2, out age))    //checks for int value again
            {       
                Console.WriteLine("You will be exactly " + (age+10) + " years old after 10 years");
            }
            else
            {
                Console.WriteLine("Sorry ... no information for you!");     //got a little carried away .. but it does the job
            }
        }
    }
}

