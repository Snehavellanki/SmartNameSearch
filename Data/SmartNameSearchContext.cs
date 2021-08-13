using Microsoft.EntityFrameworkCore;
using SmartNameSearch.Models;

namespace SmartNameSearch.Data
{
    public class SmartNameSearchContext : DbContext
    {
        public SmartNameSearchContext (DbContextOptions<SmartNameSearchContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleNames>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToTable("Sp_People_Names");
                eb.Property(v => v.label).HasColumnName("Name");
            });
        }

        public DbSet<People> People { get; set; }
        public DbSet<PeopleNames> PeopleNames { get; set; }
    }
}
