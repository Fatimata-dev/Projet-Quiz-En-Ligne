namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quizs", "CategoryId", "dbo.QuizCategories");
            DropForeignKey("dbo.QuizTests", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.QuizTests", "UserId", "dbo.Users");
            DropIndex("dbo.Quizs", new[] { "CategoryId" });
            DropIndex("dbo.QuizTests", new[] { "UserId" });
            DropIndex("dbo.QuizTests", new[] { "QuizId" });
            CreateTable(
                "dbo.Resultats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuizCategories", "Name", c => c.String());
            AddColumn("dbo.Quizs", "Image", c => c.String());
            AddColumn("dbo.Quizs", "Category", c => c.String());
            DropColumn("dbo.QuizCategories", "Title");
            DropColumn("dbo.Quizs", "CategoryId");
            DropTable("dbo.QuizTests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuizTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        UserId = c.Int(),
                        QuizId = c.Int(),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Quizs", "CategoryId", c => c.Int());
            AddColumn("dbo.QuizCategories", "Title", c => c.String());
            DropColumn("dbo.Quizs", "Category");
            DropColumn("dbo.Quizs", "Image");
            DropColumn("dbo.QuizCategories", "Name");
            DropTable("dbo.Resultats");
            CreateIndex("dbo.QuizTests", "QuizId");
            CreateIndex("dbo.QuizTests", "UserId");
            CreateIndex("dbo.Quizs", "CategoryId");
            AddForeignKey("dbo.QuizTests", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.QuizTests", "QuizId", "dbo.Quizs", "Id");
            AddForeignKey("dbo.Quizs", "CategoryId", "dbo.QuizCategories", "Id");
        }
    }
}
