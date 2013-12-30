using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        string numberstring = number.ToString();
        string helperstr = null;
        int helper1 = 0;
        int helper2 = 0;
        int helper3 = 0;
        int helper4 = 0;

        int d1 = int.Parse(numberstring[0].ToString());
        int d2 = int.Parse(numberstring[1].ToString());
        int d3 = int.Parse(numberstring[2].ToString());
        int d4 = int.Parse(numberstring[3].ToString());

        if (bulls + cows > 4 || bulls > 4 || cows > 4)      //imposible
        {
            Console.WriteLine("No");
        }
        else if (bulls == 3)                //3
        {
            Console.WriteLine("No");
        }
        else if (bulls ==4)                 //4
        {
            Console.WriteLine(number);
        }

        else if (bulls == 0)                //0
        {
            if (cows == 0)
            {
                for (int i = 1111; i <= 9999; i++)
                {
                    helperstr = i.ToString();
                    helper1 = int.Parse(helperstr[0].ToString());
                    helper2 = int.Parse(helperstr[1].ToString());
                    helper3 = int.Parse(helperstr[2].ToString());
                    helper4 = int.Parse(helperstr[3].ToString());

                    if ( (d1 != helper1 && d1 != helper2 && d1 != helper3 && d1 != helper4 ) &&
                        (d2 != helper1 && d2 != helper2 && d2 != helper3 && d2 != helper4 ) &&
                        (d3 != helper1 && d3 != helper2 && d3 != helper3 && d3 != helper4 ) &&
                        (d4 != helper1 && d4 != helper2 && d4 != helper3 && d4 != helper4 ) )

                    {
                        Console.Write(i);
                        Console.Write(" ");
                    }
                }
            }
            if (cows == 1)
            {
                for (int i = 1111; i <= 9999; i++)
                {
                    helperstr = i.ToString();
                    helper1 = int.Parse(helperstr[0].ToString());
                    helper2 = int.Parse(helperstr[1].ToString());
                    helper3 = int.Parse(helperstr[2].ToString());
                    helper4 = int.Parse(helperstr[3].ToString());

                    if ((d1 != helper1 && d1 == helper2 && d1 != helper3 && d1 != helper4) &&
                        (d2 != helper1 && d2 != helper2 && d2 != helper3 && d2 != helper4) &&
                        (d3 != helper1 && d3 != helper2 && d3 != helper3 && d3 != helper4) &&
                        (d4 != helper1 && d4 != helper2 && d4 != helper3 && d4 != helper4))
                    {
                        Console.Write(i);
                        Console.Write(" ");
                    }
                }
            }
        }
    }
}

