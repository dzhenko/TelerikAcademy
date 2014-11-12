namespace ToysStore.SampleDataGenerator.RandomDataGenerators
{
    public interface IRandomDataGenerator
    {
        string GetStringExact(int length, string charsToUse);

        string GetString(int min, int max, string charsToUse);

        int GetInt(int min, int max);

        double GetDouble();

        bool GetChance(int percent);
    }
}
