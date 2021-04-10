using Day3_Core_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day3_Core_ITI
{
    public class TracksContext : DbContext
    {

        public TracksContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTrack>().HasKey(sc => new { sc.TackId, sc.CourseId });
        }
        //entities
        public DbSet<Trainee> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<CourseTrack> CourseTracks { get; set; }
    }
}
