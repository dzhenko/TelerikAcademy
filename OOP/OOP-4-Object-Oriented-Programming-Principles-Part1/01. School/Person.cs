using System;

public class Person
{
    private string name;
    
    public Person(string inputName)
    {
        this.Name = inputName;
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
                throw new ArgumentException("Name can not be null or empty !");
            }
            this.name = value;
        }
    }
}

