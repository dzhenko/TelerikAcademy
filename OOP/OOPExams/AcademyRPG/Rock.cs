using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Rock : StaticObject, IResource
    {
        private readonly int quantity;

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
        }

        public Rock(int hitPoints, Point position)
            : base(position,0)
        {
            this.HitPoints = hitPoints;
            this.quantity = this.HitPoints / 2;
        }
    }
}
