using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using tesisCdagAsobiguaApi.Converters;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Extensions;

namespace tesisCdagAsobiguaApi.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Shot> Shots { get; set; }
        public DbSet<XyzShot> XyzShots { get; set; }
        public DbSet<Login> Logins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.UserType).IsRequired();
            modelBuilder.Entity<User>().HasIndex(p => p.Username).IsUnique();

            // REMEMBER TO ENCRYPT
            modelBuilder.Entity<User>().Property(p => p.Password).HasColumnType("binary(64)").IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Password).HasConversion(new PasswordEncryptionConverter());
            // REMEMBER TO ENCRYPT

            modelBuilder.Entity<User>().HasMany(p => p.Shots).WithOne(p => p.Player).HasForeignKey(p => p.PlayerId);
            modelBuilder.Entity<User>().HasMany(p => p.Logins).WithOne(p => p.Trainer).HasForeignKey(p => p.TrainerId);

            modelBuilder.Entity<Shot>().ToTable("Shots");
            modelBuilder.Entity<Shot>().HasKey(p => p.Id);
            modelBuilder.Entity<Shot>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Shot>().Property(p => p.Jab).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.ShotInterval).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.Straightness).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.TipSteer).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.Finesse).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.Finish).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.FollowThrough).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.BackstrokePause).IsRequired();
            modelBuilder.Entity<Shot>().Property(p => p.TimeStamp).IsRequired();
            modelBuilder.Entity<Shot>().HasMany(p => p.XyzShots).WithOne(p => p.Shot).HasForeignKey(p => p.ShotId);

            modelBuilder.Entity<XyzShot>().ToTable("XyzShots");
            modelBuilder.Entity<XyzShot>().HasKey(p => p.Id);
            modelBuilder.Entity<XyzShot>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<XyzShot>().Property(p => p.X).IsRequired();
            modelBuilder.Entity<XyzShot>().Property(p => p.Y).IsRequired();
            modelBuilder.Entity<XyzShot>().Property(p => p.Z).IsRequired();
            modelBuilder.Entity<XyzShot>().Property(p => p.TimeStamp).IsRequired();

            modelBuilder.Entity<Login>().ToTable("Logins");
            modelBuilder.Entity<Login>().HasKey(p => p.Id);
            modelBuilder.Entity<Login>().Property(p => p.TimeStamp).IsRequired();
        }
    }
}
