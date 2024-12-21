namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDTB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_QuestionImage", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_QuestionImage", "Image", c => c.String());
        }
    }
}
