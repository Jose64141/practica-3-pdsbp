using Microsoft.EntityFrameworkCore;
using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.Data;

public class DataContext : DbContext
{
    public DbSet<User>? Users { get; set; }
     public DbSet<Book>? Books { get; set; }
     public DbSet<Reserve>? Reserves { get; set; }

    public DataContext(DbContextOptions options) : base(options)
    {
    }
}