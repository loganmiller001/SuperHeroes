namespace SuperHeroes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MySuperHeroMigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperHeroes",
                c => new
                    {
                        SuperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AlterEgo = c.String(),
                        PrimaryPower = c.String(),
                        SecondaryPower = c.String(),
                        CatchPhrase = c.String(),
                    })
                .PrimaryKey(t => t.SuperId);
            
            DropTable("dbo.SuperHeroes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SuperHeroes",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        AlterEgo = c.String(),
                        PrimaryPower = c.String(),
                        SecondaryPower = c.String(),
                        CatchPhrase = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            DropTable("dbo.SuperHeroes");
        }
    }
}
