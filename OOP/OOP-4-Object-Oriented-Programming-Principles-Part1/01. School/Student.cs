using System;

public class Student : Person, ICommentable
{
    private string comments;
    private int classNumber;
    public Student(string name,int classnum) : base(name) 
    {
        if (classnum < 1)
        {
            throw new ArgumentException("Students class number must be greater than 0");
        }
        this.classNumber = classnum;
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

