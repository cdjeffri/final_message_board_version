namespace Message_Board.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedThreads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ThreadID = c.String(),
                        Author = c.String(),
                        Message = c.String(),
                        DateTimeCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Threads");
        }
    }
}
