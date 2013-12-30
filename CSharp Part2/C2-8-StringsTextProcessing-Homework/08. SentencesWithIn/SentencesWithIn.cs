//Write a program that extracts from a given text all sentences containing given word.
//		Example: The word is "in". The text is:
//We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. 
//So we are drinking all the day. We will move out of it in 5 days.
//
//		The expected result is:
//
//We are living in a yellow submarine.
//We will move out of it in 5 days.
//
//		Consider that the sentences are separated by "." and the words – by non-letter symbols.


using System;
using System.Text;

class SentencesWithIn
{
    static void Main()
    {
        //string inputText = Console.ReadLine();
        string inputText = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        //string inputWord = Console.ReadLine();
        string inputWord = "in";

        string[] sentences = inputText.Split(new char[]{'.'},StringSplitOptions.RemoveEmptyEntries);

        foreach (string sentence in sentences)
        {
            string checkingSentence = sentence.ToLower();
            int index = checkingSentence.IndexOf(inputWord.ToLower() + " ");

            if (index > -1)
            {
                Console.Write(sentence.Trim());
                Console.WriteLine(".");
            }
        }
    }
}

