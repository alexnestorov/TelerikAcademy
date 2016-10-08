using ConsoleApplication3;
using ConsoleApplication3.Contracts;
using Moq;
using NUnit.Framework;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class SchoolSystemEngineTests
    {
        [Test]
        public void EngineWhenInstanced_ShouldPassCorrectly()
        {
            var mockedSchoolSystemFactory = new Mock<ISchoolSystemFactory>();
            var mockedCommandProvider = new Mock<IReader>();

            var engine = new SchoolSystemEngine(mockedSchoolSystemFactory.Object, mockedCommandProvider.Object);

            Assert.IsInstanceOf<IEngine>(engine);
        }

        //[Test]
        //public void MethodStart_ShouldPassCorrectly_WhenBusinessLogicServiceIsCalled()
        //{
        //    var mockedSchoolSystemFactory = new Mock<ISchoolSystemFactory>();
        //    var mockedCommandProvider = new Mock<IReader>();
        //    var mockedBusinessLogicServices = new Mock<BusinessLogicService>();

        //    var engine = new SchoolSystemEngine(mockedSchoolSystemFactory.Object, mockedCommandProvider.Object);

        //    Assert.DoesNotThrow(() => mockedBusinessLogicServices.Object.Execute(
        //        mockedSchoolSystemFactory.Object, mockedCommandProvider.Object));
        //}
    }
}
