using System;

class Quotations
{
    static void Main()
    {
        string WithQ = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(WithQ);
        string WithoutQ = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(WithoutQ);
    }
}

