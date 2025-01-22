using ApiFilms.Models;
using Microsoft.EntityFrameworkCore; //using microsoft library to manage DB

namespace ApiFilms.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) //base is called with "options" parametres
        {
            
        }

        //All models need to be passed here
        public DbSet<Category> Category { get; set; }
    }
}
