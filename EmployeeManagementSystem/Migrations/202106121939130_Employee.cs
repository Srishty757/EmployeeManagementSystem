namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        City = c.String(),
                        PhoneNo = c.String(nullable: false, maxLength: 10),
                        Gender = c.String(),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.EmployeeDepartments",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Department_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Department_DepartmentId })
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Department_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeDepartments", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.EmployeeDepartments", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeDepartments", new[] { "Department_DepartmentId" });
            DropIndex("dbo.EmployeeDepartments", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Employees", new[] { "Employee_EmployeeId" });
            DropTable("dbo.EmployeeDepartments");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
