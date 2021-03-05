namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, input)); 
            //Console.WriteLine(GetGoldenBooks(db)); 
            //Console.WriteLine(GetBooksByPrice(db)); 
            //Console.WriteLine(GetBooksNotReleasedIn(db, input)); 
            //Console.WriteLine(GetBooksByCategory(db, input));
            //Console.WriteLine(GetBooksReleasedBefore(db, input));
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));
            //Console.WriteLine(GetBookTitlesContaining(db, input));
            //Console.WriteLine(GetBooksByAuthor(db, input));
            //Console.WriteLine(CountBooks(db, input));
            //Console.WriteLine(CountCopiesByAuthor(db));
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            Console.WriteLine(RemoveBooks(db)); 

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .AsEnumerable()
                .Where(x => x.AgeRestriction
                    .ToString()
                    .ToLower() == command.ToLower())
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .AsEnumerable()
                .Where(x => x.EditionType
                    .ToString() == "Gold" && x.Copies < 5000)
                .Select(x => new
                {
                    Title = x.Title,
                    Id = x.BookId
                })
                .OrderBy(x => x.Id)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new
                {
                    Title = x.Title,
                    Price = x.Price
                })
                .OrderByDescending(x => x.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .Select(x => new
                {
                    Title = x.Title,
                    Id = x.BookId
                })
                .OrderBy(x => x.Id)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToList();

            List<string> books = new List<string>();

            foreach (var category in categories)
            {
                List<string> current = context.Books
                    .Where(x => x.BookCategories.Any(x => x.Category.Name.ToLower()
                    == category))
                    .Select(x => x.Title)
                    .ToList();

                books.AddRange(current);
            }

            return String.Join(Environment.NewLine, books.OrderBy(x => x));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dt = DateTime.ParseExact(date.ToString(),
                "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < dt)
                .Select(x => new
                {
                    Title = x.Title,
                    Edition = x.EditionType.ToString(),
                    Price = x.Price,
                    Date = x.ReleaseDate
                })
                .OrderByDescending(x => x.Date)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Edition} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    FullName = x.FirstName + " " + x.LastName
                })
                .OrderBy(x => x.FullName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var au in authors)
            {
                sb.AppendLine(au.FullName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var contains = input.ToLower();

            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(contains))
                .Select(x => new
                {
                    Title = x.Title
                })
                .OrderBy(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var contains = input.ToLower();

            var books = context.Books             
                .Select(x => new
                {
                    Id = x.BookId,
                    Title = x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .Where(x => x.AuthorLastName.ToLower().StartsWith(contains))
                .OrderBy(x => x.Id)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName + " " + book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors             
                .Select(x => new
                {
                    Name = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.Name} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Profit = x.CategoryBooks.Select(x => new
                    { 
                        BookProfit = x.Book.Price * x.Book.Copies
                    })
                    .Sum(x => x.BookProfit)
                })
                .OrderByDescending(x => x.Profit)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Name = x.Name,
                    Books = x.CategoryBooks.Select(x => new
                    {
                        BookTitle = x.Book.Title,
                        ReleaseDate = x.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseDate.Value.Year.ToString()})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            var count = books.Count();

            foreach (var book in books)
            {
                context.Remove(book);
            }

            context.SaveChanges();
            return count;
        }
    }
}
