namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateQuestion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Question", "OptionA", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Question", "OptionA", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
