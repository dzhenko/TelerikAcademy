using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private const int ninjaInitialHitPoints = 1;
        private const int ninjaInitialAttackPoints = 0;
        private const int ninjaInitialDefensePoints = 100;

        private int ninjaAttackPointsIncrease;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = ninjaInitialHitPoints;
            this.ninjaAttackPointsIncrease = 0;
        }

        public new bool IsDestroyed
        {
            get
            {
                return false;
            }
        }

        public int AttackPoints
        {
            get { return ninjaInitialAttackPoints + ninjaAttackPointsIncrease; }
        }

        public int DefensePoints
        {
            get { return ninjaInitialDefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int highestHitPointsTarget = -1;

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (highestHitPointsTarget == -1)
                    {
                        highestHitPointsTarget = i;
                    }
                    if (availableTargets[i].HitPoints > availableTargets[highestHitPointsTarget].HitPoints)
                    {
                        highestHitPointsTarget = i;
                    }
                }
            }

            return highestHitPointsTarget;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.ninjaAttackPointsIncrease += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.ninjaAttackPointsIncrease += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
