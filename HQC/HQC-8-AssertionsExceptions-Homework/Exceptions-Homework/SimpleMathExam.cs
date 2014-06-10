using System;

public class SimpleMathExam : Exam
{
    private const string ProblemsSolvedNegativeExceptionMessage = "Problems solved can not be less than 0";
    private const string ProblemsSolvedMoreThanTwoExceptionMessage = "Problems solved can not be more than 2";

    private const string BadResultExamComment = "Bad result: nothing done.";
    private const string AverageResultExamComment = "Average result: half done.";
    private const string ExcellentResultExamComment = "Excellent result: everything done.";

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ProblemsSolvedNegativeExceptionMessage);
            }

            // Check method shows that you can only have solved 0 1 or 2 problems
            if (value > 2)
            {
                throw new ArgumentException(ProblemsSolvedMoreThanTwoExceptionMessage);
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        ExamResult examResultToReturn = null;

        switch (this.ProblemsSolved)
        {
            case 0: examResultToReturn = new ExamResult(2, 2, 6, BadResultExamComment);
                break;
            case 1: examResultToReturn = new ExamResult(4, 2, 6, AverageResultExamComment); 
                break;
            case 2: examResultToReturn = new ExamResult(6, 2, 6, ExcellentResultExamComment); 
                break;
            default: break;
        }

        return examResultToReturn;
    }
}
