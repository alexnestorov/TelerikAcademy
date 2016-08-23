namespace Abstraction
{
    using System;

    using Models;

    public class FigureStartUp
    {
        public static void Main()
        {
            Circle circle = new Circle(5);

            Rectangle rect = new Rectangle(2, 3);

            Console.WriteLine(circle);

            Console.WriteLine(rect);
        }
    }
}
