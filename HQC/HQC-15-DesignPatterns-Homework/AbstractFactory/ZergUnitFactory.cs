namespace AbstractFactory
{
    using AbstractFactory.Units;
    public class ZergUnitFactory : AbstractUnitFactory
    {
        public override GathererUnit GetGatherer()
        {
            return new GathererUnit("Drone", 4);
        }

        public override FighterUnit GetFighter()
        {
            return new FighterUnit("Hydralisk", 10);
        }

        public override FlyingUnit GetFlyer()
        {
            return new FlyingUnit("Mutalisk", 22);
        }
    }
}
