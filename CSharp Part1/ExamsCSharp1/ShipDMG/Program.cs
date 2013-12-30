using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//SX1, SY1, SX2, SY2, H, CX1, CY1, CX2, CY2, CX3 CY3
namespace ShipDMG
{
    class Program
    {
        static void Main()
        {
            int SX1 = int.Parse(Console.ReadLine());
            int SY1 = int.Parse(Console.ReadLine());

            int SX2 = int.Parse(Console.ReadLine());
            int SY2 = int.Parse(Console.ReadLine());

            int H = int.Parse(Console.ReadLine());

            int CX1 = int.Parse(Console.ReadLine());
            int CY1 = int.Parse(Console.ReadLine());

            int CX2 = int.Parse(Console.ReadLine());
            int CY2 = int.Parse(Console.ReadLine());

            int CX3 = int.Parse(Console.ReadLine());
            int CY3 = int.Parse(Console.ReadLine());

            int CHitX1 = CX1;
            int CHitX2 = CX2;
            int CHitX3 = CX3;

            int DMG = 0;

            int CHitY1 = 2 * H - CY1;
            int CHitY2 = 2 * H - CY2;
            int CHitY3 = 2 * H - CY3;

            int hitmeX = CHitX1;
            int hitmeY = CHitY1;

            if ( (hitmeX >= Math.Min(SX1,SX2)) && (hitmeX <= Math.Max(SX1,SX2)) )
            {
                if (hitmeX == SX1 || hitmeX == SX2)
                {
                    if ( (hitmeY >= Math.Min(SY1,SY2)) && (hitmeY <= Math.Max(SY1,SY2)) )
                    {
                        if ((hitmeY == Math.Min(SY1, SY2)) || (hitmeY == Math.Max(SY1, SY2)))
                        {
                            DMG = DMG + 25;
                        }
                        else
                        {
                            DMG = DMG + 50;
                        }
                    }
                }
                else
                {
                    if ((hitmeY >= Math.Min(SY1, SY2)) && (hitmeY <= Math.Max(SY1, SY2)))
                    {
                        if ((hitmeY == Math.Min(SY1, SY2)) || (hitmeY == Math.Max(SY1, SY2)))
                        {
                            DMG = DMG + 50;
                        }
                        else
                        {
                            DMG = DMG + 100;
                        }
                    }
                }
            }

            hitmeX = CHitX2;
            hitmeY = CHitY2;

            if ((hitmeX >= Math.Min(SX1, SX2)) && (hitmeX <= Math.Max(SX1, SX2)))
            {
                if (hitmeX == SX1 || hitmeX == SX2)
                {
                    if ((hitmeY >= Math.Min(SY1, SY2)) && (hitmeY <= Math.Max(SY1, SY2)))
                    {
                        if ((hitmeY == Math.Min(SY1, SY2)) || (hitmeY == Math.Max(SY1, SY2)))
                        {
                            DMG = DMG + 25;
                        }
                        else
                        {
                            DMG = DMG + 50;
                        }
                    }
                }
                else
                {
                    if ((hitmeY >= Math.Min(SY1, SY2)) && (hitmeY <= Math.Max(SY1, SY2)))
                    {
                        if ((hitmeY == Math.Min(SY1, SY2)) || (hitmeY == Math.Max(SY1, SY2)))
                        {
                            DMG = DMG + 50;
                        }
                        else
                        {
                            DMG = DMG + 100;
                        }
                    }
                }
            }

            hitmeX = CHitX3;
            hitmeY = CHitY3;

            if ((hitmeX >= Math.Min(SX1, SX2)) && (hitmeX <= Math.Max(SX1, SX2)))
            {
                if (hitmeX == SX1 || hitmeX == SX2)
                {
                    if ((hitmeY >= Math.Min(SY1, SY2)) && (hitmeY <= Math.Max(SY1, SY2)))
                    {
                        if ((hitmeY == Math.Min(SY1, SY2)) || (hitmeY == Math.Max(SY1, SY2)))
                        {
                            DMG = DMG + 25;
                        }
                        else
                        {
                            DMG = DMG + 50;
                        }
                    }
                }
                else
                {
                    if ((hitmeY >= Math.Min(SY1, SY2)) && (hitmeY <= Math.Max(SY1, SY2)))
                    {
                        if ((hitmeY == Math.Min(SY1, SY2)) || (hitmeY == Math.Max(SY1, SY2)))
                        {
                            DMG = DMG + 50;
                        }
                        else
                        {
                            DMG = DMG + 100;
                        }
                    }
                }
            }

            Console.Write(DMG);
            Console.WriteLine("%");
        }
    }
}
