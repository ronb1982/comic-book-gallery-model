using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookGalleryModel.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                // This line will output any SQL or database-related queries and operations
                // to the Output window for debugging purposes
                context.Database.Log = (message) => Debug.WriteLine(message);

                //var comicBooks = context.ComicBooks.ToList();

                // Filter comic books by title where title contains the word "man"
                /*var comicBooks = context.ComicBooks
                                 .Include(cb => cb.Series)
                                 .Where(cb => cb.Series.Title.Contains("man"))
                                 .ToList();*/

                // Sort by issue number descending
                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    .ThenBy(cb => cb.PublishedOn)
                //    .ToList();

                var comicBooksQuery = context.ComicBooks
                    .Include(cb => cb.Series) // Eager load Series entity
                    .OrderByDescending(cb => cb.IssueNumber);

                var comicBooks = comicBooksQuery.ToList();

                var comicBooks2 = comicBooksQuery
                    .Where(cb => cb.AverageRating < 7)
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }

                Console.WriteLine();
                Console.WriteLine("# of comic books: {0}", comicBooks.Count);
                Console.WriteLine();

                foreach (var comicBook in comicBooks2)
                {
                    Console.WriteLine(comicBook.DisplayText);
                }

                Console.WriteLine();
                Console.WriteLine("# of comic books: {0}", comicBooks2.Count);

                //// Get all comic books - include any relational objects
                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a => a.Artist))
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    var artistRoleNames = comicBook.Artists.Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                //    var artistRolesDisplayText = string.Join(", ", artistRoleNames);
                //    Console.WriteLine(comicBook.DisplayText);
                //    Console.WriteLine(artistRolesDisplayText);
                //}

                Console.ReadLine();
            }
        }
    }
}
