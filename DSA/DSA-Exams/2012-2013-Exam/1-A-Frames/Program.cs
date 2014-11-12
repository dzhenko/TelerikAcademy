using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_A_Frames
{
    class Program
    {
        static List<FrameJoint> allCombos = new List<FrameJoint>();
        static bool[] used;

        static void Main(string[] args)
        {
            var allCount = int.Parse(Console.ReadLine());

            var frames = new Frame[allCount];

            for (int i = 0; i < allCount; i++)
            {
                frames[i] = new Frame(Console.ReadLine());
            }

            used = new bool[allCount];

            Console.WriteLine();
        }

        private static void DFS(Frame[] frames, int index)
        {
            if (index == frames.Length)
            {
                return;
            }

            
        }

        static void PermuteRep(Frame[] arr, int start, int n)
        {
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left].Value != arr[right].Value)
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
    }

    class Frame
    {
        public Frame(string line)
        {
            this.A = int.Parse(line[0].ToString());
            this.B = int.Parse(line[2].ToString());
        }

        public int A { get; set; }

        public int B { get; set; }

        public int Value
        {
            get
            {
                return this.A * 10 + this.B;
            }
        }

        public override string ToString()
        {
            return "" + this.A + this.B;
        }

        public void Switch()
        {
            var old = this.A;
            this.A = this.B;
            this.B = old;
        }

        public bool AreSame
        {
            get
            {
                return this.A == this.B;
            }
        }
    }

    class FrameJoint : IComparable<FrameJoint>
    {
        public FrameJoint(IEnumerable<Frame> arrayOfFrames)
        {
            this.Value = long.Parse(string.Join("", arrayOfFrames));
        }

        public long Value { get; set; }

        public int CompareTo(FrameJoint other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }

    class FrameCompararer : IComparer<Frame[]>
    {
        public int Compare(Frame[] x, Frame[] y)
        {
            return x.Sum(f => f.Value).CompareTo(y.Sum(f => f.Value));
        }
    }
}
