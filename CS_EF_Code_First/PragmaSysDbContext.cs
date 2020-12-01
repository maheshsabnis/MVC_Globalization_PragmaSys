using System.Data.Entity;

namespace CS_EF_Code_First
{
	/// <summary>
	/// This class will manage
	/// 1. Db COnnection
	/// 2. Db Transactions
	/// 3. RecordSets using DbSet<T>
	/// </summary>
	public class PragmaSysDbContext : DbContext
	{
		/// <summary>
		/// COnstructor will read
		/// the connstection string from Config file
		/// </summary>
		public PragmaSysDbContext():base("name=PragmaSysConnStr")
		{
		}

		/// <summary>
		/// DbSet<T> for mapping with tables
		/// </summary>
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		/// <summary>
		/// This method will manage the Table Mapping
		/// from Model classes aka Entity class with Database
		/// Tables
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
