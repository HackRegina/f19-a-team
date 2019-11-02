using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NeedleBuddy.DB
{
    public partial class NeedleBuddyContext : DbContext
    {
        public NeedleBuddyContext()
        {
        }

        public NeedleBuddyContext(DbContextOptions<NeedleBuddyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dropofflocation> Dropofflocation { get; set; }
        public virtual DbSet<Pickuprequest> Pickuprequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dropofflocation>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Pickuprequest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
