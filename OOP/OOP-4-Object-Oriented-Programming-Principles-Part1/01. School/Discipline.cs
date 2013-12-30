using System;
using System.Collections.Generic;

public class Discipline : ICommentable
{
    private string name;
    private int numberOfLecturers;
    private int numberOfExcersises;
    private string comments;

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
                throw new ArgumentException("The name can not be null or empty!");
            }
            this.name = value;
        }
    }

    public int NumberOfLecturers
    {
        get
        {
            return this.numberOfLecturers;
        }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("The number of lecturers can not be less than 1!");
            }
            this.numberOfLecturers = value;
        }
    }

    public int NumberOfExercises
    {
        get
        {
            return this.numberOfExcersises;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The number of excercises can not be a negative number!");
            }
            this.numberOfExcersises = value;
        }
    }

    public Discipline(string name, int numLecturers, int numExcercises)
    {
        this.Name = name;
        this.numberOfLecturers = numLecturers;
        this.numberOfExcersises = numExcercises;
    }

    public string Comments
    {
        get
        {
            if (this.comments == null)
            {
                return "No comments yet";
            }
            return this.comments;
        }
        set
        {
            this.comments = value;
        }
    }
}

