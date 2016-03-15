using System.Collections.Generic;
using AsciiImportExport;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.Report
{
    public class StatReporter
    {
        public static string GetLongestBooks(List<Book> books)
        {
            IDocumentFormatDefinition<Book> definition = StatReportDefinition<int>.BookLengthReportBasicFormat();

            return definition.Export(books.SortBooksByMinutes());
        }

        public static string GetAuthorCountReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup<int>> definition = StatReportDefinition<int>.GenericBookGroupReportFormat();

            return definition.Export(books.DenormaliseAuthors().GroupByAuthorBookCount());
        }

        public static string GetAuthorMinutesReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup<int>> definition = StatReportDefinition<int>.GenericBookGroupReportFormat();

            return definition.Export(books.RemoveDuplicates().DenormaliseAuthors().GroupByAuthorMinutes());
        }

        public static string GetAuthorRatingsReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup<string>> definition = StatReportDefinition<string>.GenericBookGroupReportFormat();

            return definition.Export(books.RemoveDuplicates().DenormaliseAuthors().GroupByAuthorRatings());
        }

        public static string GetDecadeReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup<int>> definition = StatReportDefinition<int>.GenericBookGroupReportFormat();

            return definition.Export(books.GroupByDecade());
        }

        public static string GetYearStatsReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup<int>> definition = StatReportDefinition<int>.GenericBookGroupReportFormat();

            return definition.Export(books.YearStats());
        }

        public static string GetYearMonthReport(List<Book> books)
        {
            IDocumentFormatDefinition<MonthAggregatedGroup<int>> definition = StatReportDefinition<int>.MonthGroupReportFormat();

            return definition.Export(books.GroupByYearMonth());
        }

        public static string GetSeriesReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup<int>> definition = StatReportDefinition<int>.GenericBookGroupReportFormat();

            return definition.Export(books
                .DenormaliseAuthors()
                .RemoveBooksWithoutSeries()
                .GroupBySeries());
        }
    }
}
