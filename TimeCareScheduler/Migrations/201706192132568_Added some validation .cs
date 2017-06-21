namespace TimeCareScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedsomevalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Schedulers", "EventName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Schedulers", "EventName", c => c.String());
        }
    }
}
