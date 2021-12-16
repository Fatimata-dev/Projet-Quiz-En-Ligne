﻿using Projet_Quiz_En_Ligne.Models;
using Projet_Quiz_En_Ligne.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Quiz_En_Ligne.Services
{
    public class QuizQuestionService : IQuizQuestionService
    {
        private IQuizQuestionRepository repo;

        public QuizQuestionService(IQuizQuestionRepository repo)
        {
            this.repo = repo;
        }

        public void Delete(int id)
        {
            repo.DeleteById(id);
        }

        public List<QuizQuestion> FindAll()
        {
            return repo.FindQuizzes();
        }

        public QuizQuestion FindById(int id)
        {
            return repo.FindById(id);
        }

        public void Insert(QuizQuestion quizQ)
        {
            repo.Insert(quizQ);
        }

        public void Update(QuizQuestion quizQ)
        {
            repo.Update(quizQ);
        }
    }
}