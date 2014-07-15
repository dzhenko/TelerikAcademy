namespace Builder
{
    public class TerranBuilder : AbstractBuilder
    {
        public override void CreateUnit()
        {
            this.Unit = new Unit("Terran");
        }

        public override void SetUnitHealth()
        {
            this.Unit.Properties.Add("health", 15);
        }

        public override void SetUnitArmour()
        {
            this.Unit.Properties.Add("armour", 1);
        }

        public override void SetUnitAttack()
        {
            this.Unit.Properties.Add("attack", 3);
        }

        public override void SetUnitCost()
        {
            this.Unit.Properties.Add("cost", 65);
        }
    }
}
