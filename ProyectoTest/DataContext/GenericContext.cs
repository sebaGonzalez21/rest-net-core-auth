using Microsoft.EntityFrameworkCore;
using ProyectoTest.Model;
/**
 * Sebastian Gonzalez
 * */
namespace ProyectoTest.DataContext
{
    public class GenericContext : DbContext
    {
        public GenericContext(DbContextOptions<GenericContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Client> Client { get; set; }
    }
}
