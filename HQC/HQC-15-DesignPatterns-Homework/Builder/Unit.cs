namespace Builder
{
    using System;
    using System.Collections.Generic;
    public class Unit
    {
        private IDictionary<string, int> properties;
        private string race;

        public Unit(string race)
        {
            this.properties = new Dictionary<string, int>();
            this.Race = race;
        }

        public string Race
        {
            get
            {
                return this.race;
            }
            private set
            {
                this.race = value;
            }
        }

        public IDictionary<string, int> Properties
        {
            get
            {
                return this.properties;
            }
        }
    }
}
