namespace WeatherApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrentWeathers",
                c => new
                    {
                        City = c.String(nullable: false, maxLength: 128),
                        Temperature = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Humidity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Pressure = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CondText = c.String(),
                        CondIcon = c.String(),
                        WindSpeed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WindDir = c.String(),
                    })
                .PrimaryKey(t => t.City);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CurrentWeathers");
        }
    }
}
