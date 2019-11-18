namespace BookShop
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using BookShop.Models;
    using Data;

    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                string input = Console.ReadLine();

                string result = GetBooksByCategory(db, input);

                Console.WriteLine(result);
                
            }
        }

        //P01
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            foreach (var b in books)
            {
                sb.AppendLine(b.Title);
            }

            return sb.ToString().TrimEnd();
        }

        //P02
        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context
                .Books
                .Where(b => b.EditionType == Models.Enums.EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            var result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        //P03
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                });

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            var result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        //P05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var books = context
                .Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        //P06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var format = "dd-MM-yyyy";
            var provider = CultureInfo.InvariantCulture;
            var parsedDate = DateTime.ParseExact(date, format, provider);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < parsedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                });

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsNames = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}");

            var result = string.Join(Environment.NewLine, authorsNames);

            return result;
        }

        //P08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();

            var bookTitles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input))
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            var result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        //P09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var booksAndAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})");

            var result = string.Join(Environment.NewLine, booksAndAuthors);

            return result;
        }

        //P10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(b => b.Title.Length > lengthCheck);

            return books.Count();
        }

        //P11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    BooksCount = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.BooksCount);

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.BooksCount}");
            }

            return sb.ToString().TrimEnd();
        }

        //P12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                    .Select(cb => cb.Book.Copies * cb.Book.Price).Sum()
                })
                .OrderByDescending(c => c.TotalProfit);

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //P13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context
                .Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                            .OrderByDescending(cb => cb.Book.ReleaseDate)
                            .Take(3)
                            .Select(cb => new
                            {
                                cb.Book.Title,
                                cb.Book.ReleaseDate.Value.Year
                            })
                            .ToList()
                });

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //P14
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //P15
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count();
        }
    }
}
