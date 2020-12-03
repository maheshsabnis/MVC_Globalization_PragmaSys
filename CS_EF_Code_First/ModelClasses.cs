using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CS_EF_Code_First
{
	/// <summary>
	/// CategoryRowId will be Primary Identity Key
	/// Category will contain Multiple Products
	/// Use RequiredAttribute for No Nulll
	/// Use StringLength for defining Maxlength for string properties 
	/// </summary>
	public class Category
	{
		[Key] // used for defining the property as Primary Identity Key
		public int CategoryRowId { get; set; }
		[Required]
		[StringLength(200)]
		public string CategoryId { get; set; }
		[Required]
		[StringLength(200)]
		public string CategoryName { get; set; }
		[Required]
		[StringLength(100)]
		public string SubCategoryName { get; set; }
		[Required]
		public int BasePrice { get; set; }
		// One-to-Many Relationship
		public ICollection<Product> Products { get; set; }
	}

	/// <summary>
	/// ProductRowId will be Primary Identity Key
	/// and Product class will contain the CategoryRowId as 
	/// Foreign-Key for referential integrity
	/// </summary>
	public class Product
	{
		[Key]
		public int ProductRowId { get; set; }
		[Required]
		[StringLength(200)]
		public string ProductId { get; set; }
		[Required]
		[StringLength(200)]
		public string ProductName { get; set; }
		[Required]
		public int Price { get; set; }
		[Required]
		public int SalesTax { get; set; }
		// foreign key
		[Required]
		public int CategoryRowId { get; set; }
		// the referential integrity
		public Category Category { get; set; }
	}
}
