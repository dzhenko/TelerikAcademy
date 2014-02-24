using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class Program
    {
        const int Rows = 30;
        const int Cols = 40;

        static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(Rows, Cols);

            var particleOperator = new EvenMoreAdvancedParticleOperator();

            var engine = 
                new Engine(renderer, particleOperator, null, 100);

            GenerateInitialData(engine);

            engine.Run();
        }

        private static void GenerateInitialData(Engine engine)
        {
            engine.AddParticle(
                new Particle(
                    new MatrixCoords(0, 10),
                    new MatrixCoords(1, 1))
                );

            /*engine.AddParticle(
                new DyingParticle(
                    new MatrixCoords(20, 5),
                    new MatrixCoords(-1, 1),
                    12)
                ); */

            var emitterPosition = new MatrixCoords(29, 0);
            var emitterSpeed = new MatrixCoords(0, 0);
            var emitter = new ParticleEmitter(emitterPosition, emitterSpeed,
                RandomGenerator,
                5,
                2,
                GenerateRandomParticle
                );

            engine.AddParticle(emitter);

            var emitterPosition2 = new MatrixCoords(0, 0);
            var emitterSpeed2 = new MatrixCoords(0, 0);
            var emitter2 = new ParticleEmitter(emitterPosition2, emitterSpeed2,
                RandomGenerator,
                5,
                2,
                GenerateRandomParticle
                );

            engine.AddParticle(emitter2);

            var emitterPosition3 = new MatrixCoords(15, 0);
            var emitterSpeed3 = new MatrixCoords(0, 0);
            var emitter3 = new ParticleEmitter(emitterPosition3, emitterSpeed3,
                RandomGenerator,
                5,
                2,
                GenerateRandomParticle
                );

            engine.AddParticle(emitter3);

            var attractorPosition = new MatrixCoords(10, 3);
            var attractor = new ParticleAttractor(
                attractorPosition,
                new MatrixCoords(0, 0),
                1);

            var attractorPosition2 = new MatrixCoords(10, 13);
            var attractor2 = new ParticleAttractor(
                attractorPosition2,
                new MatrixCoords(0, 0),
                3);

            //engine.AddParticle(attractor);
            //engine.AddParticle(attractor2);

            var chaoticParticle = new ChaoticParticle(new MatrixCoords(15, 15), new MatrixCoords(1, 1), RandomGenerator, 50, 50);
            //engine.AddParticle(chaoticParticle);

            var chickenParticle = new ChickenParticle(new MatrixCoords(15, 15), new MatrixCoords(1, 1), RandomGenerator, 50, 50,
                20, 10);
            //engine.AddParticle(chickenParticle);

            var repellerParticle = new ParticleRepeller(new MatrixCoords(15, 15), new MatrixCoords(0, 0),1,8);
            engine.AddParticle(repellerParticle);
        }

        static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParameter.RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);
            switch (particleTypeIndex)
            {
                case 0: generated = new Particle(particlePos, particleSpeed); break;
                case 1:
                    uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, lifespan);
                    break;
                default:
                    throw new Exception("No such particle for this particleTypeIndex");
            }
            return generated;
        }
    }
}
