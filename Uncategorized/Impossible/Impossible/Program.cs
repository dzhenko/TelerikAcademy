using System;
using System.Collections.Generic;

struct Particle
{
    public uint start;
    public uint cord;
    public uint speed;
}

class Program
{
    static void Main()
    {
        ushort n = Convert.ToUInt16(Console.ReadLine());
        int numberX=1;
        int numberY=2;
        int counter1 = 0;
        int counter2 = 0;
        List<Particle> particlesX = new List<Particle>();
        List<Particle> particlesY = new List<Particle>();
        Particle newp = new Particle();
        for (int i = 0; i < n; i++)
        {
            var entry = Console.ReadLine();           
            newp.start = Convert.ToUInt32(entry.Split(' ')[0]);
            newp.speed = Convert.ToUInt32(entry.Split(' ')[1]);
            particlesX.Add(newp);
        }
        for (int i = 0; i < n; i++)
        {
            var entry = Console.ReadLine();
            newp.start = Convert.ToUInt32(entry.Split(' ')[0]);
            newp.speed = Convert.ToUInt32(entry.Split(' ')[1]);
            particlesY.Add(newp);
        }
        //List<Particle> newParticlesX = new List<Particle>();
        //List<Particle> newParticlesY = new List<Particle>();
        Particle temp = new Particle();
        while (!(numberX==0 && numberY==0))
        {
            numberX = particlesX.Count;
            numberY = particlesY.Count;
            for (int i = 0; i < numberX; i++)
            {
                if (particlesX[i].cord + particlesX[i].speed < 1000000000)
                {
                    temp = particlesX[i];
                    temp.cord = temp.cord + temp.speed;
                    particlesX[i] = temp; 
                }
                else
                {
                    particlesX.Remove(particlesX[i]);
                }
            }
            for (int i = 0; i < numberY; i++)
            {
                if (particlesY[i].cord + particlesY[i].speed < 1000000000)
                {
                    temp = particlesY[i];
                    temp.cord = temp.cord + temp.speed;
                    particlesY[i] = temp;
                }
                else
                {
                    particlesY.Remove(particlesY[i]);
                }
            }
            //coords are changed
            for (int i = 0; i < Math.Max(numberX,numberY); i++)
            {
                if (particlesX[i].cord == particlesY[i].start && particlesY[i].cord == particlesX[i].start)
                {
                    particlesX.Remove(particlesX[i]);
                    particlesY.Remove(particlesY[i]);
                    counter1++;
                }
            }

        }
        Console.WriteLine(counter1);
    }
}

