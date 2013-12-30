public class Tomcat : Cat
{
    public Tomcat(string name, int age) : base(name, age, true) { }

    public override void ProduceSound()
    {
        System.Console.WriteLine("TOM MIEW MF");
    }
}

