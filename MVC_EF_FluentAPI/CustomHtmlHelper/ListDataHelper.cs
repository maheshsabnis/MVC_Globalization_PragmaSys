using MVC_EF_FluentAPI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC_EF_FluentAPI.CustomHtmlHelper
{
	public static class ListDataHelper
	{
		/// <summary>
		/// Extension methdo for HtmlHelper
		/// This will be accessed on View
		/// @Html.ListData()
		/// </summary>
		/// <param name="helper"></param>
		/// <param name="customers"></param>
		/// <returns></returns>
		public static MvcHtmlString ListData
			(this HtmlHelper helper, List<Customer> customers)
		{
			string result = "<table class='table table-bordered table-striped'>";
			result += $"<thead>" +
				$"<tr><th>Customer Id</th><th>Customer Name</th>" +
				$"<th>Address</th> </tr>" +
				$"</thead>";
			result += "<tbody>";
			foreach ( Customer  cust in customers)
			{
				result += $"<tr><td>{cust.CustomerId}</td><td>" +
					$"{cust.CustomerName}</td><td>{cust.Address}</td></tr>";
			}
			result += "</tbody></table>";
			return MvcHtmlString.Create(result);

		}
			 
	}
}