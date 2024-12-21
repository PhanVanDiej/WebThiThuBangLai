namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAlias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Menu", "Alias", c => c.String());
            AddColumn("dbo.tb_QuestionImage", "Alias", c => c.String());
            AddColumn("dbo.tb_Question", "Alias", c => c.String());
            AddColumn("dbo.tb_Test", "Alias", c => c.String());
            AddColumn("dbo.tb_User", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_User", "Alias");
            DropColumn("dbo.tb_Test", "Alias");
            DropColumn("dbo.tb_Question", "Alias");
            DropColumn("dbo.tb_QuestionImage", "Alias");
            DropColumn("dbo.tb_Menu", "Alias");
        }
    }
}
