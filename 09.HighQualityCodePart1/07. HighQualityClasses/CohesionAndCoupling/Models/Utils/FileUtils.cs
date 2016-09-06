namespace CohesionAndCoupling.Models.Utils
{
    using System;

    public static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot < 0)
            {
                throw new ArgumentOutOfRangeException("File name has not extension.");
            }

            string extension = fileName.Substring(indexOfLastDot + 1, fileName.Length - indexOfLastDot - 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot < 0)
            {
                return fileName;
            }

            string withoutExtension = fileName.Substring(0, indexOfLastDot);
            return withoutExtension;
        }
    }
}
