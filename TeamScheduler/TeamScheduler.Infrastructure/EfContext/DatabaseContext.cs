using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeamScheduler.Core.Entities;

namespace TeamScheduler.Infrastructure.EfContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<WorkUnit> WorkUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opitonsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkUnit>()
                .HasOne(b => b.Schedule)
                .WithMany(a => a.WorkUnits)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.OwnSchedules);
        }
    }
}
