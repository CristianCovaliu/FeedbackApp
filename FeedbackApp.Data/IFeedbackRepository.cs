using System;
using System.Collections.Generic;
using System.Text;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Data
{
    public interface IFeedbackRepository
    {
        List<Feedback> GetAllFeedbacks();
        void CreateFeedback(Feedback feedback);
    }
}
