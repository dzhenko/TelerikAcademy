using System;

public class ExamResult
{
    private const string GradeLessThanZeroExceptionMessage = "Grade can not be less than 0";
    private const string MinGradeLessThanZeroExceptionMessage = "Min grade can not be less than 0";
    private const string MaxGradeLessOrEqualMinGradeExceptionMessage = "Max grade can not be less than or equal to min grade";
    private const string CommentsNullOrEmptyExceptionMessage = "Grade can not be less than 0";

    // will introduce private fields - the properties become single point of responsibility
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(GradeLessThanZeroExceptionMessage);
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(MinGradeLessThanZeroExceptionMessage);
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentException(MaxGradeLessOrEqualMinGradeExceptionMessage);
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(CommentsNullOrEmptyExceptionMessage);
            }

            this.comments = value;
        }
    }
}
