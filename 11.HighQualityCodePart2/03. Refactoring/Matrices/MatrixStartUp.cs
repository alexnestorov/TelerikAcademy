using System;

namespace Matrices
{
    public class MatrixStartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int dimension = int.Parse(input);

            MatrixUtils matrix = new MatrixUtils(dimension);

            int vertical = 0;
            int horizontal = 0;

            matrix.FillMatrix(vertical, horizontal, dimension);

            matrix.FindCell(vertical, horizontal);

            if (vertical != 0 && horizontal != 0)
            {
                matrix.FillMatrix(vertical, horizontal, dimension);
            }

            Console.WriteLine(matrix.Print());
        }
    }
}