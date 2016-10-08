using ConsoleApplication3.Factories;

namespace ConsoleApplication3
{
    public class Startup
    {
        public static void Main()
        {
            var provider = new ConsoleReaderProvider();
            var factory = new SchoolSystemFactory();
            var service = new BusinessLogicService();
            service.Execute(factory, provider);
        }
    }
}
