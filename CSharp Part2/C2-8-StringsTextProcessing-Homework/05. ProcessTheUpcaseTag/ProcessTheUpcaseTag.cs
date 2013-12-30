//You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
//The tags cannot be nested. Example:
//We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
//		The expected result:
//We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.

using System;
using System.Text;

class ProcessTheUpcaseTag
{
    static void Main()
    {
        string input = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";//easier testing
        // string input = Console.ReadLine(); //original
        StringBuilder sb = new StringBuilder();
        int toUpper = -1;//checks if we have to enter UPPERCASE MODE
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '<')
            {
                i++;
                toUpper = toUpper * (-1); // First < - so its an opening tag - so start UPPER
                while (input[i] != '>') // disregard all of the tag's content
                {
                    i++;
                }
            }
            else
            {
                if (toUpper == 1)
                {
                    sb.Append(input[i].ToString().ToUpper());//ToAnswer().ToProgram().ToDo().ToFindMeaningInLifeNow(DateTime.Now()) .... :)
                }                                              //can't pass my quality code course that way .. can I :)
                else
                {
                    sb.Append(input[i]);
                }
                
            }
        }
        Console.WriteLine(sb.ToString());
    }
}