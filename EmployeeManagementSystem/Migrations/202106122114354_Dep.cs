namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dep : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeDepartments", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeDepartments", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.EmployeeDepartments", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.EmployeeDepartments", new[] { "Department_DepartmentId" });
            AddColumn("dbo.Employees", "DepartmentName", c => c.String());
            AddColumn("dbo.Employees", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Employees", "Department_DepartmentId");
            AddForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Employees", "Employee_EmployeeId");
            DropTable("dbo.EmployeeDepartments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeDepartments",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Department_DepartmentId });
            
            AddColumn("dbo.Employees", "Employee_EmployeeId", c => c.Int());
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Employees", "Department_DepartmentId");
            DropColumn("dbo.Employees", "DepartmentName");
            CreateIndex("dbo.EmployeeDepartments", "Department_DepartmentId");
            CreateIndex("dbo.EmployeeDepartments", "Employee_EmployeeId");
            CreateIndex("dbo.Employees", "Employee_EmployeeId");
            AddForeignKey("dbo.Employees", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.EmployeeDepartments", "Department_DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeDepartments", "Employee_EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
