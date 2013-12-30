using System;

class Drink
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());
        int[] number = new int[rounds];
        string inputtemp = null;
        for (int i = 0; i < rounds; i++)
        {
            inputtemp = Console.ReadLine();
            number[i] = int.Parse(inputtemp);
        }
        int Mitko = 0;
        int Vladko = 0;
        int total = 0;
        string tempnumber = null;
        for (int round = 0; round < rounds; round++)
        {
            if (number[round] < 0)
            {
                number[round] = number[round] * (-1);
            }
            tempnumber = number[round].ToString();
            if (tempnumber.Length % 2 == 0)             //the number is even
            {
                for (int i = 0; i < tempnumber.Length/2; i++)
                {
                    Mitko = Mitko + Convert.ToInt32(tempnumber[i].ToString());
                    Vladko = Vladko + Convert.ToInt32(tempnumber[tempnumber.Length / 2 + i].ToString());
                    total = total + Convert.ToInt32(tempnumber[i].ToString()) + Convert.ToInt32(tempnumber[tempnumber.Length / 2 + i].ToString());
                }        
            }

            else                                        //uneven
            {
                for (int i = 0; i < (tempnumber.Length / 2) + 1; i++)
                {
                    Mitko = Mitko + Convert.ToInt32(tempnumber[i].ToString());
                    Vladko = Vladko + Convert.ToInt32(tempnumber[tempnumber.Length / 2 + i].ToString());
                    total = total + Convert.ToInt32(tempnumber[i].ToString()) + Convert.ToInt32(tempnumber[tempnumber.Length / 2 + i].ToString());
                }
            }               
        }
        if (Mitko > Vladko)
        {
            Console.WriteLine("M " + (Mitko- Vladko));
        }
        else if (Mitko < Vladko)
        {
            Console.WriteLine("V "+(Vladko - Mitko));
        }
        else if (Mitko == Vladko)
        {
            Console.WriteLine("No "+total);
        }
    }
}
