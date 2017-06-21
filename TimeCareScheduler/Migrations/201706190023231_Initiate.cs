namespace TimeCareScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initiate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedulers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedulers");
        }
    }
}
