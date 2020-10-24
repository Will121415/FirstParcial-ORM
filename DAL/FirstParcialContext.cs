using Entity;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class FirstParcialContext: DbContext
    {
        public FirstParcialContext(DbContextOptions options): base(options){}
        public DbSet<Person> Persons { get; set; }
        
        
    }
}