//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".


using System;
using System.Linq;

class ReverseTheString
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Array.Reverse(input);
        Console.WriteLine(new string(input));
    }
}
