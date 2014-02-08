using System;
using System.Linq;

public abstract class Animal : ISound
{
    private string name;
    private int age;
    private bool isMale;

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name can not be null or empty!");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Age must be at least 1 !");
            }
            this.age = value;
        }
    }

    public bool IsMale
    {
        get { return this.isMale; }
        set { this.isMale = value; }
    }

    public Animal(string name, int age, bool isMale)
    {
        this.Name = name;
        this.Age = age;
        this.isMale = isMale;
    }

    public override string ToString()
    {
        return string.Format
            ("I am a {0} - My name is {1} and Im {2} years old and Im {3}"
            ,this.GetType().Name, this.name, this.age, this.isMale ? "Male" : "Female");
    }

    public virtual void ProduceSound()
    {
        Console.WriteLine(this.GetType().Name + " said sth");
    }

    public static decimal AverageAge(Animal[] arr)
    {
        return arr.Average(x => (decimal)x.age);
    }
}

