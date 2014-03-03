using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        private const int knightInitialHitPoints = 100;
        private const int knightInitialAttackPoints = 100;
        private const int knightInitialDefensePoints = 100;

        public Knight(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = knightInitialHitPoints;
        }

        public int AttackPoints
        {
            get { return knightInitialAttackPoints; }
        }

        public int DefensePoints
        {
            get { return knightInitialDefensePoints; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
