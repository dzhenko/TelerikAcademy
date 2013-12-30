//Write a program for extracting all email addresses from given text. All substrings that match the format 
//<identifier>@<host>…<domain> should be recognized as emails.


namespace _18.EmailExtractor
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class EmailExtractor
    {
        static void Main()
        {
            string input = "dada@telerik.com is a very hardly known email adress not as popular as ivan@gmail.com who is using PC and the email working@gmail.com dude";
            foreach (var mail in Regex.Matches(input, @"\w+@\w+\.\w+"))
            {
                Console.WriteLine(mail);
            }
        }
    }
}
