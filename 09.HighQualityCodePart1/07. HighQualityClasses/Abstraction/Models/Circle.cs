namespace Abstraction.Models
{
    using System;

    using Abstracts;
    using Common;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                Validator.ValidateFigureParameter(value, "radius");
                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }
}