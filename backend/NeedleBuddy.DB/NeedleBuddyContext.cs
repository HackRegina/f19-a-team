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

        public virtual DbSet<Adminusers> Adminusers { get; set; }
        public virtual DbSet<Clientsecret> Clientsecret { get; set; }
        public virtual DbSet<Dropofflocation> Dropofflocation { get; set; }
        public virtual DbSet<Pickuprequest> Pickuprequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminusers>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn();
            });

            modelBuilder.Entity<Clientsecret>(entity =>
            {
                entity.HasNoKey();
            });

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
