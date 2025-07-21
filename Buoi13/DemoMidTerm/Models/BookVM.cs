using System.ComponentModel.DataAnnotations;

namespace DemoMidTerm.Models
{
	public class AuthorVM
	{
		[Key]
		public int AuthorId { get; set; }
		public string AuthorName { get; set; }
		public int Total { get; set; }
	}
}
