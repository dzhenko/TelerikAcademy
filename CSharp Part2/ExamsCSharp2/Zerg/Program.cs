using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        ulong lenght = (ulong)input.Length / 4;
        ulong counter = (ulong)Math.Pow(15,lenght-1);
        ulong answer = 0;
        string[] words = new string[lenght];

        for (ulong i = 0; i < lenght; i++)
		{
            words[i] = words[i] + input[(int)i * 4] + input[(int)i * 4 + 1] + input[(int)i * 4 + 2] + input[(int)i * 4 + 3];
		}
        foreach (string word in words)
	    {
            switch (word)
            {
                case "Rawr" : answer = answer + (0*counter) ;break;
                case "Rrrr" : answer = answer + (1*counter) ;break;
                case "Hsst" : answer = answer + (2*counter) ;break;
                case "Ssst" : answer = answer + (3*counter) ;break;
                case "Grrr" : answer = answer + (4*counter) ;break;
                case "Rarr" : answer = answer + (5*counter) ;break;
                case "Mrrr" : answer = answer + (6*counter) ;break;
                case "Psst" : answer = answer + (7*counter) ;break;
                case "Uaah" : answer = answer + (8*counter) ;break;
                case "Uaha" : answer = answer + (9*counter) ;break;
                case "Zzzz" : answer = answer + (10*counter) ;break;
                case "Bauu" : answer = answer + (11*counter) ;break;
                case "Djav" : answer = answer + (12*counter) ;break;
                case "Myau" : answer = answer + (13*counter) ;break;
                case "Gruh" : answer = answer + (14*counter) ;break;
            }
            counter = counter / 15;
	    }
        Console.WriteLine(answer);
    }
}