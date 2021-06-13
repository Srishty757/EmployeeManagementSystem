namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "DepartmentName_DepartmentId", newName: "DepartmentId_DepartmentId");
            RenameIndex(table: "dbo.Employees", name: "IX_DepartmentName_DepartmentId", newName: "IX_DepartmentId_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_DepartmentId_DepartmentId", newName: "IX_DepartmentName_DepartmentId");
            RenameColumn(table: "dbo.Employees", name: "DepartmentId_DepartmentId", newName: "DepartmentName_DepartmentId");
        }
    }
}
