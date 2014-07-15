namespace AbstractFactory
{
    using AbstractFactory.Units;
    public class Usage
    {
        public static void Main()
        {
            // by only changing this instance of AbstractUnitFactory to another - all the code will continue to work
            AbstractUnitFactory unitFactory = new ZergUnitFactory();
            // AbstractUnitFactory unitFactory = new TerranUnitFactory();

            GathererUnit gatherer = unitFactory.GetGatherer();
            FighterUnit fighter = unitFactory.GetFighter();
            FlyingUnit flyer = unitFactory.GetFlyer();

            gatherer.Gather();
            fighter.Engage();
            flyer.Fly();
        }
    }
}
