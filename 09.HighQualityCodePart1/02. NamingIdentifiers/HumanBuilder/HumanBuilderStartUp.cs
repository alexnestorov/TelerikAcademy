namespace HumanBuilder
{
    using System;

    public class HumanBuilderStartUp
    {
        public static void Main(string[] args)
        {
            Human firstHuman = Human.BuildHuman(24);
            Human secondHuman = Human.BuildHuman(25);
            Console.WriteLine(firstHuman.Name);
            Console.WriteLine(secondHuman.Name);
        }
    }
}
