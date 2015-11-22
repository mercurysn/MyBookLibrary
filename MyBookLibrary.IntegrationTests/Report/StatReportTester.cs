using System;
using System.Collections.Generic;
using System.IO;
using MyBookLibrary.Data;
using MyBookLibrary.Service.Model;
using MyBookLibrary.Service.Report;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MyBookLibrary.IntegrationTests.Report
{
    [TestFixture]
    public class StatReportTester
    {
        private List<Book> _books = new List<Book>();

        [SetUp]
        public void Setup()
        {
            _books = JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadFile());

        }

        [Test]
        public void TestLongestBookReport()
        {
            string report = StatReporter.GetLongestBooks(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\longestBook.txt", report);
        }

        [Test]
        public void TestAuthorReport()
        {
            string report = StatReporter.GetAuthorCountReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author.txt", report);
        }

        [Test]
        public void TestAuthorReportByMinutes()
        {
            string report = StatReporter.GetAuthorMinutesReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author-by-minutes.txt", report);
        }

        [Test]
        public void TestSeriesReport()
        {
            string report = StatReporter.GetSeriesReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\series.txt", report);
        }
    }
}
