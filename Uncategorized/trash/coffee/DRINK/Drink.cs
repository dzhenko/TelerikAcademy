using System;

    class Drink
    {
        static void Main()
        {
            int rounds = Convert.ToInt32(Console.ReadLine());
            int[] dNumbers;
            dNumbers = new int[rounds];
            for (int i = 0; i < rounds; i++)
            {
                dNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < rounds; i++)
            {
                int basicnumber = Convert.ToInt32(dNumbers[i]);
                string strnumber = Convert.ToString(basicnumber);
                int intnumber = Convert.ToInt32(strnumber);
                if (strnumber.Length % 2 == 0) //even
                {
                    int halfsize = strnumber.Length / 2;
                    string numbers = strnumber;
                    int[] intArray = new int[numbers.Length];
                    for (int j = 0; i < numbers.Length; j++)
                         {
                         intArray[i] = int.Parse(numbers[i]);
                         }
                    
                }
                else  //odd
                {

                }
                
                
            }

        }
    }

