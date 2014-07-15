namespace AbstractFactory.Units
{
    public class FlyingUnit
    {
        private string name;
        private int speed;

        public FlyingUnit(string name, int speed)
        {
            this.Name = name;
            this.Speed = speed;
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

        public int Speed
        {
            get
            {
                return this.speed;
            }
            private set
            {
                this.speed = value;
            }
        }

        public void Fly()
        {
            System.Console.WriteLine(this.Name + " is flying high at the speed of ... " + this.Speed);
        }
    }
}
