namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "quiz_Id", c => c.Int());
            AddColumn("dbo.Users", "resultat_Id", c => c.Int());
            CreateIndex("dbo.Users", "quiz_Id");
            CreateIndex("dbo.Users", "resultat_Id");
            AddForeignKey("dbo.Users", "quiz_Id", "dbo.Quizs", "Id");
            AddForeignKey("dbo.Users", "resultat_Id", "dbo.Resultats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "resultat_Id", "dbo.Resultats");
            DropForeignKey("dbo.Users", "quiz_Id", "dbo.Quizs");
            DropIndex("dbo.Users", new[] { "resultat_Id" });
            DropIndex("dbo.Users", new[] { "quiz_Id" });
            DropColumn("dbo.Users", "resultat_Id");
            DropColumn("dbo.Users", "quiz_Id");
        }
    }
}
