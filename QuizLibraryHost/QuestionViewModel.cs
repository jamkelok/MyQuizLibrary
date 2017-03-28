using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibraryHost
{
    public class QuestionViewModel
    {

        // Lokesh note : This class is called the data transfer Object (DTO)
        // It hold data between the browser client DOM and the server
        // and only data which can be allowed to be seen by the user
        // a seperate class is created for the unseen data
        // which be instantiated only when an event by the evet handler is invoked
        // That seperate class is called the "results" class in this example


        public QuestionViewModel()
        {
            Answers = new List<AnswerViewModel>();
        } 
        public QuestionViewModel(Question question)
        {
            Answers = new List<AnswerViewModel>();

            QuestionId = question.QuestionId;
            Category = question.Category;
            Content = question.Content;
            ImageUrl = question.ImageUrl;
            QuestionType = question.QuestionType;
            ReasonForAnswer = question.ReasonForAnswer;
       
            foreach (var answer in question.Answers)
            {
                Answers.Add(new AnswerViewModel (answer));
            }
           


        }

        public int QuestionId { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string MoreInfoUrl { get; set; }
        public string QuestionType { get; set; }
        public string ReasonForAnswer { get; set; }
        public virtual ICollection<AnswerViewModel> Answers { get; set; }
    }
}
