namespace FuneralHome.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Add_Models_For_FuneralEmployees : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FuneralEmployees", new[] { "Employee_ID" });
            CreateIndex("dbo.FuneralEmployees", "Employee_Id");
        }

        public override void Down()
        {
            DropIndex("dbo.FuneralEmployees", new[] { "Employee_Id" });
            CreateIndex("dbo.FuneralEmployees", "Employee_ID");
        }
    }
}
