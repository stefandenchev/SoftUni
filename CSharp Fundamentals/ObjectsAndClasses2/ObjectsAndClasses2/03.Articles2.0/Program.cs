using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string title = input[0];
                string content = input[1];
                string author = input[2];

                Article article = new Article(title, content, author);

                articles.Add(article);
            }
            string command = Console.ReadLine();

            switch (command)
            {
                case "title":
                    foreach (var article in articles.OrderBy(x => x.Title))
                    {
                        Console.WriteLine(article.ToString());
                    }
                    break;

                case "content":

                    foreach (var article in articles.OrderBy(x => x.Content))
                    {
                        Console.WriteLine(article.ToString());
                    }
                    break;

                case "author":
                    foreach (var article in articles.OrderBy(x => x.Author))
                    {
                        Console.WriteLine(article.ToString());
                    }
                    break;
            }
        }

        public class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
