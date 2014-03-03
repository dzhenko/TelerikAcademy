using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Giant : Character,IFighter,IGatherer
    {
        private const int giantInitialHitPoints = 200;
        private const int giantInitialAttackPoints = 150;
        private const int giantInitialDefensePoints = 80;

        private int GiantAttackPointsIncreaze;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = giantInitialHitPoints;
            this.GiantAttackPointsIncreaze = 0;
        }

        public int AttackPoints
        {
            get { return giantInitialAttackPoints + this.GiantAttackPointsIncreaze; }
        }

        public int DefensePoints
        {
            get { return giantInitialDefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.GiantAttackPointsIncreaze = 100;
                return true;
            }

            return false;
        }
    }
}
