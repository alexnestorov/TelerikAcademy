using System.Collections.Generic;

using ConsoleApplication3.Enums;

namespace ConsoleApplication3.Contracts
{
    /// <summary>
    /// Describes information of student needed properties.
    /// </summary>
    public interface IStudent : IPerson
    {
        /// <summary>
        /// Represents collection of Student's marks.
        /// </summary>
        IList<IMark> Marks { get; }

        /// <summary>
        /// Represent information of student's grade.
        /// </summary>
        Grade Grade { get; }

        /// <summary>
        /// Returns information about all student marks.
        /// </summary>
        /// <returns></returns>
        string PrintStudentMarks();
    }
}
