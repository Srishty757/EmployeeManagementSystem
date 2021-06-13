using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeManagementSystem.Models
{
    public class DBContextcs : DbContext
    {
        public DBContextcs() : base("cs")
         
        {
          Database.SetInitializer<DBContextcs>(new DepartmentDbInitializer<DBContextcs>());
        }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        //Seed data to department
        private class DepartmentDbInitializer<T> : DropCreateDatabaseIfModelChanges<DBContextcs>
        {
            protected override void Seed(DBContextcs context)
            {
                IEnumerable<Department> list = new List<Department>();
                {
                  new Department() { DepartmentId = 1, DepartmentName = "Admin" };
                  new Department() { DepartmentId = 2, DepartmentName = "Sales" };
                  new Department() { DepartmentId = 3, DepartmentName = "Marketing" };
                  new Department() { DepartmentId = 4, DepartmentName = "Software Developer" };
                }

                //IList <Department> list = new List<Department>();
                //Adding Row
                // list.Add(new Department() { DepartmentId = 1, DepartmentName = "Admin" });
                // list.Add(new Department() { DepartmentId = 2, DepartmentName = "Sales" });
                // list.Add(new Department() { DepartmentId = 3, DepartmentName = "Marketing" });
                // list.Add(new Department() { DepartmentId = 4, DepartmentName = "Software Developer" });
               
             
                foreach (Department department in list)
                    context.Departments.Add(department);

                base.Seed(context);
            }
        
        }

    }

    
}