namespace Facade
{
    public class Marine
    {
        private Gun gun;
        private Ammo ammo;
        private Motor motor;

        public Marine(Gun gun, Ammo ammo, Motor motor)
        {
            this.Gun = gun;
            this.Ammo = ammo;
            this.Motor = motor;
        }

        public Gun Gun
        {
            get
            {
                return this.gun;
            }
            set
            {
                this.gun = value;
            }
        }

        public Ammo Ammo
        {
            get
            {
                return this.ammo;
            }
            set
            {
                this.ammo = value;
            }
        }

        public Motor Motor
        {
            get
            {
                return this.motor;
            }
            set
            {
                this.motor = value;
            }
        }
    }
}
