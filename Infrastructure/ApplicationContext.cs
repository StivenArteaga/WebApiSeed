using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure
{
    public class ApplicationContext : DbContext, Configuration.IDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }


        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

    }
}
