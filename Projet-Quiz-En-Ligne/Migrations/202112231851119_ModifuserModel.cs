namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifuserModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.Users", "resultat_Id", "dbo.Resultats");
            DropIndex("dbo.Users", new[] { "quiz_Id" });
            DropIndex("dbo.Users", new[] { "resultat_Id" });
            DropColumn("dbo.Users", "quiz_Id");
            DropColumn("dbo.Users", "resultat_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "resultat_Id", c => c.Int());
            AddColumn("dbo.Users", "quiz_Id", c => c.Int());
            CreateIndex("dbo.Users", "resultat_Id");
            CreateIndex("dbo.Users", "quiz_Id");
            AddForeignKey("dbo.Users", "resultat_Id", "dbo.Resultats", "Id");
            AddForeignKey("dbo.Users", "quiz_Id", "dbo.Quizs", "Id");
        }
    }
}
