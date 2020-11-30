1. Implementing the Multi-Lingual UI dynamically in MVC Applications
- Create a multi-culture strings on server-side, so that when the browser requestes the specifc culture will be loaded.
- CReating Resource Files
	- These are the files containing Multi-Culture Strings to render response in UI by loading specific cultures
- ClientValidationEnabled
	- Execute the validations applied on Model class properties on client-side in broweser
-UnobtrusiveJavaScriptEnabled
	- Render HTML 5 Validation elements frpo client-side validation, which will avoid the unnecessary JavaScript 
		generation on browser
		- This is handled using data-val validaiton attributes of HTML 5


Step 1: Add  new class library project in solution. Name it as ResourceProvider. Delete class1.cs
Step 2: Add new a Resource File in the Project. This will name as Resource.resx
Step 3: Chane the Access Modifier of the File to 'public' from internal
	-- This will amke sure that all Culture-Specific  Strings will be accessible by all other projects
	-- Right-Clik on resx file and set the build action as 'Embaded Resource' 
			-- This will add the Resx file into the output assembly generated
Step 4: Copy and paste the Resource.resx in the same project and rename it as resx.fr.resx (French Cultre)
	Translate the Values for Resource.fr.resx file to frence usign Google Translater

Step 5: Add the reference of ResourceProvider project into the MVC application using 
Add References
Step 6: Modify Data Annotations of the Student class by using 
'ErrorMessageResourceName' property  --> Represent the 'Name' of the resource from Resx file
and
ErrorMessageResourceType property --> it is the Resource class that contains Culture Specific String Constants

Student Original class
public class Student
	{
		[Display(Name ="FirstName")]
		[Required(ErrorMessage ="First Name is Required")]
		public string FirstName { get; set; }
		[Display(Name = "LastName")]
		[Required(ErrorMessage = "Last Name is Required")]
		public string LastName { get; set; }
		[Display(Name = "Address")]
		[Required(ErrorMessage = "Address is Required")]
		public string Address { get; set; }
		[Display(Name = "CollageName")]
		[Required(ErrorMessage = "Collage Name is Required")]
		public string CollageName { get; set; }
		[Display(Name = "Age")]
		[Required(ErrorMessage = "Age is Required")]
		[Range(16, 25, ErrorMessage ="Age must be within 0 to 25")]
		public string Age { get; set; }
	}

Will be replace by
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

-- The .NET Application understands cultures as below
English --> en-US
Hindi --> hi-IN
French --> fr-FR
German --> de-DE

TO update /Change the Culture of Web App in .NET (ASP.NET WebForms or ASP.NET MVC)
The 'Session' must be established.
	- The session is estalished with Web Server means that a thread is allocated 
	by web server over which Request will be accepted and responsed with be 
	delivered back
	
System.Threading
The "Thread" class with following  important properties for Cultures
	- Thread.CurrentThread.CurrentCulture, the culture for current executing thread
	- Thread,CurrentThread,CurrentUICulture, the UI culture for current executing
				thread
TO update the Thread Culture (incldding UI Culture), we must use Session object
	This session object will carry the session information

	The following method of ControllerBase class cna be used to 
	check the session object value for any culture change request

protected virtual void Initialize(RequestContext requestContext);


Write following code in COntroller that will respond views with culture change
 /// <summary>
        /// This method will check the Session object
        /// in current request
        /// </summary>
        /// <param name="requestContext"></param>
		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
            // if the request sends the new culture in Request
            // using Session object
            if (Session["Culture"] != null)
            {
                Thread.CurrentThread.CurrentCulture
                    = new CultureInfo(Session["Culture"].ToString());
                Thread.CurrentThread.CurrentUICulture
                    = new CultureInfo(Session["Culture"].ToString());
            }
		}

MOfidy the Create.chtml for Student create
@*Referring Namespace containing all resource Constants and names*@ 
@using RourcesProvider
@model MVC_Globalization.Models.Student

@{
	ViewBag.Title = Resource.Create;
}

<h2>@Resource.Create</h2>


@*Create a DropDown so that User can select culture and submit it*@

