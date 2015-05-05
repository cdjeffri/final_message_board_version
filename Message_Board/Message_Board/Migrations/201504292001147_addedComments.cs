namespace Message_Board.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ThreadID = c.Int(nullable: false),
                        CommentMessage = c.String(),
                        Author = c.String(),
                        DateTimeCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
