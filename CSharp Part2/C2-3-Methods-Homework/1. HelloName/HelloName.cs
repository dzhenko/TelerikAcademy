//Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). 
//Write a program to test this method.


using System;

class HelloName
{
    static void PrintName(string name)
    {
        Console.WriteLine("Hello "+name+" !");
    }

    static void Main()                                      
    {                                                       
        Console.Write("Enter your name : ");                
        string inputName = Console.ReadLine();              
        PrintName(inputName);                               
    }
}

