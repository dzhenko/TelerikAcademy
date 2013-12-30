//Write a program that creates an array containing all letters from the alphabet (A-Z). 
//Read a word from the console and print the index of each of its letters in the array.


using System;

class AllTheLetters
{
    static void Main()
    {
        char[] letters = new char[26];
        for (int i = 0; i < 26; i++)
        {
            letters[i] = (char)(65+i);
        }
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            Console.WriteLine("The code of letter--> "+input[i]+" <--is exactly  "+Array.IndexOf(letters,input[i]) );
            Console.WriteLine("                     ---               ---");
        }
    }
}

