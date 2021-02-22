using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    class Program
    {
		public static void Main(string[] args)
		{
			var connectionString = "Server=.;Database=MiniORM;Integrated Security=true";

			var context = new SoftUniDbContext(connectionString);

			context.Employees.Add(new Employee
			{
				FirstName = "Kaladin",
				LastName = "Stormblessed",
				DepartmentId = context.Departments.First().Id,
				IsEmployed = true,
			});

			var employee = context.Employees.Last();
			employee.FirstName = "Modified";

			context.SaveChanges();
		}
	}
}