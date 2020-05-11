using System;
using System.Collections.Generic;
using System.Text;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Data
{
    public interface IFeedbackRepository
    {
        void CreateFeedback(Feedback feedback);
    }
}
