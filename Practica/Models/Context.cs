using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Practica.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) 
        {

        }

        public DbSet<autores> autores { get; set; }
        public DbSet<libros> libros { get; set; }
    }
}
