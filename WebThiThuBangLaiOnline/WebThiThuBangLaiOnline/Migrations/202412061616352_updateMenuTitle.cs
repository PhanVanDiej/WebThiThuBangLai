﻿namespace WebThiThuBangLaiOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenuTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Menu", "Title", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Menu", "Title", c => c.String(maxLength: 500));
        }
    }
}
