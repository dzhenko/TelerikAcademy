using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade
{
    public class Usage
    {
        public static void Main()
        {
            // the only thing we need to get a new marine is use this method
            // we can hide complex code usage behind a single method, so that the user uses our code more efficently and easy.

            var marine = FacadeForCreatingMarine.GetMarine();

            // instead we could have used this:
            /*
            // creating motor
            var random = new Random();

            var wheels = random.Next(2, 4);
            var wheelsArr = new Wheel[wheels];
            for (int i = 0; i < wheels; i++)
            {
                wheelsArr[i] = new Wheel();
            }

            var frame = new Frame();

            var hp = random.Next(40, 101);
            var engine = new Engine(hp);

            var motor = new Motor(wheelsArr, frame, engine);

            // creating marine
            var gun = new Gun();

            var ammo = new Ammo();

            var marine = new Marine(gun, ammo, motor);
            */
        }
    }
}
