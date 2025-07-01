using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions) 
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficalties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("949a1506-5b6a-4242-8bf9-0ad053ece225"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("deb1e3f2-e4e4-4d8e-ad2b-04a5e6859da7"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("f7d3ad4c-47f2-4773-8ac2-731a6da82bdb"),
                    Name = "Hard"
                }
            };
            //seed difficalties to DB
            modelBuilder.Entity<Difficulty>().HasData(difficalties);

            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("e5ae10b1-653f-4d97-bde8-70c71258b480"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.pexels.com/photo/auckland-city-with-a-view-of-the-sky-tower-new-zealand-17824133/"
                },
                new Region
                {
                    Id = Guid.Parse("add7dacc-8e4f-499c-859a-81f550e66ff0"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://www.pexels.com/photo/cape-reinga-lighthouse-at-sunset-north-island-new-zealand-17824120/"
                },
                new Region
                {
                    Id = Guid.Parse("bc0172df-33e1-4b24-b10c-5795bba96147"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://www.pexels.com/photo/crescent-shaped-coastline-of-mount-maunganui-in-new-zealand-21047861/"
                },
                new Region
                {
                    Id = Guid.Parse("00220bee-b7d6-4dc1-80f2-c968325cc30d"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://www.pexels.com/photo/brown-hanging-bridge-surrounded-by-trees-403781/"
                },
                new Region
                {
                    Id = Guid.Parse("7dd441bc-6edd-40f8-a21c-15a908621e99"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://www.pexels.com/photo/view-of-a-countryside-3396854/"
                },
                new Region
                {
                    Id = Guid.Parse("80393ee4-c338-4b54-a3c9-64c6f2e104f8"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://www.pexels.com/photo/calm-lake-1353248/"
                },
            };

            // seed regions to DB
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
