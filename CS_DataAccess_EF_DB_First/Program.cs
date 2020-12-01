using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DataAccess_EF_DB_First
{
	class Program
	{
		static void Main(string[] args)
		{
			DataAccessLayer ds = new DataAccessLayer();

			var depts = ds.GetDepts();

			foreach (var dept in depts)
			{
				Console.WriteLine($"DeptNo {dept.DeptNo} DeptName = {dept.DeptName} Location = {dept.Location}");
			}

			Console.WriteLine();

			//var newDept = new Department()
			//{
			//	 DeptNo = 300, DeptName = "IT-300", Location="Pune"
			//};
			//ds.CreateDept(newDept);
			//Console.WriteLine("After adding new records");
			
			Console.WriteLine();
			var updateDept = new Department()
			{
				DeptNo = 300,
				DeptName = "IT-ES-300",
				Location = "Pune-Bavdhan"
			};

			//ds.UpdateDept(300, updateDept);

			//Console.WriteLine("After Update");

			ds.DeleteDept(300);


			depts = ds.GetDepts();

			foreach (var dept in depts)
			{
				Console.WriteLine($"DeptNo {dept.DeptNo} DeptName = {dept.DeptName} Location = {dept.Location}");
			}


			Console.ReadLine();
		}
	}
}
