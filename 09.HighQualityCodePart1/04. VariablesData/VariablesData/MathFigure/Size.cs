using System;

namespace VariablesData
{
    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be negative number.");
                };

                this.width = value;
            }

        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height can not be negative number.");
                };

                this.height = value;
            }

        }

        public static Size GetRotatedSize(Size currentSize, double angleOfTheFigureThatWillBeRotaed)
        {
            return new Size(
                Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * currentSize.Width +
                Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * currentSize.Height,
                Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed)) * currentSize.Width +
                Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed)) * currentSize.Height);
        }
    }
}