<div class="container">
	@using (Html.BeginForm("SetNewCulture", "Student"))
	{
		@*The DropDown will show all cultures
			the 'cultureName' is the values selected by end-user
			e.g. en-US, the 'cultureText' is displayed in the dropdown list
			the 'Session["Culture"]' will; contains the selected cultureName
			 This will be submited to the SetNewCulture method of StudentCOntroller *@
		<div class="form-group">
			<label>Select Language</label>
			@Html.DropDownList("cultureName",
			new SelectList(ViewBag.Cultures, "cultureName", "cultureText",
			 Session["Culture"]), new { onchange = "this.form.submit();" })
		</div>
	}
</div>




@using (Html.BeginForm())
{
	@Html.AntiForgeryToken()

	<div class="form-horizontal">
		<h4>@Resource.Student</h4>
		<hr />
		@Html.ValidationSummary(true, "", new { @class = "text-danger" })
		<div class="form-group">
			@Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" })
			<div class="col-md-10">
				@Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
				@Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" })
			</div>
		</div>

		<div class="form-group">
			@Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" })
			<div class="col-md-10">
				@Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } })
				@Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" })
			</div>
		</div>

		<div class="form-group">
			@Html.LabelFor(model => model.Address, htmlAttributes: new { @class = "control-label col-md-2" })
			<div class="col-md-10">
				@Html.EditorFor(model => model.Address, new { htmlAttributes = new { @class = "form-control" } })
				@Html.ValidationMessageFor(model => model.Address, "", new { @class = "text-danger" })
			</div>
		</div>

		<div class="form-group">
			@Html.LabelFor(model => model.CollageName, htmlAttributes: new { @class = "control-label col-md-2" })
			<div class="col-md-10">
				@Html.EditorFor(model => model.CollageName, new { htmlAttributes = new { @class = "form-control" } })
				@Html.ValidationMessageFor(model => model.CollageName, "", new { @class = "text-danger" })
			</div>
		</div>

		<div class="form-group">
			@Html.LabelFor(model => model.Age, htmlAttributes: new { @class = "control-label col-md-2" })
			<div class="col-md-10">
				@Html.EditorFor(model => model.Age, new { htmlAttributes = new { @class = "form-control" } })
				@Html.ValidationMessageFor(model => model.Age, "", new { @class = "text-danger" })
			</div>
		</div>

		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<input type="submit" value="Create" class="btn btn-default" />
			</div>
		</div>
	</div>
}

<div>
	@Html.ActionLink("Back to List", "Index")
</div>

@section Scripts {
	@Scripts.Render("~/bundles/jqueryval")
}


Add following method in StudentController to Set New Culture
  /// <summary>
        /// The Post method that will accept POST request to the 
        /// to select new culture
        /// </summary>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetNewCulture(string  cultureName)
        {
            // apply the new Culture
            Thread.CurrentThread.CurrentCulture
                   = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture
                = new CultureInfo(cultureName);
            // set this new culture to the session object
            Session["Culture"] = cultureName;

            // pass the list of available cultures to UI
            // so that end-user can select the culture
            ViewBag.Cultures = new[] {
                new {cultureName="en-US", cultureText = "English" },
                new {cultureName="fr-FR", cultureText = "French" },
            };
            return View("Create");
        }

Since the 'Create' view is send the ViewBag by the above method, Make sure
that all methods returning the Create view must pass the ViewBag so modify
Create methods in StudentControllr as follows

 public ActionResult Create()
        {
            var student = new Student();
            // pass the list of available cultures to UI
            // so that end-user can select the culture
            ViewBag.Cultures = new[] {
                new {cultureName="en-US", cultureText = "English" },
                new {cultureName="fr-FR", cultureText = "French" },
            };
            return View(student);
        }

        [HttpPost]
        public ActionResult Create(Student st)
        {
            // pass the list of available cultures to UI
            // so that end-user can select the culture
            ViewBag.Cultures = new[] {
                new {cultureName="en-US", cultureText = "English" },
                new {cultureName="fr-FR", cultureText = "French" },
            };
            if (ModelState.IsValid)
            {
                // do some operations
                // logic to write the data in database
                // redirect to Index Page
                var student = new Student();
                return View(student);
            }
            return View(st);
           
        }