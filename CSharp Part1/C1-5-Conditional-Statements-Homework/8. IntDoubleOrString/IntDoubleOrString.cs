//Write a program that, depending on the user's choice inputs int, double or string variable. 
//If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
//The program must show the value of that variable as a console output. Use switch statement.


using System;

class IntDoubleOrString
{
    static void Main()
    {
        var userInput = Console.ReadLine();
        int answer = 0;
        int userInt;
        double userDouble = 0;
        string userStr = "";
        if (int.TryParse(userInput,out userInt))
        {
            answer = 1;
        }
        else if (double.TryParse(userInput,out userDouble))
        {
            answer = 2;
        }
        else 
        {
            userStr = userInput;
            answer = 3;
        }
        switch (answer)
        {
            case 1 :
                Console.WriteLine(userInt+1); break ;
            case 2 :
                Console.WriteLine(userDouble+1); break ;
            case 3 :
                Console.WriteLine(userStr +"*"); break;
            default:
                Console.WriteLine("Error!"); break;

        }
    }
}

