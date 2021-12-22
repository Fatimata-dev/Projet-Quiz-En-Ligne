namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelsNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuizCategories", newName: "Categories");
            RenameTable(name: "dbo.QuizQuestions", newName: "Questions");
            RenameTable(name: "dbo.QuizReponses", newName: "Reponses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Reponses", newName: "QuizReponses");
            RenameTable(name: "dbo.Questions", newName: "QuizQuestions");
            RenameTable(name: "dbo.Categories", newName: "QuizCategories");
        }
    }
}
