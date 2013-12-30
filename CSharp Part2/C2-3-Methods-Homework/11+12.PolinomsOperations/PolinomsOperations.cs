//Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
//		x2 + 5 = 1x2 + 0x + 5  5 0 1
//Extend the program to support also subtraction and multiplication of polynomials.


namespace _11_12.PolinomsAddSubstractMulty
{
    using System;

    class PolinomsAddSubstractMulty
    {
        public static void Main()
        {
            int[] polinom1 = EnterPolinom();
            int[] polinom2 = EnterPolinom();

            int[] resultAddition = PolinomOperation(polinom1, polinom2, "Add");
            int[] resultSubstraction = PolinomOperation(polinom1, polinom2, "Substract");
            int[] resultMulty = PolinomOperation(polinom1, polinom2, "Multiply");

            PrintPolinom(resultAddition);

            PrintPolinom(resultSubstraction);

            PrintPolinom(resultMulty);
        }

        public static int[] EnterPolinom()
        {
            Console.Write("Enter highest power of x : ");
            int n = int.Parse(Console.ReadLine());

            int[] answer = new int[n + 1];
            for (int i = 0; i < answer.Length; i++)
            {
                Console.Write("Enter the coeficient before x^{0} : ", i);
                answer[i] = int.Parse(Console.ReadLine());
            }
            return answer;
        }

        public static void PrintPolinom(int[] polinom)
        {
            for (int i = polinom.Length - 1; i > 0; i--)//intentionally missing the last element
            {
                if (polinom[i] != 0)
                {
                    Console.Write("({0})x^{1} + ", polinom[i], i);
                }
            }
            Console.WriteLine("({0})", polinom[0]);
        }

        public static int[] PolinomOperation(int[] polinom1, int[] polinom2, string operation)
        {
            int[] answer;

            if (polinom1.Length >= polinom2.Length)
            {
                answer = new int[polinom1.Length];
                Array.Copy(polinom1, answer, polinom1.Length);
            }
            else
            {
                answer = new int[polinom2.Length];
                Array.Copy(polinom2, answer, polinom2.Length);
            }

            int operationsToBePerformed = Math.Min(polinom1.Length, polinom2.Length);

            if (operation == "Add")
            {
                for (int i = 0; i < operationsToBePerformed; i++)
                {
                    answer[i] = polinom1[i] + polinom2[i];
                }
            }
            else if (operation == "Substract")
            {
                for (int i = 0; i < operationsToBePerformed; i++)
                {
                    answer[i] = polinom1[i] - polinom2[i];
                }
            }
            else if (operation == "Multiply")
            {
                for (int i = 0; i < operationsToBePerformed; i++)
                {
                    answer[i] = polinom1[i] * polinom2[i];
                }
            }
            else
            {
                Console.WriteLine("Wrong operation !");
                Environment.Exit(0);
            }

            return answer;


        }
    }
}