using System.Data.Entity.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class cityName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CurrentWeathers", "CityName", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.CurrentWeathers", "CityName");
        }
    }
}