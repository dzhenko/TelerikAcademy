using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        private readonly int directionChangeFrequencyRowPercent;
        private readonly int directionChangeFrequencyColPercent;

        public ChaoticParticle(MatrixCoords position,MatrixCoords speed,
            Random randomGenerator, uint directionChangeFreqRowPercent, uint directionChangeFreqColPercent)
            : base(position,speed)
        {
            this.RandomGenerator = randomGenerator;
            this.directionChangeFrequencyRowPercent = (int)directionChangeFreqRowPercent;
            this.directionChangeFrequencyColPercent = (int)directionChangeFreqColPercent;
        }

        protected Random RandomGenerator { get; private set; }

        protected int DirectionChangeFrequencyRowPercent
        {
            get
            {
                return this.directionChangeFrequencyRowPercent;
            }
        }

        protected int DirectionChangeFrequencyColPercent
        {
            get
            {
                return this.directionChangeFrequencyColPercent;
            }
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.RandomGenerator.Next(0, 101) <= this.directionChangeFrequencyRowPercent)
            {
                this.Accelerate(new MatrixCoords(2 * (this.Speed.Row * (-1)) , 0));
            }
            if (this.RandomGenerator.Next(0, 101) <= this.directionChangeFrequencyColPercent)
            {
                this.Accelerate(new MatrixCoords(0, 2 * (this.Speed.Col * (-1))));
            }
            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '?' } };
        }
    }
}
