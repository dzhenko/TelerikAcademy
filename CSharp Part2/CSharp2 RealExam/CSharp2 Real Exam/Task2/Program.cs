namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    public class Program
    {
        public static int firstStepCounter = 1;

        public static List<int> rabbits = new List<int>();

        public static BigInteger multiplication = 1;

        public static StringBuilder sb = new StringBuilder();

        public static int addition = 0;

        public static void Main()
        {
            ReadInput();

            while (true)
            {
               Solver();
            }
        }

        private static void Solver()
        {
            int rabitsToTakeFirst = 0;

            if (firstStepCounter > rabbits.Count)
            {
                Console.Write(rabbits[0]);//1place
                for (int i = 1; i < rabbits.Count; i++)
                {
                    Console.Write(" ");
                    Console.Write(rabbits[i]);
                }
                Console.WriteLine();
                Environment.Exit(0);
            }

            for (int i = 0; i < firstStepCounter; i++)
            {
                rabitsToTakeFirst += rabbits[i];
            }

            if (rabitsToTakeFirst + firstStepCounter > rabbits.Count)
            {
                Console.Write(rabbits[0]);//1place
                for (int i = 1; i < rabbits.Count; i++)
                {
                    Console.Write(" ");
                    Console.Write(rabbits[i]);
                }
                Console.WriteLine();
                Environment.Exit(0);
            }

            addition = 0;
            multiplication = 1;

            for (int i = firstStepCounter; i < rabitsToTakeFirst+firstStepCounter; i++)
            {
                addition += rabbits[i];
                multiplication *= rabbits[i];
            }

            sb.Clear();

            sb.Append(addition);
            sb.Append(multiplication);

            for (int i = rabitsToTakeFirst+firstStepCounter; i < rabbits.Count; i++)
            {
                sb.Append(rabbits[i]);
            }

            sb.Replace("0", "");
            sb.Replace("1", "");

            firstStepCounter++;

            List<int> newRabits = new List<int>();

            for (int i = 0; i < sb.Length; i++)
            {
                newRabits.Add(int.Parse(sb[i].ToString()));
            }

            rabbits = newRabits;
        }

        private static void ReadInput()
        {
            string currentLine = Console.ReadLine();

            while (currentLine != "END")
            {
                rabbits.Add(int.Parse(currentLine));

                currentLine = Console.ReadLine();
            }
        }
    }
}
