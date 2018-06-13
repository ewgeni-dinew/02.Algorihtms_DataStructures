namespace EventManager.Data
{
    using EventManager.Data.EntityConfig;
    using EventManager.Models;
    using Microsoft.EntityFrameworkCore;

    public class EventManagerContext : DbContext
    {
        public EventManagerContext()
        {

        }

        public EventManagerContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfig());
        }
    }
}
