namespace Facade
{
    public class Engine
    {
        private int hp;

        public Engine(int hp)
        {
            this.Hp = hp;
        }
        public int Hp
        {
            get
            {
                return this.hp;
            }
            set
            {
                this.hp = value;
            }
        }
    }
}
