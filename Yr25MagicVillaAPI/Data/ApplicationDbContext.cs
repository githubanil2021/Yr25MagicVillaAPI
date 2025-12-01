using Microsoft.EntityFrameworkCore;
using Yr25MagicVillaAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Yr25MagicVillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) { }
        
            
        
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<LocalUser> LocalUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id=1,
                    Name="Royal Villa",
                    Details="Royal villa details",
                    ImageUrl= "https://www.pixelstalk.net/wp-content/uploads/images1/House-Wallpapers-HD-Free-download.jpg",
                    Occupancy=5,
                    Rate=100,
                    Sqft=101,
                    Amenity=""
                },
                new Villa()
                {
                Id = 2,
                    Name = "Diamond Pool Villa",
                    Details = "Diamond Pool Villa details",
                    ImageUrl = "https://tse3.mm.bing.net/th/id/OIP.UoGwhRnp0aERT5c1oVplOgHaFg?rs=1&pid=ImgDetMain&o=7&rm=3",
                    Occupancy = 2,
                    Rate = 200,
                    Sqft = 201,
                    Amenity = "*"
                }
                );        
        }

    }
}
