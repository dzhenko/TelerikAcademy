using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _1_Frames
{
    public class Program
    {
        static StringBuilder sb = new StringBuilder();
        static List<Frame[]> gigabag = new List<Frame[]>();

        static void Main()
        {
            var framesCount = int.Parse(Console.ReadLine());

            OrderedBag<Frame> bag = new OrderedBag<Frame>();

            for (int i = 0; i < framesCount; i++)
            {
                var line = Console.ReadLine().Split();
                if (line[0].CompareTo(line[1]) < 0)
                {
                    bag.Add(new Frame(line[0], line[1]));
                }
                else
                {
                    bag.Add(new Frame(line[1], line[0]));
                }
            }

            var array = bag.ToArray();

            PermuteRep(array, 0, framesCount);

            Console.WriteLine(gigabag.Count);

            gigabag.Sort(new FramArrCompararer());

            foreach (var el in gigabag)
            {
                sb.AppendLine(string.Join(" | ", el.Select(e => string.Format("({0}, {1})", e.ToString()[0], e.ToString()[1]))));
            }

            Console.Write(sb.ToString());
        }

        static void PermuteRep(Frame[] arr, int start, int n)
        {
            MakePermuts(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (!arr[left].IsLike(arr[right]))
                    {
                        var old = arr[left];
                        arr[left] = arr[right];
                        arr[right] = old;

                        PermuteRep(arr, left + 1, n);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        private static void MakePermuts(Frame[] arr)
        {
            Switch(arr, 0);
        }

        private static void Switch(Frame[] arr, int index)
        {
            if (index == arr.Length)
            {
                gigabag.Add(arr.ToArray());
                return;
            }

            Switch(arr, index + 1);

            if (!arr[index].Mirror)
            {
                arr[index].Switch();

                Switch(arr, index + 1);

                arr[index].Switch();
            }
        }
    }

    public struct Frame : IComparable<Frame>
    {
        public Frame(string first, string second) : this()
        {
            this.First = first;
            this.Second = second;
        }

        public long Value { get { return long.Parse(this.First) * 10 + long.Parse(this.Second); } }

        public string First { get; set; }

        public string Second { get; set; }

        public bool Mirror
        {
            get
            {
                return this.First == this.Second;
            }
        }

        public void Switch()
        {
            var old = this.First;
            this.First = this.Second;
            this.Second = old;
        }

        public int CompareTo(Frame other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return this.First + this.Second;
        }

        public bool IsLike(Frame other)
        {
            return this.First == other.First && this.Second == other.Second;
        }
    }

    public class FramArrCompararer : IComparer<Frame[]>
    {

        public int Compare(Frame[] x, Frame[] y)
        {
            return long.Parse(string.Join("", x)).CompareTo(long.Parse(string.Join("", y)));
        }
    }
}
