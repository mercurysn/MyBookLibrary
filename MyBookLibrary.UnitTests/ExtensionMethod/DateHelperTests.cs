using MyBookLibrary.Service.ExtensionMethods;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.ExtensionMethod
{
    [TestFixture]
    public class DateHelperTests
    {
        [Test]
        public void Test_Convert_To_Decade()
        {
            int year1 = 2013;
            int year2 = 2019;

            Assert.AreEqual(2010, year1.ToDecade());
            Assert.AreEqual(2010, year2.ToDecade());
        }
    }
}
