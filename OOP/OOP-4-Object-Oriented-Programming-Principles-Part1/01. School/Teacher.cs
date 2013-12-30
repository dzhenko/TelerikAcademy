using System;
using System.Collections.Generic;

public class Teacher : Person, ICommentable
{
    private List<Discipline> disciplines;
    private string comments;

    public Teacher(string name, params Discipline[] inputDisciplines) : base(name)
    {
        disciplines = new List<Discipline>();
        foreach (Discipline d in inputDisciplines)
        {
            this.disciplines.Add(d);
        }
    }

    public Discipline[] Disciplines
    {
        get
        {
            return this.disciplines.ToArray();
        }
    }

    public void AddDiscipline(Discipline d)
    {
        this.disciplines.Add(d);
    }

    public void RemoveDiscipline(Discipline d)
    {
        if (!this.disciplines.Contains(d))
        {
            throw new ArgumentException("No such teacher in this class found");
        }
        this.disciplines.Remove(d);
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

