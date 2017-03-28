using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // Added for Entity Framework Libraries


namespace QuizLibraryHost
{
    public class QuestionRepositoryEf : IQuestionRepository
    {

        // Lokesh Note : Instantiate new list of questions
        /* Lokesh Note : only in memeory    
        private List<Question> _questionList = new List<Question>();  
        // declare an id var since in the objec it does not auto increment
        private static int nextId = 0;
        Lokesh - end note */


        // Lokesh Note : general getter to get all questions for the Quiz manager
        public List<Question> GetQuestions()
        {
            /* Lokesh note : only in memory     
             return _questionList; 
             */
            
            // Lokesh Note : below code only EF

            using (var db = new MyQuizModel())
            {
                var questions = from q in db.Questions
                                orderby q.QuestionId descending
                                select q;

                // The type of var CLI library  above is defined from the select statement to the right
                return questions.ToList();
            }

            // end only in ef

        }

        // get only one question by id
        public Question GetQuestionById(int id)
        {
            /* only in in memory
             return _questionList.Find(question => question.QuestionId == id);
             */
            // only in EF
            using (var db = new MyQuizModel())
            {
                var question = db.Questions.Find(id);
                db.Entry(question).Collection(q => q.Answers).Load();
                return question;
            }
            // end only in ef

        }

        // for the manager to add, update or delete a new question
        public void AddQuestion(Question newQuestion)
        {
            /* only in in memory
            newQuestion.QuestionId = nextId++;
            _questionList.Add(newQuestion);
            */
            // below code only in EF
            newQuestion.Content = newQuestion.Content + "?";

            using (var db = new MyQuizModel())
            {
                db.Questions.Add(newQuestion);
                // Saving of changes is required seperately for databases
                db.SaveChanges();
            }
            // end of code for ef

        }
        public void UpdateQuestion(Question UpdateQuestion)
        {
            /* only in in memory
            _questionList.RemoveAll(question => question.QuestionId == UpdateQuestion.QuestionId);
            _questionList.Add(UpdateQuestion);
            */
            // below code only in EF
            using (var db = new MyQuizModel())
            {
                db.Questions.Attach(UpdateQuestion);
                // instead of add there is attach and change the property of the entry to modified so that the http communication sees the flag and does the select and update. this is becuase
                // the database is not in-memory
                var entry = db.Entry(UpdateQuestion);
                entry.State = System.Data.Entity.EntityState.Modified;

                foreach (var answer in UpdateQuestion.Answers)
                {
                    var AnswerEntry = db.Entry(answer);
                    AnswerEntry.State = System.Data.Entity.EntityState.Modified;
                }
                // save changes fo that the context sees modified and saves changes
                db.SaveChanges();
            }
            // end of code for ef
        }
        /* only in in memory 
        public void DeleteQuestion(Question DeleteQuestion)
        {
         _questionList.RemoveAll(question => question.QuestionId == DeleteQuestion.QuestionId);
        }
         */
        public void DeleteQuestion(int id)
        {
            using (var db = new MyQuizModel())
            {
                var question = db.Questions.Find(id);
                db.Questions.Remove(question);
                db.SaveChanges();
            }
        }


        // Lokesh note : This method is  added later on for the Webapi
        // at the time of creating the Quiz Question Controller
        // it is actually for the Quiz controller i.e. the user coming from the Quiz controller
        // to access the Questions

        // we also need to call one of the above classes class to couple with the Get method
        // so that we can use the httppost method to actually call the database record by id
        // that is the getQuestionbyid Class

        // so we have 2 methods in the WebAPI controller - the QuizQuestion Controller
        // (1) GET method to select id (2) GETQUESTIOnBy ID to get the actual question
        // The first method returns teh QuestionViewModel
        // the second method contains the actual if-then validation & returns a value


        private static Random _randy = new Random();
        public QuestionViewModel GetQuestion()
        {
            using (var db = new MyQuizModel())
            {
                var qList = db.Questions
                    .Include(j => j.Answers)
                    .ToList();

                return new QuestionViewModel(qList[_randy.Next(0, qList.Count)]);
            }
        }




    }
}
