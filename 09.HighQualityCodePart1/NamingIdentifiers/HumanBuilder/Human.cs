namespace HumanBuilder
{
    using System;

    public class Human
    {
        private string name;
        private GenderType gender;
        private int age;

        public Human()
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < 1 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("The age must be in range [0,120]");
                }

                this.age = value;
            }
        }

        public GenderType Gender { get; private set; }

        public static Human BuildHuman(int age)
        {
            Human currentHuman = new Human();
            currentHuman.Age = age;
            if (age % 2 == 0)
            {
                currentHuman.Name = "Bad Name";
                currentHuman.Gender = GenderType.Male;
            }
            else
            {
                currentHuman.Name = "Amanda Amanda";
                currentHuman.Gender = GenderType.Female;
            }

            return currentHuman;
        }
    }
}