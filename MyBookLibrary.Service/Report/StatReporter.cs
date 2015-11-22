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
            IDocumentFormatDefinition<Book> definition = StatReportDefinition.BookLengthReportBasicFormat();

            return definition.Export(books.SortBooksByMinutes());
        }

        public static string GetAuthorCountReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup> definition = StatReportDefinition.GenericBookGroupReportFormat();

            return definition.Export(books.DenormaliseAuthors().GroupByAuthorBookCount());
        }

        public static string GetAuthorMinutesReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup> definition = StatReportDefinition.GenericBookGroupReportFormat();

            return definition.Export(books.DenormaliseAuthors().GroupByAuthorMinutes());
        }

        public static string GetSeriesReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup> definition = StatReportDefinition.GenericBookGroupReportFormat();

            return definition.Export(books
                .DenormaliseAuthors()
                .RemoveBooksWithoutSeries()
                .GroupBySeries());
        }
    }
}
