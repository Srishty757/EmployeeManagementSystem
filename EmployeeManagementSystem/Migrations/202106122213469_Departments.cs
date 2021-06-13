namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Departments : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Department_DepartmentId", newName: "DepartmentName_DepartmentId");
            RenameIndex(table: "dbo.Employees", name: "IX_Department_DepartmentId", newName: "IX_DepartmentName_DepartmentId");
            AddColumn("dbo.Employees", "EmployeeManager_EmployeeId", c => c.Int());
            CreateIndex("dbo.Employees", "EmployeeManager_EmployeeId");
            AddForeignKey("dbo.Employees", "EmployeeManager_EmployeeId", "dbo.Employees", "EmployeeId");
            DropColumn("dbo.Employees", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DepartmentName", c => c.String());
            DropForeignKey("dbo.Employees", "EmployeeManager_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "EmployeeManager_EmployeeId" });
            DropColumn("dbo.Employees", "EmployeeManager_EmployeeId");
            RenameIndex(table: "dbo.Employees", name: "IX_DepartmentName_DepartmentId", newName: "IX_Department_DepartmentId");
            RenameColumn(table: "dbo.Employees", name: "DepartmentName_DepartmentId", newName: "Department_DepartmentId");
        }
    }
}
