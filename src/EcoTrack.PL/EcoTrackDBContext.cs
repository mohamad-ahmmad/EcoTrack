using EcoTrack.PL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoTrack.PL
{
    public class EcoTrackDBContext : DbContext
    {
        public EcoTrackDBContext()
        {

        }
        public EcoTrackDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }  
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EnviromentalReport> EnviromentalReports { get; set; }
        public DbSet<EnviromentalReportsTopic> enviromentalReportsTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedingLocations(modelBuilder);
            SeedingUsers(modelBuilder);
        }       

        private void SeedingLocations(ModelBuilder mb)
        {
            mb.Entity<Location>().HasData
                (
                    new Location
                    {
                        LocationId = -10,
                        CityName = "Nablus",
                        CountryName = "Palestine"
                    },
                    new Location
                    {

                        LocationId= -9,
                        CityName="Jenin",
                        CountryName="Palestine"
                    },
                    new Location
                    {
                        LocationId=-8,
                        CityName="Tokyo",
                        CountryName="Japan"
                    },
                    new Location
                    {
                        LocationId = -7,
                        CityName ="Seoul",
                        CountryName="North Korea"
                    }
                    
                );
        }
        private void SeedingUsers(ModelBuilder mb)
        {
            mb.Entity<User>().HasData
                (
                    new User
                    {
                        UserId = -10,
                        Username="morse",
                        Password= "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                        Email="morsee@egy.pt",
                        FirstName="Mer'e",
                        LastName="Pharaoh",
                        Deleted=false,
                        BirthDate=DateTime.Now,
                        LocationId= -10,
                        
                    },
                    new User
                    {
                        UserId= -9, 
                        Username = "mohammad",
                        Password = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                        Email = "moghrabi@egy.pt",
                        FirstName = "Sal",
                        LastName = "Tan",
                        Deleted = false,
                        BirthDate = DateTime.Now,
                        LocationId = -8
                    }
                );;   
        }
    }
}
