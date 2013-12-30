public class Frog : Animal
{
    public Frog(string name, int age, bool isMale) : base(name, age, isMale) { }

    public override void ProduceSound()
    {
        System.Console.WriteLine("Rabbit");
    }
}

