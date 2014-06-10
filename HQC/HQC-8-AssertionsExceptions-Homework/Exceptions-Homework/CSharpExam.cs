using System;

public class CSharpExam : Exam
{
    private const string ScoreCanNotBeLessThan0ExceptionMessage = "Score can not be less than 0";
    private const string ScoreCanNotBeMoreThan100ExceptionMessage = "Score can not be more than 100";

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ScoreCanNotBeLessThan0ExceptionMessage);
            }

            if (value > 100)
            {
                throw new ArgumentException(ScoreCanNotBeMoreThan100ExceptionMessage);
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
