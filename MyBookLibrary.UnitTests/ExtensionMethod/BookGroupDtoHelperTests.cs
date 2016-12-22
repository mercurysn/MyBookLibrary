using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;
using NUnit.Framework;

namespace MyBookLibrary.UnitTests.ExtensionMethod
{
    [TestFixture]
    public class BookGroupDtoHelperTests
    {
        [Test]
        public void Test_ComputeRankPercentile()
        {
            List<BookGroupDto> bookGroups = new List<BookGroupDto>
            {
                new BookGroupDto
                {
                    Name = "2016",
                    TotalTime = 100
                },
                new BookGroupDto
                {
                    Name = "2015",
                    TotalTime = 10
                },
                new BookGroupDto
                {
                    Name = "2014",
                    TotalTime = 150
                }
            };

            var result = bookGroups.ComputeRankPercentile().ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("2014", result[0].Name);
            Assert.AreEqual("2016", result[1].Name);
            Assert.AreEqual("2015", result[2].Name);
            Assert.AreEqual(100, result[0].Percentile);
            Assert.AreEqual(50, result[1].Percentile);
            Assert.AreEqual(0, result[2].Percentile);
        }
    }
}
