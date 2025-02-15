using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;  

namespace Practica.Models
{
    public class autoresContext : DbContext
    {
        public autoresContext(DbContextOptions<autoresContext> options) : base(options)
        {

        }
    }
    
    }

