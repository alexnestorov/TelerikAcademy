namespace CohesionAndCoupling
{
    using System;

    using Models;
    using Models.Utils;

    public class UtilsExamples
    {
        public static void Main()
        {
            //Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                               GeometryUtils.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                               GeometryUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            double figureWidth = 3;
            double figureHeight = 4;
            double figureDepth = 5;

            Figure currentFigure = new Figure(figureWidth, figureHeight, figureDepth);

            Console.WriteLine("Volume = {0:f2}", currentFigure.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}",currentFigure.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", currentFigure.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", currentFigure.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", currentFigure.CalculateDiagonalYZ());
        }
    }
}
