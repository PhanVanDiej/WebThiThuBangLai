namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenu : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_Menu");
            AlterColumn("dbo.tb_Menu", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.tb_Menu", "Title", c => c.String(nullable: false, maxLength: 500));
            AddPrimaryKey("dbo.tb_Menu", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.tb_Menu");
            AlterColumn("dbo.tb_Menu", "Title", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Menu", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tb_Menu", "ID");
        }
    }
}
