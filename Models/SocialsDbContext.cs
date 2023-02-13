using Microsoft.EntityFrameworkCore;

namespace Socials.Models
{
	public class SocialsDbContext: DbContext
	{
        public SocialsDbContext(DbContextOptions<SocialsDbContext> options)
            : base(options)
        { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodScheduling> FoodSchedulings { get; set; }
    }
}
