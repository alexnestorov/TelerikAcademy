namespace HighQualityMethods.Methods
{
    using System;

    using Enums;
    using global::Methods;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertDigitToText(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine(PrintAsNumber(1.3, "f"));
            Console.WriteLine(PrintAsNumber(0.75, "%"));
            Console.WriteLine(PrintAsNumber(2.30, "r"));

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + CheckForLinePosition(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + CheckForLinePosition(2, 4, 3, 4));
            Console.WriteLine("Horizontal? " + CheckForLinePosition(2, 4, 6, 8));
            // Console.WriteLine("Vertical? " + CheckForLinePosition(3, 5, 3, 5));
            Student firstStudent = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                BirthdayDate = new DateTime(1989, 12, 29),
                Town = TownType.Burgas,
                OtherInfo = "Student at Sofia University"
            };

            Student secondStudent = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova",
                BirthdayDate = new DateTime(1987, 10, 21),
                Town = TownType.Sofia,
                OtherInfo = "Student at Telerik Academy season 2016 / 2017"
            };

            Console.WriteLine("{0} older than {1} -> {2}",
                                   firstStudent.FirstName,
                                   secondStudent.FirstName,
                                   firstStudent.IsOlderThan(secondStudent));
        }

        internal static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)
            {
                throw new ArgumentOutOfRangeException("Side A can not be negative number");
            }
            else if (sideB <= 0)
            {
                throw new ArgumentOutOfRangeException("Side B can not be negative number");
            }
            else if (sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Side C can not be negative number");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
            return area;
        }

        internal static string ConvertDigitToText(int digit)
        {
            switch (digit)
            {
                case 0: return StringDigitType.Zero.ToString();
                case 1: return StringDigitType.One.ToString();
                case 2: return StringDigitType.Two.ToString();
                case 3: return StringDigitType.Three.ToString();
                case 4: return StringDigitType.Four.ToString();
                case 5: return StringDigitType.Five.ToString();
                case 6: return StringDigitType.Six.ToString();
                case 7: return StringDigitType.Seven.ToString();
                case 8: return StringDigitType.Eight.ToString();
                case 9: return StringDigitType.Nine.ToString();
                default: throw new ArgumentOutOfRangeException("Invalid digit. Must enter digit between [0-9].");
            }
        }

        internal static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("No elements has passed.");
            }

            var maxElement = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        internal static string PrintAsNumber(object number, string format)
        {
            var formattedString = string.Empty;

            if (number.Equals(null))
            {
                throw new ArgumentNullException("Number can not be null");
            }

            if (format.Equals("f"))
            {
                formattedString = string.Format("{0:f2}", number);
            }
            else if (format.Equals("%"))
            {
                if (Convert.ToInt32(number) < 0)
                {
                    throw new ArgumentOutOfRangeException("The number must be greater or equal to 0 to convert to %.");
                }

                formattedString = string.Format("{0:p0}", number);
            }
            else if (format.Equals("r"))
            {
                formattedString = string.Format("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format");
            }

            return formattedString;
        }

        internal static double CalculateDistance(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            double distance = Math.Sqrt((pointX2 - pointX1) * (pointX2 - pointX1) + 
                                        (pointY2 - pointY1) * (pointY2 - pointY1));

            return distance;
        }

        internal static string CheckForLinePosition(double pointX1, double pointY1, double pointX2, double pointY2)
        {
            var linePosition = string.Empty;

            if (pointX1.Equals(pointX2) && pointY1.Equals(pointY2))
            {
                throw new ArgumentNullException("The points are on the same position. Hence there is no line.");
            }

            if (pointX1.Equals(pointX2))
            {
                return linePosition = "Vertical Line";
            }
            else if (pointY1.Equals(pointY2))
            {
                return linePosition = "Horizontal Line";
            }
            else
            {
                return linePosition = "Line position is not defined either horizontal or vertical";
            }
        }
    }
}