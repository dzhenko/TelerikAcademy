using System;

class NullValues
{
    static void Main()
    {
        int? nullint = null;
        double? nulldouble = null;
        Console.WriteLine(nullint);     //Prints nothing
        Console.WriteLine(nulldouble);  //Prints nothing
        nullint = 5;
        nulldouble = 3.14;
        Console.WriteLine(nullint);     //Prints 5
        Console.WriteLine(nulldouble);  //Prints 3.14
    }
}

