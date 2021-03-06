﻿using System;
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
        private readonly IBookDatabaseReader _reader = new LocalDatabaseReader();

        [SetUp]
        public void Setup()
        {
            
            _books = JsonConvert.DeserializeObject<List<Book>>(_reader.ReadImageFreeFile());
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
        public void TestAuthorReportByRating()
        {
            string report = StatReporter.GetAuthorRatingsReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author-by-rating.txt", report);
        }

        [Test]
        public void TestSeriesReportByRating()
        {
            string report = StatReporter.GetSeriesRatingsReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\series-by-rating.txt", report);
        }

        [Test]
        public void TestMultiBookAuthorReportByRating()
        {
            string report = StatReporter.GetMultiBookAuthorRatingsReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\author-by-rating-multi.txt", report);
        }

        [Test]
        public void TestGroupByDecadeReport()
        {
            string report = StatReporter.GetDecadeReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\book-decade.txt", report);
        }

        [Test]
        public void TestYearStatsReport()
        {
            string report = StatReporter.GetYearStatsReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\year-stats.txt", report);
        }

        [Test]
        public void TestYearMonthReport()
        {
            string report = StatReporter.GetYearMonthReport(_books);

            Console.WriteLine(report);
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Source\year-month.txt", report);
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
