//Write a program to calculate n! for each n in the range[1..100]. Hint: Implement first a method
//that multiplies a number represented as array of digits by given integer number.

namespace Methods10
{
    using System;
    using System.Text;

    class FactorielMethod
    {
        public static string NumberMultiplyer(string number, int digit)
        {
            string result = null;
            int carry = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                int currDigit = int.Parse(number[i].ToString());
                int currProduct = currDigit * digit;
                if (currProduct + carry < 10)
                {
                    result = (currProduct + carry) + result;
                }
                else
                {
                    result = ((currProduct + carry) % 10) + result;
                    carry = (currProduct + carry) / 10;
                }
            }
            if (carry != 0)
            {
                result = carry + result;
            }
            return result;
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string answer = "1";

            for (int i = 2; i <= n; i++) // 0 and 1 ! are 1
            {
                answer = NumberMultiplyer(answer, i);
            }
            Console.WriteLine(answer);
        }
    }
}