using System;

namespace missCat
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] votes = new int[n];
            for (int i = 0; i < n; i++)
            {
                votes[i] = int.Parse(Console.ReadLine());
            }
            int[] c = new int[10];
            foreach (int vote in votes)
            {
                switch (vote)
                {
                    case 1: c[0]++ ; break;
                    case 2: c[1]++ ; break;
                    case 3: c[2]++ ; break;
                    case 4: c[3]++ ; break;
                    case 5: c[4]++ ; break;
                    case 6: c[5]++ ; break;
                    case 7: c[6]++ ; break;
                    case 8: c[7]++ ; break;
                    case 9: c[8]++ ; break;
                    case 10: c[9]++ ; break;
                }
            }
            int max = c[0];
            for (int i = 0; i < 10; i++)
			{
			    if (max < c[i])
	            {
                    max = c[i];
	            }
			}
            if (max == c[0])
            {
                Console.WriteLine(1);
            }
            else if (max == c[1])
            {
                Console.WriteLine(2);
            }
            else if (max == c[2])
            {
                Console.WriteLine(3);
            }
            else if (max == c[3])
            {
                Console.WriteLine(4);
            }
            else if (max == c[4])
            {
                Console.WriteLine(5);
            }
            else if (max == c[5])
            {
                Console.WriteLine(6);
            }
            else if (max == c[6])
            {
                Console.WriteLine(7);
            }
            else if (max == c[7])
            {
                Console.WriteLine(8);
            }
            else if (max == c[8])
            {
                Console.WriteLine(9);
            }
            else if (max == c[9])
            {
                Console.WriteLine(10);
            }
        }
    }
}
