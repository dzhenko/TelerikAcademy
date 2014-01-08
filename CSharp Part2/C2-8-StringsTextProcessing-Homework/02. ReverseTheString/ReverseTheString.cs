//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

using System;
using System.Linq;

class ReverseTheString
{
    static void Main()
    {
        //quality of the code = -9 :)
        Console.WriteLine(new string(Console.ReadLine().ToCharArray().Reverse().ToArray()));
    }
}
