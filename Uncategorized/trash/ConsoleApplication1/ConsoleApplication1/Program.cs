using System;

class Program
{
    static void Main()
    {
        int height = Convert.ToInt32(Console.ReadLine());
        int branches = height - 1;
        for (int i = 1; i <= branches; i++)
        {
            Console.Write(new string('.',branches-i));
            Console.Write(new string('*',i*2-1));
            Console.Write(new string('.',branches-i));
            Console.WriteLine();
        }
        Console.WriteLine(new string('.',branches-1) + '*' +new string('.',branches-1));
    }
}

