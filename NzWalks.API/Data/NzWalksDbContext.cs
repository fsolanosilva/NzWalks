using Microsoft.EntityFrameworkCore;
using NzWalks.API.Models.Domain;

namespace NzWalks.API.Data
{
    public class NzWalksDbContext : DbContext
    {
        public NzWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            // Easy, medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("d032d151-9a86-4166-b42f-efd6ab034b5d"),
                    Name = "Easy",
                },
                 new Difficulty()
                {
                    Id =  Guid.Parse("c38f1745-3b69-47d1-b7c0-8ca84b559770"),
                    Name = "Medium",
                },
                  new Difficulty()
                {
                    Id =  Guid.Parse("de6f2a3f-623c-4dce-bf11-01868a1d5c70"),
                    Name = "Hard",
                },
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed Data for regions
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("1a8921b8-0e47-4cf2-94c6-309b3e969799"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("303caa3a-37bb-45b0-8f30-f032bc3aa9b4"),
                    Name = "NorthLand",
                    Code = "NTL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("154a22b2-ba16-4b45-997d-84df1f9f5601"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("fe8e70bf-5175-44c6-90c7-71f5f4c070cc"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("fdd20847-05aa-47ca-b202-f2e5dfb83c3b"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                },
                new Region()
                {
                    Id = Guid.Parse("f441a618-bd63-4457-8009-64f825019c80"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
