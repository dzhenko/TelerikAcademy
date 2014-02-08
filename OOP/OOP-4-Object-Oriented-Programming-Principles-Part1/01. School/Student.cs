using System;

public class Student : Person, ICommentable
{
    private string comments;
    private int classNumber;

    public Student(string name,int classnum) : base(name) 
    {
        this.ClassNumber = classnum;
    }

    public int ClassNumber
    {
        get
        {
            return this.classNumber;
        }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Students class number must be greater than 0");
            }
            this.classNumber = value;
        }
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

