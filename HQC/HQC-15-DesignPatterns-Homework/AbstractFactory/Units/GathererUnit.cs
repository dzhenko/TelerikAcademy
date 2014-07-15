namespace AbstractFactory.Units
{
    public class GathererUnit
    {
        private string name;
        private int capacity;

        public GathererUnit(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            private set
            {
                this.capacity = value;
            }
        }

        public void Gather()
        {
            System.Console.WriteLine(this.Name + " can collect " + this.Capacity + " minerals at once!");
        }
    }
}
