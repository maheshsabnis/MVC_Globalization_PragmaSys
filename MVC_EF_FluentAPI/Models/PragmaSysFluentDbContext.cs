using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_EF_FluentAPI.Models
{
	public class PragmaSysFluentDbContext : DbContext
	{
		public PragmaSysFluentDbContext():base("name=AppConnectionString")
		{
		}

		// define DbSets
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }

		/// <summary>
		/// The method to contain the Fluent
		/// API methods for defining
		/// Mapping with COnstraints
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// CustomerId is Primary Key
			modelBuilder.Entity<Customer>().HasKey(c=>c.CustomerId);
			// Make the CustomerId as Primary Identity Key
			modelBuilder.Entity<Customer>()
				.Property(c => c.CustomerId)
						.HasDatabaseGeneratedOption(
				DatabaseGeneratedOption.Identity);

			modelBuilder.Entity<Customer>().Property(
				  c => c.CustomerName
				).IsRequired();

			modelBuilder.Entity<Customer>().Property(
				  c=>c.CustomerName
				).HasMaxLength(100);

			modelBuilder.Entity<Customer>().Property(
				  c => c.Address
				).IsRequired();

			modelBuilder.Entity<Customer>().Property(
				  c => c.Address
				).HasMaxLength(100);

			// settings fluent APIs for Order

			// OrderId is Primary Key
			modelBuilder.Entity<Order>().HasKey(o=>o.OrderId);
			// Make the OrderId as Primary Identity Key
			modelBuilder.Entity<Order>()
				.Property(o => o.OrderId)
						.HasDatabaseGeneratedOption(
				DatabaseGeneratedOption.Identity);


			modelBuilder.Entity<Order>().Property(
				  o => o.OrderedItem
				).IsRequired();

			modelBuilder.Entity<Order>().Property(
				  o => o.OrderedItem
				).HasMaxLength(100);

			// Set the CustomerId as Foreign Key
			// from the Order Table
			modelBuilder.Entity<Order>()
				.HasRequired(c =>c.Customer) // Order Must have Customer
				.WithMany(o => o.Orders) // Customer Have Multiple Orders
				.HasForeignKey(o => o.CustomerId) // Each Order will have CustomerId as foreign Key
				.WillCascadeOnDelete(true); // CasCaseDelete


			base.OnModelCreating(modelBuilder);
		}

	}
}