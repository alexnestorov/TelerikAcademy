using System;
using System.Linq;
using System.Collections.Generic;
using Exceptions.Abstracts;
using Exceptions.Validations;

namespace Exceptions
{
    public class Student
    {
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
                Validator.IsStringNull(value, this.firstName);
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
                Validator.IsStringNull(value, this.lastName);
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
                Validator.IsArrayNullOrEmpty(value);
                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams.Count == 0)
            {
                throw new InvalidOperationException("The student has no exams!");
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
            if (this.Exams.Count == 0)
            {
                throw new InvalidOperationException("The student has no exams!");
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
}