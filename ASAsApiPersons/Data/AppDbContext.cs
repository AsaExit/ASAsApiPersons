using ASAsApiPersons.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ASAsApiPersons.Data
{
    public class AppDbContext:DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; } = default!;
    }
}

