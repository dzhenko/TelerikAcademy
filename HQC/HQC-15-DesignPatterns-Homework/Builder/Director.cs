namespace Builder
{
    public class Director
    {
        // imagine that calling this steps in this order is vital!
        public Unit ConstructUnit(AbstractBuilder builder)
        {
            builder.CreateUnit();

            builder.SetUnitHealth();

            builder.SetUnitArmour();

            builder.SetUnitAttack();

            builder.SetUnitCost();

            return builder.GetUnit();
        }
    }
}
