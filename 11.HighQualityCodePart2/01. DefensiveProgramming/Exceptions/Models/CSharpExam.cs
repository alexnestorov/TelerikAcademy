using System;

using Exceptions.Abstracts;
using Exceptions.Validations;
using Exceptions.Extensions;

public class CSharpExam : Exam
{
    private int examScore;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.examScore;
        }

        private set
        {
            Validator.IsObjectNull(value, this.examScore.ToString());
            Validator.IsValidNumber(value, 0, 100);

            this.examScore = value;
        }
    }

    public override ExamResult Check()
    {
        var result = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");

        return result;
    }
}