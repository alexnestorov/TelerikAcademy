namespace _01.Point3D
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PathStorage
    {
        public static void SavePath(string inputFile, Path path)
        {
            try
            {
                File.WriteAllText(inputFile, path.ToString());
            }
            catch (AccessViolationException avex)
            {

                throw avex;
            }
            catch (IOException ioex)
            {
                throw ioex;
            }
        }
        public static void LoadPath(string outputFile)
        {
            Path path = new Path();
            try
            {

                string text = File.ReadAllText(outputFile);
                string[] points = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var point in points)
                {
                    string[] coordinates = point.Split(new string[] { ",", ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
                    double x = double.Parse(coordinates[0]);
                    double y = double.Parse(coordinates[1]);
                    double z = double.Parse(coordinates[2]);
                    path.AddPoint(new Point3D(x, y, z));
                }

            }
            catch (FileNotFoundException fnfe)
            {

                Console.WriteLine("####The file is not found");
                throw fnfe;
            }
            catch (IOException ioex)
            {
                throw ioex;
            }
        }
    }
}
