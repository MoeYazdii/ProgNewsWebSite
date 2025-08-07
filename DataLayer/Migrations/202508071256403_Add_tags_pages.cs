namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_tags_pages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NewsPages", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NewsPages", "Tags");
        }
    }
}
