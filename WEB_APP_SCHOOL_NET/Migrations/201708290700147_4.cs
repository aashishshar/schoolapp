namespace WEB_APP_SCHOOL_NET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Menu = c.String(),
                        Path = c.String(),
                        Read = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Execute = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationGroupRoles",
                c => new
                    {
                        ApplicationGroupId = c.String(nullable: false, maxLength: 128),
                        ApplicationRoleId = c.String(),
                        ApplicationGroup_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationGroupId)
                .ForeignKey("dbo.ApplicationGroups", t => t.ApplicationGroup_Id)
                .Index(t => t.ApplicationGroup_Id);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        ApplicationGroupId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.ApplicationGroups", t => t.ApplicationGroupId)
                .Index(t => t.ApplicationGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserGroups", "ApplicationGroupId", "dbo.ApplicationGroups");
            DropForeignKey("dbo.ApplicationGroupRoles", "ApplicationGroup_Id", "dbo.ApplicationGroups");
            DropIndex("dbo.ApplicationUserGroups", new[] { "ApplicationGroupId" });
            DropIndex("dbo.ApplicationGroupRoles", new[] { "ApplicationGroup_Id" });
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.ApplicationGroupRoles");
            DropTable("dbo.ApplicationGroups");
        }
    }
}
