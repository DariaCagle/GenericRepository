namespace FuneralHome.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    Phone = c.String(),
                    Address = c.String(),
                    DeathCertificateNumber = c.Int(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Funerals",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateUtc = c.DateTime(nullable: false),
                    Type = c.Int(nullable: false),
                    ClientId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    MiddleName = c.String(),
                    LastName = c.String(),
                    Phone = c.String(),
                    Position = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.FuneralEmployees",
                c => new
                {
                    Funeral_Id = c.Int(nullable: false),
                    Employee_ID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Funeral_Id, t.Employee_ID })
                .ForeignKey("dbo.Funerals", t => t.Funeral_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Funeral_Id)
                .Index(t => t.Employee_ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.FuneralEmployees", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.FuneralEmployees", "Funeral_Id", "dbo.Funerals");
            DropForeignKey("dbo.Funerals", "ClientId", "dbo.Clients");
            DropIndex("dbo.FuneralEmployees", new[] { "Employee_ID" });
            DropIndex("dbo.FuneralEmployees", new[] { "Funeral_Id" });
            DropIndex("dbo.Funerals", new[] { "ClientId" });
            DropTable("dbo.FuneralEmployees");
            DropTable("dbo.Employees");
            DropTable("dbo.Funerals");
            DropTable("dbo.Clients");
        }
    }
}
