namespace PayChecks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var all = new Employe[int.Parse(Console.ReadLine())];

            for (int i = 0; i < all.Length; i++)
            {
                all[i] = new Employe();
            }

            for (int i = 0; i < all.Length; i++)
            {
                var currentLine = Console.ReadLine();
                for (int j = 0; j < currentLine.Length; j++)
                {
                    if (currentLine[j] == 'Y')
                    {
                        all[i].employees.Add(all[j]);
                    }
                }
            }

            for (int i = 0; i < 12313; i++)
            {
                foreach (var item in all)
                {
                    item.ProduceSalary();
                }
            }

            long answer = 0;

            foreach (var item in all)
            {
                answer += item.salary;
            }

            Console.WriteLine(answer);
        }
    }

    class Employe
    {
        public List<Employe> employees { get; set; }
        public int salary { get; set; }
        public Employe()
        {
            this.employees = new List<Employe>();
            this.salary = 1;
        }
        public override string ToString()
        {
            return this.salary + " " + this.employees.Count + "emps";
        }
        public void ProduceSalary()
        {
            if (this.employees.Count == 0)
            {
                return;
            }
            this.salary = 0;
            foreach (var item in this.employees)
            {
                this.salary += item.salary;
            }
        }
    }
}
