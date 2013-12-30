using System;

class Student : Human
{
    private double grade;

    public double Grade
    {
        get
        {
            return this.grade;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Grade can not be a negative number");
            }
            this.grade = value;
        }
    }

    public Student(string firstName, string secondName, double grade)
        : base(firstName, secondName)
    {
        this.Grade = grade;
    }
}

