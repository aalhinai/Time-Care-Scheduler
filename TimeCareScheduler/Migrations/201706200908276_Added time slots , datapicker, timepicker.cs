namespace TimeCareScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtimeslotsdatapickertimepicker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedulers", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "EndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedulers", "StartDateTime");
            DropColumn("dbo.Schedulers", "EndDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedulers", "EndDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "StartDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedulers", "EndTime");
            DropColumn("dbo.Schedulers", "StartTime");
            DropColumn("dbo.Schedulers", "EndDate");
            DropColumn("dbo.Schedulers", "StartDate");
        }
    }
}
