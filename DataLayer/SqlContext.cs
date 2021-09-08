using DataLayer.Models;

using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    /// <summary>
    /// Todo: Install the following nuget packages
    /// Entity FrameworkCore
    /// Microsoft.EntityFrameworkCore.Tools
    /// Microsoft.EntityFrameworkCore.SqlServer
    /// 
    /// Tools -> Nuget Package manager -> Package manager console
    /// Create migration: add-migration #migration-name
    /// Update database: update-database
    /// 
    /// Install: Sql server (use localdb)
    /// Microsoft sql server management studio
    /// </summary>
    public class SqlContext : DbContext
    {
        public DbSet<StudentDto> Students { get; set; }

        public DbSet<School> Schools { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Todo: set connection string
            // set database name
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentDemo1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
