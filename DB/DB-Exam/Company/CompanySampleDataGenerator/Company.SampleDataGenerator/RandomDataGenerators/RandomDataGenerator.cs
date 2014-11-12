namespace Company.SampleDataGenerator.RandomDataGenerators
{
    using System;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        private const string allLeters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private static RandomDataGenerator instance;

        private readonly Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static RandomDataGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomDataGenerator();
                }

                return instance;
            }
        }

        public string GetStringExact(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = allLeters[this.random.Next(0, allLeters.Length)];
            }

            return new string(result);
        }

        public string GetString(int min, int max)
        {
            return this.GetStringExact(this.random.Next(min, max + 1));
        }

        public int GetInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 101) <= percent;
        }
    }
}
