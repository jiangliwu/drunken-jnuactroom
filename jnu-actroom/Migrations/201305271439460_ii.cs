namespace jnu_actroom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "Password", c => c.String());
          
        }
        
        public override void Down()
        {
           
        }
    }
}
