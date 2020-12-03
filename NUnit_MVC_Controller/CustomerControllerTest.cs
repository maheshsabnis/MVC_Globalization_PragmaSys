
using MVC_EF_FluentAPI.Controllers;
using MVC_EF_FluentAPI.Models;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace NUnit_MVC_Controller
{
	[TestFixture]
	public class CustomerControllerTest
	{
		[Test]
		public void AddTest()
		{
			// Arrange
			// Arrange the required dependencies 
			// used for testing
			int x = 10;
			int y = 20;
			int ExpectedResult = 30;

			// Act
			// Call the method to be tested
			int ActualResult = x + y;

			// Assert
			// Verify the Test
			Assert.AreEqual(ExpectedResult,ActualResult);

		}
		[Test]
		public void TestCustomerIndexAction()
		{
			// Arrange
			var custController = new CustomerController();

			// Act
			// Call an Index() method
			var actualResult = custController.Index() as ViewResult;

			// Assertion
			// Verify if the method return Index View
			Assert.That(actualResult.ViewName, Is.EqualTo("Index"));
		}

		[Test]
		public void TestCustomerCreateMetodForRedirect()
		{
			// Arrange
			var custController = new CustomerController();

			RedirectToRouteResult result =
				  custController.Create(
					   new Customer() { 
					      CustomerName = "Keumar",
						  Address = "Pune"
					   }
					  ) as RedirectToRouteResult;
			// install or add reference of System.Web
			Assert.That(result.RouteValues["action"], Is.EqualTo("Index")); ;

		}

	}
}
