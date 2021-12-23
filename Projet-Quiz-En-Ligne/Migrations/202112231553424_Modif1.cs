namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserResultViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Email = c.String(nullable: false),
                        quiz_Id = c.Int(),
                        resultat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.quiz_Id)
                .ForeignKey("dbo.Resultats", t => t.resultat_Id)
                .Index(t => t.quiz_Id)
                .Index(t => t.resultat_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserResultViewModels", "resultat_Id", "dbo.Resultats");
            DropForeignKey("dbo.UserResultViewModels", "quiz_Id", "dbo.Quizs");
            DropIndex("dbo.UserResultViewModels", new[] { "resultat_Id" });
            DropIndex("dbo.UserResultViewModels", new[] { "quiz_Id" });
            DropTable("dbo.UserResultViewModels");
        }
    }
}
