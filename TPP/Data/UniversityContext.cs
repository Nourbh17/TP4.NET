
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using TPP.Models;

namespace TPP.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        private static UniversityContext instance = null;
        private UniversityContext(DbContextOptions o) : base(o) { }

        public static UniversityContext Instantiate_UniversityContext()
        {
            if (instance == null)
            {
                Debug.WriteLine("Initiation UniversityContext");
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite(@"Data Source =C:\Users\nourb\Downloads\2022 GL3 .NET Framework TP4 - SQLite database.db");
                instance = new UniversityContext(optionsBuilder.Options);
            }
            return instance;
        }



    }
}