using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBookmakerSystem;Integrated Security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(x => new { x.PlayerId, x.GameId });


            modelBuilder.Entity<Team>().HasOne(x => x.PrimaryKitColor)
                           .WithMany(x => x.PrimaryKitTeams)
                           .HasForeignKey(k => k.PrimaryKitColorId)
                           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>().HasOne(x => x.SecondaryKitColor)
                           .WithMany(x => x.SecondaryKitTeams)
                           .HasForeignKey(k => k.SecondaryKitColorId)
                           .OnDelete(DeleteBehavior.Restrict);


            /*modelBuilder.Entity<Color>(x =>
            {
                x.HasMany(x => x.PrimaryKitTeams)
                .WithOne(x => x.PrimaryKitColor)
                .HasForeignKey(k => k.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.SetNull);

                x.HasMany(x => x.SecondaryKitTeams)
                .WithOne(x => x.SecondaryKitColor)
                .HasForeignKey(k => k.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.SetNull);
            });*/


            modelBuilder.Entity<Game>(x =>
            {
                x.HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .HasForeignKey(k => k.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(x => x.AwayTeam)
               .WithMany(x => x.AwayGames)
               .HasForeignKey(k => k.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}