namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelp;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Books = x.AuthorsBooks
                    .OrderByDescending(x => x.Book.Price).
                    Select(x => new
                    {
                        BookName = x.Book.Name,
                        BookPrice = $"{x.Book.Price:F2}"
                    })
                    .ToList()
                })
                .ToList()
                .OrderByDescending(x => x.Books.Count())
                .ThenBy(x => x.AuthorName);

            var result = JsonConvert.SerializeObject(authors, Formatting.Indented);

            return result.ToString().TrimEnd();
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var books = context.Books.ToList()
                .Where(x => x.PublishedOn < date && x.Genre.ToString() == "Science")
                .Select(x => new BookExportXmlModel
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.Date)
                .Take(10)
                .ToList();

            string root = "Books";
            var result = XmlConverter.Serialize(books, root);

            return result.ToString().TrimEnd();
        }
    }
}