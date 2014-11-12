namespace Company.SampleDataGenerator.RandomDataGenerators
{
    public interface IRandomDataGenerator
    {
        string GetStringExact(int length);

        string GetString(int min, int max);

        int GetInt(int min, int max);

        bool GetChance(int percent);
    }
}
