//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;

namespace _20.PalindromesFinder
{
    class PalindromesFinder
    {
        static void Main(string[] args)
        {
            string input = "every time i lalal think I see a palindrom, damn mamam i abba usually dont get any abba chance of finding it again";
            string[] words = input.Split(new char[] {' ',',','.'},StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string word in words)
            {
                bool isPalindrome = true;
                for (int i = 0; i < word.Length/2; i++)
                {
                    if (word[i] != word[word.Length - 1 - i])
                    {
                        isPalindrome = false;
                        break;
                    }
                }
                if ((isPalindrome) && (word.Length>1)) //dont need 1 letter words
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
