namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.XmlHelp;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            string root = "Books";
            StringBuilder sb = new StringBuilder();

            BookImportXmlModel[] books = XmlConverter.Deserialize<BookImportXmlModel>(xmlString, root);

            foreach (var currBook in books)
            {
                if (!IsValid(currBook))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool parsedDate = DateTime.TryParseExact(
                    currBook.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var date);

                if (!parsedDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Book book = new Book
                {
                    Name = currBook.Name,
                    Genre = (Genre)currBook.Genre,
                    Price = currBook.Price,
                    Pages = currBook.Pages,
                    PublishedOn = date
                };

                context.Books.Add(book);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported book {book.Name} for {book.Price:F2}.");
                //sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            List<Author> authorsToAdd = new List<Author>();
            AuthorImportJsonModel[] authors = JsonConvert.DeserializeObject<AuthorImportJsonModel[]>(jsonString);


            foreach (var currAuthor in authors)
            {
                if (!IsValid(currAuthor))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Authors.Any(a => a.Email == currAuthor.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Author author = new Author
                {
                    FirstName = currAuthor.FirstName,
                    LastName = currAuthor.LastName,
                    Phone = currAuthor.Phone,
                    Email = currAuthor.Email
                };

                foreach (var currBook in currAuthor.Books)
                {
                    if (!currBook.BookId.HasValue)
                    {
                        continue;
                    }
                    Book book = context.Books.FirstOrDefault(x => x.Id == currBook.BookId);

                    if (book == null)
                    {
                        continue;
                    }
                    author.AuthorsBooks.Add(new AuthorBook()
                    {
                        Author = author,
                        Book = book
                    });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                authorsToAdd.Add(author);
                sb.AppendLine(string.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName,
                    author.AuthorsBooks.Count));
            }

            context.Authors.AddRange(authorsToAdd);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}