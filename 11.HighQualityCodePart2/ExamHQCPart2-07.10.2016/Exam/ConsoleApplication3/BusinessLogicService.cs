using ConsoleApplication3.Contracts;

namespace ConsoleApplication3
{
    public class BusinessLogicService
    {
        public void Execute(ISchoolSystemFactory schoolSystemFactory, IReader provider)
        {
            var engine = new SchoolSystemEngine(schoolSystemFactory, provider);

            engine.Start();
        }
    }
}
