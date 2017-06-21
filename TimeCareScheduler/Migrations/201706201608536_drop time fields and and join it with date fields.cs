namespace TimeCareScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class droptimefieldsandandjoinitwithdatefields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedulers", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "EndDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedulers", "StartDate");
            DropColumn("dbo.Schedulers", "EndDate");
            DropColumn("dbo.Schedulers", "StartTime");
            DropColumn("dbo.Schedulers", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedulers", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Schedulers", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedulers", "EndDateTime");
            DropColumn("dbo.Schedulers", "StartDateTime");
        }
    }
}
