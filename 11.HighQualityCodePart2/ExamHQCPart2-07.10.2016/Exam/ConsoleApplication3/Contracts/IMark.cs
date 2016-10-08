using ConsoleApplication3.Enums;

namespace ConsoleApplication3.Contracts
{
    /// <summary>
    /// Represent information about criterias for evaluating person.
    /// </summary>
    public interface IMark
    {
        /// <summary>
        /// Describes information about SchoolSystem Subject
        /// </summary>
        Subject Subject { get; }

        /// <summary>
        /// Defines current value of the Mark.
        /// </summary>
        decimal SubjectValue { get; }
    }
}
