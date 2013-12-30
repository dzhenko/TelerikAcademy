using System;
using System.Collections.Generic;

public class Class : ICommentable
{
    private List<Teacher> teachers;
    private string textIdentifier;
    private string comments;

    public Class(string textid, params Teacher[] Teachers)
    {
        if (string.IsNullOrEmpty(textid))
        {
            throw new ArgumentException("Class Text Identifier can not be null or empty!");
        }
        this.teachers = new List<Teacher>();
        foreach (Teacher t in Teachers)
        {
            this.teachers.Add(t);
        }
    }

    public Teacher[] Teachers
    {
        get
        {
            return this.teachers.ToArray();
        }
    }

    public void AddTeacher (Teacher t)
    {
        this.teachers.Add(t);
    }

    public void RemoveTeacher(Teacher t)
    {
        if (!this.teachers.Contains(t))
        {
            throw new ArgumentException("No such teacher in this class found");
        }
        this.teachers.Remove(t);
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