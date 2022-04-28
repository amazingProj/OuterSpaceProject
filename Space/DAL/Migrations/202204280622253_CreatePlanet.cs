namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePlanet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ImagesPath = c.String(),
                        mass = c.Double(nullable: false),
                        diameter = c.Double(nullable: false),
                        density = c.Double(nullable: false),
                        gravity = c.Double(nullable: false),
                        rotation_period = c.Double(nullable: false),
                        distance_from_sun = c.Double(nullable: false),
                        mean_temperature = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Planets");
        }
    }
}
