using AsciiImportExport;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.Report
{
    public class StatReportDefinition
    {
        public static IDocumentFormatDefinition<Book> GetBookLengthBasic()
        {
            return new DocumentFormatDefinitionBuilder<Book>("\t", true)
                .SetExportHeaderLine(true, "")
                .AddColumn(x => x.Name)
                .AddColumn(x => x.Author, b => b.SetExportFunc(ConcatAuthors))
                .AddColumn(x => x.Minutes, b => b.SetAlignment(ColumnAlignment.Right))
                .AddColumn(x => x.Pages, b => b.SetAlignment(ColumnAlignment.Right))
                .AddColumn(x => x.Series)
                .Build();
        }

        public static IDocumentFormatDefinition<BookAggregatedGroup> GetBookGroupDefinition()
        {
            return new DocumentFormatDefinitionBuilder<BookAggregatedGroup>("\t", true)
                .SetExportHeaderLine(true, "")
                .AddColumn(x => x.Field)
                .AddColumn(x => x.Value, b => b.SetAlignment(ColumnAlignment.Right))
                .Build();
        }



        public static string ConcatAuthors(Book book, string[] authors)
        {
            return string.Join(", ", authors);
        } 
    }
}
