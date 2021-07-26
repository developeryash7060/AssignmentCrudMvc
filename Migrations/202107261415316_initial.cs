namespace AssignmentCrudMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DOJ = c.DateTime(nullable: false),
                        Mobile = c.Long(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        DeptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DeptId, cascadeDelete: true)
                .Index(t => t.DeptId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salaries", "Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DeptId", "dbo.Departments");
            DropIndex("dbo.Salaries", new[] { "Id" });
            DropIndex("dbo.Employees", new[] { "DeptId" });
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
