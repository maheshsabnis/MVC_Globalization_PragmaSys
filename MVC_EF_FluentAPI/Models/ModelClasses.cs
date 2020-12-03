using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF_FluentAPI.Models
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string CustomerName { get; set; }
		public string Address { get; set; }
		public virtual ICollection<Order> Orders { get; set; }

	}

	public class Order
	{
		public int OrderId { get; set; }
		public string OrderedItem { get; set; }
		public int OrderedQuantity { get; set; }
		public int UnitPrice { get; set; }
		public int TotalBill { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
	}
}