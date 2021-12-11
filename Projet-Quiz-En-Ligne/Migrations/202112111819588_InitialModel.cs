namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuizCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuizQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QstText = c.String(),
                        IsMultiple = c.Boolean(nullable: false),
                        NumOrder = c.Int(nullable: false),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
            CreateTable(
                "dbo.QuizReponses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RespText = c.String(),
                        IsCorrect = c.Boolean(nullable: false),
                        QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizQuestions", t => t.QuestionId)
                .Index(t => t.QuestionId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.QuizId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sujet = c.String(),
                        CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizCategories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        TotalPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizTests", "UserId", "dbo.Users");
            DropForeignKey("dbo.QuizTests", "QuizId", "dbo.Quizs");
            DropForeignKey("dbo.QuizQuestions", "Quiz_Id", "dbo.Quizs");
            DropForeignKey("dbo.Quizs", "CategoryId", "dbo.QuizCategories");
            DropForeignKey("dbo.QuizReponses", "QuestionId", "dbo.QuizQuestions");
            DropIndex("dbo.Quizs", new[] { "CategoryId" });
            DropIndex("dbo.QuizTests", new[] { "QuizId" });
            DropIndex("dbo.QuizTests", new[] { "UserId" });
            DropIndex("dbo.QuizReponses", new[] { "QuestionId" });
            DropIndex("dbo.QuizQuestions", new[] { "Quiz_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Quizs");
            DropTable("dbo.QuizTests");
            DropTable("dbo.QuizReponses");
            DropTable("dbo.QuizQuestions");
            DropTable("dbo.QuizCategories");
        }
    }
}
