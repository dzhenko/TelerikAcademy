namespace Builder
{
    public class Usage
    {
        public static void Main()
        {
            Director director = new Director();

            Unit terranUnit = director.ConstructUnit(new TerranBuilder());
            Unit zergUnit = director.ConstructUnit(new ZergBuilder());
        }
    }
}
