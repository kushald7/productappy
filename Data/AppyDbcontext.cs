using Microsoft.EntityFrameworkCore;
using WebAppy.Models;

namespace WebAppy.Data
{
    public class AppyDbcontext : DbContext
    {
        
        public AppyDbcontext(DbContextOptions<AppyDbcontext> options): base(options) 
        {
            
        }
        public DbSet<Product> Products {get; set;}
       
    }
}
