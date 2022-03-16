using MagiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MagiProject.Data.Context
{
    public partial class MagiProjectContext : DbContext
    {
        public MagiProjectContext()
        {
        }

        public MagiProjectContext(DbContextOptions<MagiProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CityName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
