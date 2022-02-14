using RestfulApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RestfulApi.Repository.Persistence
{
    public class RestfulApiDbContext : DbContext
    {
        public RestfulApiDbContext(DbContextOptions<RestfulApiDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
