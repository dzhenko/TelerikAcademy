//Write a program that reverses the words in given sentence.
//	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".

namespace _13.WordReverse
{

    using System;
    using System.Text;

    class WordReverse
    {
        static void Main()
        {
            string originalText = "C# is not C++, not PHP and not Delphi!";
            char lastSighn = originalText[originalText.Length - 1];

            string[] allWords = originalText.Substring(0,originalText.Length-1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < allWords.Length; i++)
            {
                Console.Write(allWords[allWords.Length-1-i]);
                Console.Write(" ");
            }
            Console.WriteLine(lastSighn);
        }
    }
}
