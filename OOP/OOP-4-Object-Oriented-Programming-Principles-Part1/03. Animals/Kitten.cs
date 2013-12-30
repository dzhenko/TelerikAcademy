public class Kitten : Cat
{
    public Kitten(string name, int age) : base(name, age, false) { }

    public override void ProduceSound()
    {
        System.Console.WriteLine("Kitty mieww");
    }
}

