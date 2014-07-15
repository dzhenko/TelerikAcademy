namespace AbstractFactory
{
    using AbstractFactory.Units;
    public abstract class AbstractUnitFactory
    {
        public abstract GathererUnit GetGatherer();
        public abstract FighterUnit GetFighter();
        public abstract FlyingUnit GetFlyer();
    }
}
