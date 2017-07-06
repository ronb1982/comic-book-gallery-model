using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        // Methods of changing the default name of the database
        // via Entity Framework
        
        // Method 1: Pass new database name to base class constructor
        //public Context() : base("ComicBookGallery")

        // Method 2: Pass entire connection string to base class constructor
        //public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicBookGalleryConnectionString;Integrated Security=True;MultipleActiveResultSets=True")
        //{
        //}

        // Method 3: Add connection string with the new database name to the app.config or web.config file
        // SEE App.config connectionString node

        public Context()
        { 
            // Drop and create database every time the model changes
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
