namespace Facade
{
    public class Motor
    {
        private Wheel[] wheels;
        private Frame frame;
        private Engine engine;

        public Motor(Wheel[] wheels, Frame frame, Engine engine)
        {
            this.Wheels = wheels;
            this.Frame = frame;
            this.Engine = engine;
        }

        public Wheel[] Wheels
        {
            get
            {
                return this.wheels;
            }
            set
            {
                this.wheels = value;
            }
        }

        public Frame Frame
        {
            get
            {
                return this.frame;
            }
            set
            {
                this.frame = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }
    }
}
