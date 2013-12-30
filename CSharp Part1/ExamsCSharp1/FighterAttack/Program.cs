using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int px1 = int.Parse(Console.ReadLine());
            int py1 = int.Parse(Console.ReadLine());

            int px2 = int.Parse(Console.ReadLine());
            int py2 = int.Parse(Console.ReadLine());

            int Fx = int.Parse(Console.ReadLine());
            int Fy = int.Parse(Console.ReadLine());

            int D = int.Parse(Console.ReadLine());

            int hit100X = Fx + D;
            int hit100Y = Fy;

            int hit75X = Fx + D + 1;
            int hit75Y = Fy;

            int hit50LX = Fx + D ;
            int hit50LY = Fy + 1;

            int hit50RX = Fx + D;
            int hit50RY = Fy - 1;

            int score = 0;

            int checkerX = 0;
            int checkerY = 0;

            checkerX = hit100X;
            checkerY = hit100Y;

            if ((checkerY >= Math.Min(py1,py2)) && checkerY <= Math.Max(py1,py2))
            {
                if ((checkerX >= Math.Min(px1,px2)) && checkerX<= Math.Max(px1,px2))
                {
                    score += 100;
                }
            }

            checkerX = hit75X;
            checkerY = hit75Y;

            if ((checkerY >= Math.Min(py1, py2)) && checkerY <= Math.Max(py1, py2))
            {
                if ((checkerX >= Math.Min(px1, px2)) && checkerX <= Math.Max(px1, px2))
                {
                    score += 75;
                }
            }
            checkerX = hit50LX;
            checkerY = hit50LY;

            if ((checkerY >= Math.Min(py1, py2)) && checkerY <= Math.Max(py1, py2))
            {
                if ((checkerX >= Math.Min(px1, px2)) && checkerX <= Math.Max(px1, px2))
                {
                    score += 50;
                }
            }

            checkerX = hit50RX;
            checkerY = hit50RY;

            if ((checkerY >= Math.Min(py1, py2)) && checkerY <= Math.Max(py1, py2))
            {
                if ((checkerX >= Math.Min(px1, px2)) && checkerX <= Math.Max(px1, px2))
                {
                    score += 50;
                }
            }

            Console.WriteLine(score+"%");
        }
    }
}
