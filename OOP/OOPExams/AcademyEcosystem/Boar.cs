using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public class Boar : Animal, IHerbivore, ICarnivore
    {
        private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, 4)
        {
            this.biteSize = 2;
        }

        public override void Update(int timeElapsed)
        {
            if (this.State == AnimalState.Sleeping)
            {
                if (timeElapsed >= sleepRemaining)
                {
                    this.Awake();
                }
                else
                {
                    this.sleepRemaining -= timeElapsed;
                }
            }

            base.Update(timeElapsed);
        }

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size++;
                return p.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null && animal.IsAlive)
            {
                if (animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
