namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDTB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tb_QuestionImage",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        QuestionID = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tb_Question",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        TestID = c.String(maxLength: 128),
                        DetailQuestion = c.String(maxLength: 1000),
                        OptionA = c.String(maxLength: 500),
                        OptionB = c.String(maxLength: 500),
                        OptionC = c.String(maxLength: 500),
                        OptionD = c.String(maxLength: 500),
                        Answer = c.String(maxLength: 500),
                        Type = c.Int(nullable: false),
                        Explain = c.String(maxLength: 1000),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tb_Test", t => t.TestID)
                .Index(t => t.TestID);
            
            CreateTable(
                "dbo.tb_Test",
                c => new
                    {
                        TestID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.String(),
                        NumOfQuestion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TestID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tb_User",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Email = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_Question", new[] { "TestID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.tb_User");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_Test");
            DropTable("dbo.tb_Question");
            DropTable("dbo.tb_QuestionImage");
            DropTable("dbo.tb_Menu");
        }
    }
}
