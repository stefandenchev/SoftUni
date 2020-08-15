using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SchoolLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split("&", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                var elements = input.Split(" | ");

                string command = elements[0];
                string book = elements[1];

                switch (command)
                {
                    case "Add Book":

                        if (!books.Contains(book))
                        {
                            books.Insert(0, book);
                        }
                        break;

                    case "Take Book":
                        if (books.Contains(book))
                        {
                            books.Remove(book);
                        }
                        break;

                    case "Swap Books":
                        var book2 = elements[2];

                        if (books.Contains(book) && books.Contains(book2))
                        {
                            int bookIndex = books.IndexOf(book);
                            int book2Index = books.IndexOf(book2);
                            string tempBook = book;
                            string tempBook2 = book2;

                            books.Remove(book);
                            books.Insert(book2Index, tempBook);
                            books.Remove(book2);
                            books.Insert(bookIndex, tempBook2);
                        }
                        break;

                    case "Insert Book":
                        books.Add(book);
                        break;

                    case "Check Book":
                        int index = int.Parse(book);
                        if (index >= 0 && index <= books.Count)
                        {
                            Console.WriteLine(books.ElementAt(index));
                        }
                        break;

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(", ", books));

        }
    }
}