namespace FuneralHome.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FuneralHome.Data.FuneralHomeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FuneralHome.Data.FuneralHomeContext context)
        {

        }
    }
}
