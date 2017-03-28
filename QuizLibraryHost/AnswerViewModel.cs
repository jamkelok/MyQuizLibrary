using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibraryHost
{
    public class AnswerViewModel
    {

        // Lokesh note : This viewmodel is a Class only to hide out the correct answer - a field 
        // which one would not disclose to the user
        public AnswerViewModel()
        {

        }
        public AnswerViewModel(Answer answer)
        {
            AnswerId = answer.AnswerId;
            QuestionId = answer.QuestionId;
            Content = answer.Content;
            ImageUrl = answer.ImageUrl;
            Reason = answer.Reason;
        }

        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Reason { get; set; }
    }
}
