namespace Builder
{
    public class ZergBuilder : AbstractBuilder
    {
        public override void CreateUnit()
        {
            this.Unit = new Unit("Zerg");
        }

        public override void SetUnitHealth()
        {
            this.Unit.Properties.Add("health", 12);
        }

        public override void SetUnitArmour()
        {
            this.Unit.Properties.Add("armour", 0);
        }

        public override void SetUnitAttack()
        {
            this.Unit.Properties.Add("attack", 5);
        }

        public override void SetUnitCost()
        {
            this.Unit.Properties.Add("cost", 50);
        }
    }
}
