using System.Collections.Generic;
using System.Linq;

namespace CS_DataAccess_EF_DB_First
{
	public class DataAccessLayer
	{
		CompanyEntities Ctx;

		public DataAccessLayer()
		{
			Ctx = new CompanyEntities();
		}

		public List<Department> GetDepts()
		{
			return Ctx.Departments.ToList();
		}

		public void CreateDept(Department dept)
		{
			Ctx.Departments.Add(dept);
			Ctx.SaveChanges();
		}

		public void UpdateDept(int deptNo, Department dept)
		{
			var searchDept = Ctx.Departments.Find(deptNo);
			if (searchDept != null)
			{
				// if the dept is present
				searchDept.DeptName = dept.DeptName;
				searchDept.Location = dept.Location;
				Ctx.SaveChanges();
			}
		}

		public void DeleteDept(int deptNo)
		{
			var searchDept = Ctx.Departments.Find(deptNo);
			if (searchDept != null)
			{
				Ctx.Departments.Remove(searchDept);
				Ctx.SaveChanges();
			}
		}
	}
}
