using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Builder
{
    public abstract class AbstractBuilder
    {
        protected Unit Unit;
        public abstract void CreateUnit();

        public abstract void SetUnitHealth();

        public abstract void SetUnitArmour();

        public abstract void SetUnitAttack();

        public abstract void SetUnitCost();

        public Unit GetUnit()
        {
            return this.Unit;
        }
    }
}
