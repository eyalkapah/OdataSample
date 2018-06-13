using System;
using Microsoft.EntityFrameworkCore;
using OdataSample.App.Configurations;
using OdataSample.App.Models;

namespace OdataSample.App
{
    public class MondialDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }

        public MondialDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());

            modelBuilder.Entity<Group>().HasData(
                new Group { Id = 1, Name = 'A' },
                new Group { Id = 2, Name = 'B' },
                new Group { Id = 3, Name = 'C' },
                new Group { Id = 4, Name = 'D' },
                new Group { Id = 5, Name = 'E' },
                new Group { Id = 6, Name = 'F' },
                new Group { Id = 7, Name = 'G' },
                new Group { Id = 8, Name = 'H' });

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, GroupId = 1, Name = "Russia", Rank = 61 },
                new Team { Id = 2, GroupId = 1, Name = "Saudi Arabia", Rank = 64 },
                new Team { Id = 3, GroupId = 1, Name = "Egypt", Rank = 43 },
                new Team { Id = 4, GroupId = 1, Name = "Uruguay", Rank = 22 },
                new Team { Id = 5, Name = "Portugal", GroupId = 2, Rank = 3 },
                new Team { Id = 6, Name = "Spain", GroupId = 2, Rank = 6 },
                new Team { Id = 7, Name = "Morocco", GroupId = 2, Rank = 42 },
                new Team { Id = 8, Name = "Iran", GroupId = 2, Rank = 33 },
                new Team { Id = 9, Name = "France", GroupId = 3, Rank = 9 },
                new Team { Id = 10, Name = "Australia", GroupId = 3, Rank = 36 },
                new Team { Id = 11, Name = "Peru", GroupId = 3, Rank = 11 },
                new Team { Id = 12, Name = "Denmark", GroupId = 3, Rank = 12 },
                new Team { Id = 13, Name = "Argentina", GroupId = 4, Rank = 4 },
                new Team { Id = 14, Name = "Iceland", GroupId = 4, Rank = 18 },
                new Team { Id = 15, Name = "Croatia", GroupId = 4, Rank = 15 },
                new Team { Id = 16, Name = "Nigeria", GroupId = 4, Rank = 52 },
                new Team { Id = 17, Name = "Brazil", GroupId = 5, Rank = 2 },
                new Team { Id = 18, Name = "Switzerland", GroupId = 5, Rank = 8 },
                new Team { Id = 19, Name = "Costa Rica", GroupId = 5, Rank = 25 },
                new Team { Id = 20, Name = "Serbia", GroupId = 5, Rank = 34 },
                new Team { Id = 21, Name = "Germany", GroupId = 6, Rank = 1 },
                new Team { Id = 22, Name = "Mexico", GroupId = 6, Rank = 17 },
                new Team { Id = 23, Name = "Sweden", GroupId = 6, Rank = 19 },
                new Team { Id = 24, Name = "South Korea", GroupId = 6, Rank = 58 },
                new Team { Id = 25, Name = "Belgium", GroupId = 7, Rank = 5 },
                new Team { Id = 26, Name = "Panama", GroupId = 7, Rank = 53 },
                new Team { Id = 27, Name = "Tunisia", GroupId = 7, Rank = 23 },
                new Team { Id = 28, Name = "England", GroupId = 7, Rank = 16 },
                new Team { Id = 29, Name = "Poland", GroupId = 8, Rank = 7 },
                new Team { Id = 30, Name = "Senegal", GroupId = 8, Rank = 27 },
                new Team { Id = 31, Name = "Colombia", GroupId = 8, Rank = 13 },
                new Team { Id = 32, Name = "Japan", GroupId = 8, Rank = 55 });

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    Id = 1,
                    Name = "Cristiano Ronaldo",
                    BirthDate = new DateTime(1985, 2, 5),
                    Position = "Forward",
                    TeamId = 5
                },
                new Player
                {
                    Id = 2,
                    Name = "Lionel Messi",
                    BirthDate = new DateTime(1987, 6, 24),
                    Position = "Forward",
                    TeamId = 13
                });

        }
    }
}