namespace SortingHomework
{
    using System;

    public class MyRandom
    {
        private static Random instance;

        private MyRandom() { }

        public static Random Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Random();
                }
                return instance;
            }
        }
    }
}
