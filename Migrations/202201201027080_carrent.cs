namespace Lcvoiture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class carrent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voitures", "image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voitures", "image", c => c.Binary());
        }
    }
}
