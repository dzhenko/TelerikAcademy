namespace AbstractFactory.Units
{
    public class FighterUnit
    {
        private string name;
        private int attack;

        public FighterUnit(string name, int attack)
        {
            this.Name = name;
            this.Attack = attack;
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

        public int Attack
        {
            get
            {
                return this.attack;
            }
            private set
            {
                this.attack = value;
            }
        }

        public void Engage()
        {
            System.Console.WriteLine(this.Name + " attacks and causes " + this.Attack + " damage!");
        }
    }
}
