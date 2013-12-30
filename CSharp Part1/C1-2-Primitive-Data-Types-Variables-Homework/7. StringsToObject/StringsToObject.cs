using System;

class StringsToObject
{
    static void Main()
    {
        string first = "Hello";
        string second = "World";
        object all = first + " " + second;
        string both = (string)all;
    }
}

