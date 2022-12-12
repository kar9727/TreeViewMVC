namespace TreeViewMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        nodeId = c.Int(nullable: false, identity: true),
                        nodeName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        startdate = c.DateTime(nullable: false),
                        parentNodeId = c.Int(),
                    })
                .PrimaryKey(t => t.nodeId)
                .ForeignKey("dbo.Categories", t => t.parentNodeId)
                .Index(t => t.parentNodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "parentNodeId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "parentNodeId" });
            DropTable("dbo.Categories");
        }
    }
}
