using System;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// Represents information for sport player.
    /// </summary>
    public class Player
    {
        private string firstName;
        private string lastName;
        private string position;
        private int height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Creates instance for player with basic information.
        /// </summary>
        /// <param name="firstName">First name must be a string</param>
        /// <param name="lastName">Last name must be a string</param>
        /// <param name="height">Must be unsigned integer</param>
        /// <param name="position">Optional for position. Must be a string</param>
        public Player(string firstName, string lastName, int height, string position = null)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException();
            }

            if (lastName == null)
            {
                throw new ArgumentNullException();
            }

            if (height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.height = height;
            this.position = position;
        }
    }
}