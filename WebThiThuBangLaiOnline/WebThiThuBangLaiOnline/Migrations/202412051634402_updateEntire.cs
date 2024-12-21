namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEntire : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test");
            DropIndex("dbo.tb_Question", new[] { "TestID" });
            AlterColumn("dbo.tb_QuestionImage", "Image", c => c.String());
            AlterColumn("dbo.tb_Question", "TestID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.tb_Question", "DetailQuestion", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.tb_Question", "OptionA", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.tb_Question", "OptionB", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.tb_Question", "OptionC", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.tb_Question", "Answer", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.tb_Question", "Explain", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.tb_Test", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.tb_Test", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.tb_User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.tb_User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.tb_User", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.tb_User", "Password", c => c.String(nullable: false));
            CreateIndex("dbo.tb_Question", "TestID");
            AddForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test", "TestID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test");
            DropIndex("dbo.tb_Question", new[] { "TestID" });
            AlterColumn("dbo.tb_User", "Password", c => c.String());
            AlterColumn("dbo.tb_User", "UserName", c => c.String());
            AlterColumn("dbo.tb_User", "Email", c => c.String());
            AlterColumn("dbo.tb_User", "Name", c => c.String());
            AlterColumn("dbo.tb_Test", "Type", c => c.String());
            AlterColumn("dbo.tb_Test", "Name", c => c.String());
            AlterColumn("dbo.tb_Question", "Explain", c => c.String(maxLength: 1000));
            AlterColumn("dbo.tb_Question", "Answer", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Question", "OptionC", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Question", "OptionB", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Question", "OptionA", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Question", "DetailQuestion", c => c.String(maxLength: 1000));
            AlterColumn("dbo.tb_Question", "TestID", c => c.String(maxLength: 128));
            AlterColumn("dbo.tb_QuestionImage", "Image", c => c.String(nullable: false));
            CreateIndex("dbo.tb_Question", "TestID");
            AddForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test", "TestID");
        }
    }
}
