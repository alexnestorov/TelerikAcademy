namespace _01.Point3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Point3DProgram
    {
        static void Main()
        {
            // Add some points.
            Point3D firstPoint = new Point3D(2,2,2);
            Point3D secondPoint = new Point3D(4,4,4);
            Point3D thirdPoint = new Point3D(6,6,6);
            Point3D fourthPoint = new Point3D(8,8,8);
            Point3D fifthPoint = new Point3D(9,9,9);

            Path path = new Path();

            // Add points in path.
            path.AddPoint(firstPoint);
            path.AddPoint(secondPoint);
            path.AddPoint(thirdPoint);
            path.AddPoint(fourthPoint);
            path.AddPoint(fifthPoint);

            // Remove last 3D point.
            path.RemovePoint(fifthPoint);

            // Remove point at index.
            path.RemovePointAt(2);

            // Change values for all 3D points.
            for (int i = 0; i < path.Count; i++)
            {
                path[i] = new Point3D(i + 1, i * 2, i + 3);
            }

            string inputFile = @"../../IOFiles/inputFile.txt";
            PathStorage.SavePath(inputFile, path);


            //string outputFile = @"../../IOFiles/outputFile.txt";
            //sPath pathFromFile = PathStorage.LoadPath(outputFile);
        }
    }
}
