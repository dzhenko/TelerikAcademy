using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> inputList = new List<int>();
        int entrence = 0;
        while (true)
        {
            entrence = int.Parse(Console.ReadLine());
            if (entrence != (-1))
            {
                inputList.Add(entrence);
            }
            else
	        {
                break;
	        }          
        }
        int[,] matrix = new int[inputList.Count, 32];
        string binar = null;
        for (int row = 0; row < inputList.Count; row++)
        {
            binar = Convert.ToString(inputList[row],2).PadLeft(32,'0');
            for (int col = 0; col < 32; col++)
            {

                matrix[row, col] = binar[col] - 48;
            }
        }
        int[,] answer = new int[inputList.Count, 32];
        bool helper = false;
        for (int i = 0; i < inputList.Count; i++)
        {
            helper = false;
            for (int j = 0; j < 30; j++)
            {         
                if (matrix[i,j] == 1 && matrix[i,j+1]== 0)
                {
                    for (int z = j + 2; z < 32; z++)
                    {
                        if (matrix[i, z] == 1)
                        {
                            helper = true;
                        }
                    }
                    if (helper)
                    {
                        answer[i, j + 1] = 1;
                        matrix[i, j + 1] = 1;
                        if (matrix[i, j + 2] == 1)
                        {
                            break;
                        }
                    }
                }
            }
        }


        int printer = 0;
        int number = 0;
        for (int i = 0; i < inputList.Count; i++)
        {
            printer = 0;
            for (int j = 0; j < 32; j++)
            {
                number = int.Parse(answer[i,32 - 1 - j].ToString());
                printer = printer + number*((int)Math.Pow(2, j));
            }
            Console.WriteLine(printer);
        }
    }
}
