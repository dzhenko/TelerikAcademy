namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Salaries
    {
        static ulong all;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var tree = new List<int>[n];
            var payrolls = new ulong[n];

            for (int i = 0; i < n; i++)
            {
                tree[i] = new List<int>();

                var line = Console.ReadLine();

                for (int j = 0; j < n; j++)
                {
                    if (line[j] == 'Y')
                    {
                        tree[i].Add(j);
                    }
                }

                if (tree[i].Count == 0)
                {
                    payrolls[i] = 1;
                    all++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (payrolls[i] == 0)
                {
                    payrolls[i] = GetPayRoll(i, tree, payrolls);
                }
            }

            Console.WriteLine(all);
        }

        private static ulong GetPayRoll(int index, List<int>[] tree, ulong[] payrolls)
        {
            ulong sum = 0;
            foreach (var emp in tree[index])
            {
                if (payrolls[emp] == 0)
                {
                    payrolls[emp] = GetPayRoll(emp, tree, payrolls);
                }

                sum += payrolls[emp];
            }

            payrolls[index] = sum;

            all += sum;
            return sum;
        }
    }
}
