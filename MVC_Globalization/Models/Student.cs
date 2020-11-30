// refer the resource provider

using RourcesProvider;
using System.ComponentModel.DataAnnotations;

namespace MVC_Globalization.Models
{
	public class Student
	{
		// the FirstName is the Constant String for Reource class 
		[Display(Name ="FirstName", ResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName ="FirstNameRequired", ErrorMessageResourceType = typeof(Resource))]
		public string FirstName { get; set; }
		[Display(Name = "LastName", ResourceType =typeof(Resource))]
		[Required(ErrorMessageResourceName = "LastNameRequired", ErrorMessageResourceType = typeof(Resource))]
		public string LastName { get; set; }
		[Display(Name = "Address", ResourceType =typeof(Resource))]
		[Required(ErrorMessageResourceName = "AddressRequired", ErrorMessageResourceType = typeof(Resource))]
		public string Address { get; set; }
		[Display(Name = "CollageName", ResourceType =typeof(Resource))]
		[Required(ErrorMessageResourceName = "CollageNameRequired", ErrorMessageResourceType = typeof(Resource))]
		public string CollageName { get; set; }
		[Display(Name = "Age", ResourceType =typeof(Resource))]
		[Required(ErrorMessageResourceName = "AgeRequired", ErrorMessageResourceType = typeof(Resource))]
		[Range(16, 25, ErrorMessageResourceName = "AgeRange", ErrorMessageResourceType = typeof(Resource))]
		public string Age { get; set; }
	}
}

