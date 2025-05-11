using Microsoft.EntityFrameworkCore;
using TestSoftwareDeveloperGetechnologiesMxDotnetApi.Models;

namespace TestSoftwareDeveloperGetechnologiesMxDotnetApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Person)
                .WithMany(p => p.Bills)
                //.HasForeignKey(b => b.PersonIdentification)
                .HasForeignKey(b => b.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
                //.HasPrincipalKey(p => p.Identification);
        }
    }
}
