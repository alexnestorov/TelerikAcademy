using ConsoleApplication3.Enums;

namespace ConsoleApplication3.Contracts
{
    /// <summary>
    /// Describes information about teacher needed properties.
    /// </summary>
    public interface ITeacher : IPerson
    {
        /// <summary>
        /// Represents each teacher subject which he is teaching in SchoolSystem API.
        /// </summary>
        Subject Subject { get; }

        /// <summary>
        /// Add mark value for current Student.
        /// </summary>
        /// <param name="currentStudent"></param>
        /// <param name="studentMark"></param>
        void AddMark(IStudent currentStudent, decimal studentMark);
    }
}
