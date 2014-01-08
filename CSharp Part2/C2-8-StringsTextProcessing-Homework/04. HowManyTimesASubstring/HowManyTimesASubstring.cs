//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
//		Example: The target substring is "in". The text is as follows:
//We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. 
//So we are drinking all the day. We will move out of it in 5 days.
//Answer - 9



using System;
using System.Linq;

class HowManyTimesASubstring
{
    static void Main()
    {
        //string input = Console.ReadLine(); ORIGINAL
        string input = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight.So we are drinking all the day. We will move out of it in 5 days.";
        //for easier testing
        input = input.ToLower();
        int answer = 0;

        int indexer = input.IndexOf("in",0);
        while (indexer!=-1)
        {
            answer++;
            indexer = input.IndexOf("in", indexer + 1);
        }


        Console.WriteLine(answer);
    }
}