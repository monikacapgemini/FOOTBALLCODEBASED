namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Footballs",
                c => new
                    {
                        MatchID = c.Int(nullable: false),
                        TeamName1 = c.String(nullable: false),
                        TeamName2 = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        WinningTeam = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Footballs");
        }
    }
}
