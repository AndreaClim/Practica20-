using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Practica.Models
{
    public class librosContext : DbContext  
    {
        public librosContext(DbContextOptions<librosContext> options) : base(options) 
        {
            
        }
    }
}
