﻿using System;
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

                // EAGER LOAD - Get all comic books -include any relational objects.
                    // Executes a single query to get all data.
                /*var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();*/

                // LAZY LOAD - Get all comic books -include any relational objects
                    // Make related navigational properties "virtual" in the ComicBook and
                    // ComicBookArtist classes in order for Entity Framework to create
                    // dynamic proxies. These dynamic proxies are child classes that
                    // EF creates to access relational data at runtime.
                    // A SQL query is executed every time an object reference is used.
                var comicBooks = context.ComicBooks.ToList();

                foreach (var comicBook in comicBooks)
                {
                    // EXPLICIT LOADING
                        // Explicitly call Load() on an Entry object's Reference or Collection
                        // navigational property. Check for null before calling this operation
                        // to load a new entity into memory.
                    if (comicBook.Series == null)
                    {
                        context.Entry(comicBook)
                            .Reference(cb => cb.Series)
                            .Load();
                    }

                    var artistRoleNames = comicBook.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();
                    var artistRolesDisplayText = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.DisplayText);
                    Console.WriteLine(artistRolesDisplayText);
                }

                Console.ReadLine();
            }
        }
    }
}
