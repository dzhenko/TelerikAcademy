namespace Task1
{
    using System;

    public class Program
    {
        public static string GetDigit(ulong number)
        {
            switch (number)
            {
               case 0: return "LON+"	;
               case 1: return "VK-"	    ;
               case 2: return "*ACAD"	;
               case 3: return "^MIM"	;
               case 4: return "ERIK|"	;
               case 5: return "SEY&"	;
               case 6: return "EMY>>"	;
               case 7: return "/TEL"	;
               case 8: return "<<DON"	;
               default: throw new ArgumentException("Digits should be between 0 and 8");
            }
        }
        public static void Main()
        {
            ulong inputNumber = ulong.Parse(Console.ReadLine());

            string answer = string.Empty;

            if (inputNumber == 0)
            {
                answer = GetDigit(0);
            }

            while (inputNumber != 0)
            {
                answer = GetDigit(inputNumber % 9) + answer;

                inputNumber /= 9;
            }

            Console.WriteLine(answer);
        }
    }
}
