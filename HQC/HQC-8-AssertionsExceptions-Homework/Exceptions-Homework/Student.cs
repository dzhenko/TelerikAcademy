using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private const string InvalidFirstNameExceptionMessage = "Invalid first name!";
    private const string InvalidLastNameExceptionMessage = "Invalid last name!";
    private const string StudentExamsAreNullExceptionMessage = "Student exams are null";
    private const string StudentExamsAreZeroExceptionMessage = "Student exams are 0";

    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(InvalidFirstNameExceptionMessage);
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(InvalidLastNameExceptionMessage);
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        private set
        {
            // constructor presets the value of exams = null -> meaning that by logic exams can be null!
            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(StudentExamsAreNullExceptionMessage);
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentException(StudentExamsAreZeroExceptionMessage);
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams == null)
        {
            throw new ArgumentNullException(StudentExamsAreNullExceptionMessage);
        }

        if (this.Exams.Count == 0)
        {
            throw new ArgumentException(StudentExamsAreZeroExceptionMessage);
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
