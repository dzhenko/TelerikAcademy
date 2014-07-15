namespace AbstractFactory
{
    using AbstractFactory.Units;
    public class TerranUnitFactory: AbstractUnitFactory
    {
        public override GathererUnit GetGatherer()
        {
            return new GathererUnit("SCV", 5);
        }

        public override FighterUnit GetFighter()
        {
            return new FighterUnit("Marine", 6);
        }

        public override FlyingUnit GetFlyer()
        {
            return new FlyingUnit("Wright", 18);
        }
    }
}
