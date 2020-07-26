using System.Data.Entity.Migrations;

namespace WeatherApp.Data.Migrations
{
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.CurrentWeathers",
                    c => new
                    {
                        City = c.String(false, 128),
                        Temperature = c.Decimal(false, 18, 2),
                        Humidity = c.Decimal(false, 18, 2),
                        Pressure = c.Decimal(false, 18, 2),
                        CondText = c.String(),
                        CondIcon = c.String(),
                        WindSpeed = c.Decimal(false, 18, 2),
                        WindDir = c.String()
                    })
                .PrimaryKey(t => t.City);
        }

        public override void Down()
        {
            DropTable("dbo.CurrentWeathers");
        }
    }
}