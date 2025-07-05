using Microsoft.EntityFrameworkCore;

namespace Lab06.Models
{
	public class MyDbContext : DbContext
	{
		public DbSet<Loai> Loais { get; set; }
		public DbSet<HangHoa> HangHoas { get; set;}

		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
	}
}
