using System.ComponentModel.DataAnnotations;

namespace EFCoreWebApiCrud.Model
{
	public class Product
	{
		[Key]
		public int ProductID { get; set; }

		[Required]
		[MaxLength(100)]
		public string ProductName { get; set; }

		[MaxLength(500)]
		public string ProductDescription { get; set; }

		[StringLength(100)]
		public string Brand { get; set; }

		public decimal Price { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public string ImageName { get; set; }

	}
}
