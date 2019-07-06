using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using tesisCdagAsobiguaApi.Domain.Models;

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
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(p => p.UserType).IsRequired();
            modelBuilder.Entity<User>().HasIndex(p => p.Username).IsUnique();

            // REMEMBER TO ENCRYPT
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired();
            // REMEMBER TO ENCRYPT

            modelBuilder.Entity<User>().HasMany(p => p.Shots).WithOne(p => p.Player).HasForeignKey(p => p.PlayerId);
            //modelBuilder.Entity<User>().HasMany(p => p.Shots).WithOne(p => p.Trainer).HasForeignKey(p => p.TrainerId);
            modelBuilder.Entity<User>().HasMany(p => p.Logins).WithOne(p => p.Player).HasForeignKey(p => p.PlayerId);
            //modelBuilder.Entity<User>().HasMany(p => p.Logins).WithOne(p => p.Trainer).HasForeignKey(p => p.TrainerId);

            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = -1001,
                        Email = "trainer1@mail.com",
                        Name = "Trainer1Name",
                        LastName = "Trainer1Lastname",
                        Password = "asdf1234",
                        Username = "trainer1",
                        UserType = EUserType.Trainer
                    },
                    new User
                    {
                        Id = -2002,
                        Email = "player1@mail.com",
                        Name = "Player1Name",
                        LastName = "Player1Lastname",
                        Password = "asdf1234",
                        Username = "player1",
                        UserType = EUserType.Player
                    },
                    new User
                    {
                        Id = -3003,
                        Email = "player2@mail.com",
                        Name = "Player2Name",
                        LastName = "Player2Lastname",
                        Password = "asdf1234",
                        Username = "player2",
                        UserType = EUserType.Player
                    },
                    new User
                    {
                        Id = -4004,
                        Email = "player3@mail.com",
                        Name = "Player3Name",
                        LastName = "Player3Lastname",
                        Password = "asdf1234",
                        Username = "player3",
                        UserType = EUserType.Player
                    },
                    new User
                    {
                        Id = -5005,
                        Email = "trainer2@mail.com",
                        Name = "Traine2rName",
                        LastName = "Trainer2Lastname",
                        Password = "asdf1234",
                        Username = "trainer2",
                        UserType = EUserType.Trainer
                    }
                );

            modelBuilder.Entity<Shot>().ToTable("Shots");
            modelBuilder.Entity<Shot>().HasKey(p => p.Id);
            modelBuilder.Entity<Shot>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
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

            modelBuilder.Entity<Shot>().HasData
                (
                    new Shot
                    {
                        Id = -1001,
                        FollowThrough = 1,
                        Finesse = 3,
                        BackstrokePause = 4,
                        Finish = 0.4,
                        Jab = 3.7,
                        ShotInterval = 5.6,
                        Straightness = 9.2,
                        TipSteer = 4.4,
                        TimeStamp = DateTime.Now.AddMinutes(-5),
                        TrainerId = -1001,
                        PlayerId = -2002
                    },
                    new Shot
                    {
                        Id = -2002,
                        FollowThrough = 1,
                        Finesse = 3,
                        BackstrokePause = 4,
                        Finish = 0.4,
                        Jab = 3.7,
                        ShotInterval = 5.6,
                        Straightness = 9.2,
                        TipSteer = 4.4,
                        TimeStamp = DateTime.Now.AddMinutes(-5),
                        TrainerId = -1001,
                        PlayerId = -3003
                    },
                    new Shot
                    {
                        Id = -3003,
                        FollowThrough = 1,
                        Finesse = 3,
                        BackstrokePause = 4,
                        Finish = 0.4,
                        Jab = 3.7,
                        ShotInterval = 5.6,
                        Straightness = 9.2,
                        TipSteer = 4.4,
                        TimeStamp = DateTime.Now.AddMinutes(-5),
                        TrainerId = -1001,
                        PlayerId = -4004
                    },
                    new Shot
                    {
                        Id = -4004,
                        FollowThrough = 1,
                        Finesse = 3,
                        BackstrokePause = 4,
                        Finish = 0.4,
                        Jab = 3.7,
                        ShotInterval = 5.6,
                        Straightness = 9.2,
                        TipSteer = 4.4,
                        TimeStamp = DateTime.Now.AddMinutes(-5),
                        TrainerId = -5005,
                        PlayerId = -4004
                    }
                );

            modelBuilder.Entity<XyzShot>().ToTable("XyzShots");
            modelBuilder.Entity<XyzShot>().HasKey(p => p.Id);
            modelBuilder.Entity<XyzShot>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            modelBuilder.Entity<XyzShot>().Property(p => p.X).IsRequired();
            modelBuilder.Entity<XyzShot>().Property(p => p.Y).IsRequired();
            modelBuilder.Entity<XyzShot>().Property(p => p.Z).IsRequired();
            modelBuilder.Entity<XyzShot>().Property(p => p.TimeStamp).IsRequired();

            modelBuilder.Entity<XyzShot>().HasData
                (
                    new XyzShot
                    {
                        Id = -101,
                        ShotId = -1001,
                        TimeStamp = DateTime.Now.AddMilliseconds(-5),
                        X = 0.34,
                        Y = -2.35,
                        Z = 1.55
                    },
                    new XyzShot
                    {
                        Id = -202,
                        ShotId = -1001,
                        TimeStamp = DateTime.Now.AddMilliseconds(-4),
                        X = 0.34,
                        Y = -2.35,
                        Z = 1.55
                    },
                    new XyzShot
                    {
                        Id = -303,
                        ShotId = -1001,
                        TimeStamp = DateTime.Now.AddMilliseconds(-3),
                        X = 0.34,
                        Y = -2.35,
                        Z = 1.55
                    },
                    new XyzShot
                    {
                        Id = -404,
                        ShotId = -2002,
                        TimeStamp = DateTime.Now.AddMilliseconds(-5),
                        X = 0.34,
                        Y = -2.35,
                        Z = 1.55
                    },
                    new XyzShot
                    {
                        Id = -505,
                        ShotId = -3003,
                        TimeStamp = DateTime.Now.AddMilliseconds(-5),
                        X = 0.34,
                        Y = -2.35,
                        Z = 1.55
                    },
                    new XyzShot
                    {
                        Id = -606,
                        ShotId = -4004,
                        TimeStamp = DateTime.Now.AddMilliseconds(-5),
                        X = 0.34,
                        Y = -2.35,
                        Z = 1.55
                    },
                    new XyzShot
                    {
                        Id = -707,
                        ShotId = -4004,
                        TimeStamp = DateTime.Now.AddMilliseconds(-4),
                        X = 1.12,
                        Y = 2.42,
                        Z = -1.55
                    }
                );

            modelBuilder.Entity<Login>().ToTable("Logins");
            modelBuilder.Entity<Login>().HasKey(p => p.Id);
            modelBuilder.Entity<Login>().HasKey(p => p.TimeStamp);

            modelBuilder.Entity<Login>().HasData
                (
                    new Login { Id = -1001, TrainerId = -1001, PlayerId = -2002, TimeStamp = DateTime.Now.AddMinutes(-5) },
                    new Login { Id = -2002, TrainerId = -1001, PlayerId = -3003, TimeStamp = DateTime.Now.AddMinutes(-4) },
                    new Login { Id = -3003, TrainerId = -1001, PlayerId = -2002, TimeStamp = DateTime.Now.AddMinutes(-3) },
                    new Login { Id = -4004, TrainerId = -1001, PlayerId = -3003, TimeStamp = DateTime.Now.AddMinutes(-2) },
                    new Login { Id = -5005, TrainerId = -1001, PlayerId = -2002, TimeStamp = DateTime.Now.AddMinutes(-1) },
                    new Login { Id = -6006, TrainerId = -5005, PlayerId = -4004, TimeStamp = DateTime.Now }
                );

            
        }
    }
}
