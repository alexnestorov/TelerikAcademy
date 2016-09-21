using System;
using System.Text;

namespace Matrices
{
    public class MatrixUtils
    {
        private readonly int[] vertical = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly int[] horizontal = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private int[,] matrix;

        public MatrixUtils(int dimension)
        {
            this.Matrix = new int[dimension, dimension];
            this.DimensionCounter = 1;
        }

        public int[,] Matrix
        {
            get
            {
                return this.matrix;
            }

            set
            {
                if (value.GetLength(0) <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid dimension");
                }
                else if (value.GetLength(1) <= 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid dimension");
                }

                this.matrix = value;
            }
        }

        public int DimensionCounter { get; set; }

        public int FindCell(int vertical, int horizontal)
        {
            vertical = 0;
            horizontal = 0;
            bool isEmpty = false;
            int emptyCellResult = 0;
            for (int col = 0; col < this.Matrix.GetLength(0); col++)
            {
                for (int row = 0; row < this.Matrix.GetLength(0); row++)
                {
                    if (this.Matrix[col, row] == 0)
                    {
                        vertical = col;
                        horizontal = row;
                        isEmpty = true;
                        emptyCellResult = this.Matrix[col, row];
                    }
                }
            }

            if (!isEmpty)
            {
                throw new ArgumentException("Matrix does not contain empty cell");
            }
            else
            {
                return emptyCellResult;
            }
        }

        public void FillMatrix(int vertical, int horizontal, int dimension)
        {
            int deltaY = 1;
            int deltaX = 1;

            while (this.DimensionCounter < dimension)
            {
                this.Matrix[vertical, horizontal] = this.DimensionCounter;

                if (!this.CheckDirection(this.Matrix, vertical, horizontal))
                {
                    this.DimensionCounter++;
                    break;
                }

                while (this.CheckOutOfMatrix(vertical, horizontal, deltaX, vertical, dimension))
                {
                    this.ChangeDirection(ref vertical, ref deltaX);
                }

                vertical += deltaY;
                horizontal += deltaX;
                this.DimensionCounter++;
            }
        }

        public string Print()
        {
            var result = new StringBuilder();
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    var currentString = string.Format("{0,4}", this.Matrix[row, col]);
                    result.Append(currentString);
                }

                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }

        private int FindDirection(int currentDirectionY, int currentDirectionX)
        {
            if (currentDirectionX < 0 || currentDirectionX >= 8)
            {
                throw new ArgumentOutOfRangeException("Invalid direction");
            }

            if (currentDirectionY < 0 || currentDirectionY >= 8)
            {
                throw new ArgumentOutOfRangeException("Invalid direction");
            }

            for (int directionCounter = 0; directionCounter < 8; directionCounter++)
            {
                if (this.vertical[directionCounter] == currentDirectionX
                    && this.horizontal[directionCounter] == currentDirectionX)
                {
                    return directionCounter;
                }
            }

            throw new ArgumentException("Direction was not found.");
        }

        private void ChangeDirection(ref int vertical, ref int horizontal)
        {
            int directionIndex = this.FindDirection(vertical, horizontal);

            if (directionIndex == 7)
            {
                vertical = this.vertical[0];
                horizontal = this.horizontal[0];
            }
            else
            {
                vertical = this.vertical[directionIndex + 1];
                horizontal = this.vertical[directionIndex + 1];
            }
        }

        private bool CheckDirection(int[,] matrix, int vertical, int horizontal)
        {
            int[] possibleDirectionVertical = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] possibleDirectionHorizontal = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int index = 0; index < 8; index++)
            {
                if (vertical + possibleDirectionVertical[index] >= matrix.GetLength(0)
                    || vertical + possibleDirectionVertical[index] < 0)
                {
                    possibleDirectionVertical[index] = 0;
                }

                if (horizontal + possibleDirectionHorizontal[index] >= matrix.GetLength(0)
                    || horizontal + possibleDirectionHorizontal[index] < 0)
                {
                    possibleDirectionHorizontal[index] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[vertical + possibleDirectionVertical[i], horizontal + possibleDirectionHorizontal[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckOutOfMatrix(int vertical, int horizontal,
            int directionX, int directionY, int dimension)
        {
            if (vertical + directionY >= dimension
                    || vertical + directionY < 0
                    || horizontal + directionX >= dimension
                    || horizontal + directionX < 0
                    || this.Matrix[vertical + directionY, horizontal + directionX] != 0)
            {
                return true;
            }

            return false;
        }
    }
}
