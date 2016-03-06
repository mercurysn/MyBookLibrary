using MyBookLibrary.Service.ExtensionMethods;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.ExtensionMethod
{
    [TestFixture]
    public class TimeHelperTests
    {
        [Test]
        public void Test_ConvertTimeToMinutes()
        {
            const string time = "14:35:20";

            Assert.AreEqual("875", time.ConvertTimeToMinutes());
        }

        [Test]
        public void Test_ConvertMinuteToHourMinutes()
        {
            const int minutes = 875;

            Assert.AreEqual("14h 35m", minutes.ConvertMinuteToHoursMinutes());
        }
    }
}
