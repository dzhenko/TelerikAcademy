//Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...


using System;

class OnePlus12Minus13Etc
{
    static void Main()
    {
        double a = 1.0;
        int sighn = -1;
        double sum = 1.5;
        int denominator = 2;
        double oldsum = 0;
       // int counter = 0;
        while ((Math.Round(sum, 3)) != (Math.Round(oldsum, 3)))
        {
            oldsum = sum;
            denominator = (denominator + 1);
            a = 1.0 / denominator;
            sum = sum + a*(sighn);
            sighn = sighn * (-1);
           // counter++; // I was just curious how many iterations it did 
        }
        Console.WriteLine(Math.Round(sum,3));
       // Console.WriteLine(counter); //again not necesary
    }
}

