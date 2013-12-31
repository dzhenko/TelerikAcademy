using System;
using System.Text;

public class Person
{
    private int? age;
    private string name;

    public int? Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age can not be less than 0");
            }
            this.age = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name can not be null or empty");
            }
            this.name = value;
        }
    }

    public Person(string name,int? age = null)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return string.Format("Name: [{0}] , Age [{1}]", this.Name, this.Age == null ? "Unknown" : this.Age.ToString());
    }
}