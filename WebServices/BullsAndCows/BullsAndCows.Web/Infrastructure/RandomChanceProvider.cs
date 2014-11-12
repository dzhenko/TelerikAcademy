namespace BullsAndCows.Web.Infrastructure
{
    using System;

    public class RandomChanceProvider : IRandomChanceProvider
    {
        private Random random;

        public RandomChanceProvider()
        {
            this.random = new Random();
        }

        public bool GetChance(int percent)
        {
            return this.random.Next(0, 100) < percent;
        }
    }
}