namespace ConsoleApplication3.Contracts
{
    /// <summary>
    /// Defines information for all creating instances in SchoolSystem API
    /// </summary>
    public interface ISchoolSystemFactory
    {
        /// <summary>
        /// Creates student with first and last name, and grade
        /// </summary>
        /// <param name="firstName">Must be a string</param>
        /// <param name="lastName">Must be a string</param>
        /// <param name="grade">Must be a string</param>
        /// <returns></returns>
        IStudent CreateStudent(string firstName, string lastName, string grade);

        /// <summary>
        /// Creates teacher with first and last name, and grade
        /// </summary>
        /// <param name="firstName">Must be a string</param>
        /// <param name="lastName">Must be a string</param>
        /// <param name="grade">Must be a string</param>
        /// <returns></returns>
        ITeacher CreateTeacher(string firstName, string lastName, int subjectId);
    }
}
