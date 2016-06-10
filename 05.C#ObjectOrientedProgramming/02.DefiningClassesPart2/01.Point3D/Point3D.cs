namespace _01.Point3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct Point3D
    {
        // Set coordinates for 3D Point
        private double x;
        private double y;
        private double z;

        //start of system
        private static readonly Point3D startOfCordinateSystem = new Point3D(0, 0, 0);

        // Set properties for coordinates x, y, z.
        //x property
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        //y property
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        //z property
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        //constructor
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // static constructor. Set starting coordinates, when set a new Point.
        public static Point3D Point3DStartingCoordinates
        {
            get {return startOfCordinateSystem; }
        }

        public override string ToString()
        {
            return string.Format("3D Point coordinates: {0}, {1}, {2}", this.X, this.Y, this.Z);
        }
    }
}
