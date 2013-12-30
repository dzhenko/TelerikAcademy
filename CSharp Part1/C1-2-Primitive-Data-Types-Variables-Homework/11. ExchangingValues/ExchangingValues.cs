using System;

class ExchangingValues
{
    static void Main()
    {
        int x = 5;
        int y = 10;
        Console.WriteLine("In the beggining x is " + x + " and y is " + y);
        x = x + y;  //without using a 3rd variable
        y = x - y;
        x = x - y;
        Console.WriteLine("In the end x is " + x + " and y is " + y);
    }
}

