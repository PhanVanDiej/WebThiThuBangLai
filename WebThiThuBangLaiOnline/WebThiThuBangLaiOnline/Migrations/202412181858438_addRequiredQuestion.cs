namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredQuestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test");
            DropIndex("dbo.tb_Question", new[] { "TestID" });
            AlterColumn("dbo.tb_Question", "TestID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tb_Question", "TestID");
            AddForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test", "TestID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test");
            DropIndex("dbo.tb_Question", new[] { "TestID" });
            AlterColumn("dbo.tb_Question", "TestID", c => c.String(maxLength: 128));
            CreateIndex("dbo.tb_Question", "TestID");
            AddForeignKey("dbo.tb_Question", "TestID", "dbo.tb_Test", "TestID");
        }
    }
}
