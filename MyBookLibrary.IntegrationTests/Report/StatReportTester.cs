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
            _books = JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadImageFreeFile());

        }

        [Test, Explicit]
        public void TestLongestBookReport()
        {
            string report = StatReporter.GetLongestBooks(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\longestBook.txt", report);
        }

        [Test, Explicit]
        public void TestAuthorReport()
        {
            string report = StatReporter.GetAuthorCountReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author.txt", report);
        }

        [Test, Explicit]
        public void TestAuthorReportByMinutes()
        {
            string report = StatReporter.GetAuthorMinutesReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author-by-minutes.txt", report);
        }

        [Test, Explicit]
        public void TestAuthorReportByRating()
        {
            string report = StatReporter.GetAuthorRatingsReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author-by-rating.txt", report);
        }

        [Test, Explicit]
        public void TestGroupByDecadeReport()
        {
            string report = StatReporter.GetDecadeReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\book-decade.txt", report);
        }

        [Test, Explicit]
        public void TestYearStatsReport()
        {
            string report = StatReporter.GetYearStatsReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\year-stats.txt", report);
        }

        [Test, Explicit]
        public void TestSeriesReport()
        {
            string report = StatReporter.GetSeriesReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\series.txt", report);
        }
    }
}
