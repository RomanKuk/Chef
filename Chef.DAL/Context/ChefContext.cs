using Microsoft.EntityFrameworkCore;

namespace Chef.DAL.Context
{
    public class ChefContext : DbContext
    {

        public ChefContext(DbContextOptions<ChefContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
