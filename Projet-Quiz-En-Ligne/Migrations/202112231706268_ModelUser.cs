namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserResultViewModels", "quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.UserResultViewModels", "resultat_Id", "dbo.Resultats");
            DropIndex("dbo.UserResultViewModels", new[] { "quiz_Id" });
            DropIndex("dbo.UserResultViewModels", new[] { "resultat_Id" });
            AddColumn("dbo.Users", "quiz_Id", c => c.Int());
            AddColumn("dbo.Users", "resultat_Id", c => c.Int());
            CreateIndex("dbo.Users", "quiz_Id");
            CreateIndex("dbo.Users", "resultat_Id");
            AddForeignKey("dbo.Users", "quiz_Id", "dbo.Quizs", "Id");
            AddForeignKey("dbo.Users", "resultat_Id", "dbo.Resultats", "Id");
            DropColumn("dbo.Users", "TotalPoints");
            DropTable("dbo.UserResultViewModels");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "TotalPoints", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "resultat_Id", "dbo.Resultats");
            DropForeignKey("dbo.Users", "quiz_Id", "dbo.Quizs");
            DropIndex("dbo.Users", new[] { "resultat_Id" });
            DropIndex("dbo.Users", new[] { "quiz_Id" });
            DropColumn("dbo.Users", "resultat_Id");
            DropColumn("dbo.Users", "quiz_Id");
            CreateIndex("dbo.UserResultViewModels", "resultat_Id");
            CreateIndex("dbo.UserResultViewModels", "quiz_Id");
            AddForeignKey("dbo.UserResultViewModels", "resultat_Id", "dbo.Resultats", "Id");
            AddForeignKey("dbo.UserResultViewModels", "quiz_Id", "dbo.Quizs", "Id");
        }
    }
}
