using System;

using Exceptions.Abstracts;
using Exceptions.Validations;

public class SimpleMathExam : Exam
{
    private int problemSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemSolved;
        }

        private set
        {
            Validator.IsValidNumber(value, 0, 10);
            this.problemSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved <= 2)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved > 2 && this.ProblemsSolved <= 4)
        {
            return new ExamResult(3, 2, 6, "Average result: you should study harder.");
        }
        else if (this.ProblemsSolved > 4 && this.ProblemsSolved <= 6)
        {
            return new ExamResult(4, 2, 6, "Good result: You've most of the tasks.");
        }
        else if (this.ProblemsSolved > 6 && this.ProblemsSolved <= 8)
        {
            return new ExamResult(5, 2, 6, "Very good result: You've done almost all tasks.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Excellent result: You are a great student.");
        }
    }
}