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
            IDocumentFormatDefinition<Book> definition = StatReportDefinition.GetBookLengthBasic();

            return definition.Export(books.SortBooksByMinutes());
        }

        public static string GetAuthorReport(List<Book> books)
        {
            IDocumentFormatDefinition<BookAggregatedGroup> definition = StatReportDefinition.GetBookGroupDefinition();

            return definition.Export(books.DenormaliseAuthors().GroupByAuthor());
        }
    }
}
