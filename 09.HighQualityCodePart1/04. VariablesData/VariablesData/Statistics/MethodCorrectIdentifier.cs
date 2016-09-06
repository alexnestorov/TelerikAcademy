using VariablesData.Statistics.Extensions;

namespace VariablesData
{
    public class StatisticsProgram
    {
        public static void Main(string[] args)
        {
            var array = new[] { 5.3, 200, -4, 1521, -10 };
            array.PrintStatistics();
        }
    }
}
