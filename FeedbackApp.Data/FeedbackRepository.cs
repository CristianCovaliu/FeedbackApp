using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FeedbackApp.Domain;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Data
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;

        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        } 
        public void CreateFeedback(Feedback feedback)
        {
            feedback.FeedbackPlaced = DateTime.Now;

            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return _appDbContext.Feedbacks.ToList();
        }
    }
}
