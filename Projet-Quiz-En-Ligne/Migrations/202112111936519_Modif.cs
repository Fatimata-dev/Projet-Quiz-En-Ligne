namespace Projet_Quiz_En_Ligne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.QuizQuestions", name: "Quiz_Id", newName: "QuizId");
            RenameIndex(table: "dbo.QuizQuestions", name: "IX_Quiz_Id", newName: "IX_QuizId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuizQuestions", name: "IX_QuizId", newName: "IX_Quiz_Id");
            RenameColumn(table: "dbo.QuizQuestions", name: "QuizId", newName: "Quiz_Id");
        }
    }
}
