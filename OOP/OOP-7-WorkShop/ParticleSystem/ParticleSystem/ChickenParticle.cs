using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        private readonly int stopFrequencyPercent;
        private readonly int stopDuarationTicks;
        private int currentTick;
        private MatrixCoords lastKnownSpeed;
        private bool currentlyStopped;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random random, 
            uint directionChangeFreqRowPercent, uint directionChangeFreqColPercent, 
            uint stopFrequencyPercent, uint stopDuarationTicks)
            :base (position,speed,random,directionChangeFreqRowPercent,directionChangeFreqColPercent)
        {
            this.stopFrequencyPercent = (int)stopFrequencyPercent;
            this.stopDuarationTicks = (int)stopDuarationTicks;
            this.currentlyStopped = false;
            this.currentTick = 0;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '@' } };
        }

        public override IEnumerable<Particle> Update()
        {
            if (!this.currentlyStopped && this.RandomGenerator.Next(0, 101) <= this.stopFrequencyPercent)
            {
                lastKnownSpeed = this.Speed;
                this.Accelerate(new MatrixCoords(this.Speed.Row * (-1), this.Speed.Col * (-1)));
                this.currentlyStopped = true;
            }
            if (currentlyStopped)
            {
                this.currentTick++;
                if (this.currentTick == this.stopDuarationTicks)
                {
                    this.Accelerate(lastKnownSpeed);
                    this.currentTick = 0;
                    this.currentlyStopped = false;

                    var baseProduced = base.Update();

                    List<Particle> newProduced = new List<Particle>()
                    {
                        new ChickenParticle(this.Position,lastKnownSpeed,this.RandomGenerator,
                            (uint)base.DirectionChangeFrequencyRowPercent,(uint)this.DirectionChangeFrequencyColPercent,
                            (uint)this.stopFrequencyPercent,(uint)this.stopDuarationTicks)
                    };

                    newProduced.AddRange(baseProduced);

                    return newProduced;
                }
            }
            return base.Update();
        }
    }
}
