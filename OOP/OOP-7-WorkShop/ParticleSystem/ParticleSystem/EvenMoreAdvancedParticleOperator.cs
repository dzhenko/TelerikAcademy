using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class EvenMoreAdvancedParticleOperator : AdvancedParticleOperator
    {
        List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        List<Particle> allOtherParticles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var particleAsReppeler = p as ParticleRepeller;
            if (particleAsReppeler != null)
            {
                this.repellers.Add(particleAsReppeler);
            }
            else
            {
                this.allOtherParticles.Add(p);
            }
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.allOtherParticles)
                {
                    if (IsParticleInRangeOfRepeller(repeller.Position,particle.Position,repeller.RadiusOfEffect))
                    {
                        particle.Accelerate(new MatrixCoords(particle.Speed.Row * (-1) * (repeller.ReppelerPower+1), 
                            particle.Speed.Col * (-1) * (repeller.ReppelerPower+1)));
                    }
                }
            }

            this.repellers.Clear();
            this.allOtherParticles.Clear();

            base.TickEnded();
        }
  
        private bool IsParticleInRangeOfRepeller(MatrixCoords positionRepeller, MatrixCoords positionParticle, int radius)
        {
            var result = Math.Sqrt
                (
                    (positionRepeller.Row - positionParticle.Row) * (positionRepeller.Row - positionParticle.Row) +
                    (positionRepeller.Col - positionParticle.Col) * (positionRepeller.Col - positionParticle.Col)
                );
            return radius >= result;
        }
    }
}
