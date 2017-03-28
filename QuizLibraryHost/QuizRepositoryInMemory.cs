using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibraryHost
{
    public class QuizRepositoryInMemory
    {
        // Instantiate new list of questions

        private List<Question> _questionList = new List<Question>();
        // declare an id var since in the objec it does not auto increment

        private static int nextId=0; 


        // general getter to get all questions for the manager
        public List<Question> GetQuestions()
        {
            return _questionList;
        }

        // get only one question by id
        public Question GetQuestion(int id)
        {
            return _questionList.Find(question => question.QuestionId == id);
        }

        // for the manager to add, update or delete a new question
        public void AddQuestion(Question newQuestion)
        {
            newQuestion.QuestionId = nextId++;
            _questionList.Add(newQuestion);
        }
        public void UpdateQuestion(Question UpdateQuestion)
        {
            _questionList.RemoveAll(question => question.QuestionId == UpdateQuestion.QuestionId);
            _questionList.Add(UpdateQuestion);
        }
        public void DeleteQuestion(Question DeleteQuestion)
        {
            _questionList.RemoveAll(question => question.QuestionId == DeleteQuestion.QuestionId);
          
        }

        // Lokesh note : This method is  added ater on for the Webapi
        // at the time of creating the Quiz Question Controller
        // it is actually for the Quiz controller i.e. the user coming from the Quiz controller
        // to access the Questions
        // there is a similar addition to the EF repository
        // but that can only call a random question


        public QuestionViewModel GetQuestion()
        {
            return new QuestionViewModel(GetQuestions(1)[0]);
        }

        private static Random _randy = new Random();


        public List<Question> GetQuestions(int maxNumberOfQuestions)
        {
            

            if (_questionList.Count == 0)
            {
                return _questionList;
            }
            // Create a new list that will contain the number of questions
            // requested. THIS is the one we'll return, NOT the whole 

            List<Question> returnList = new List<Question>();

            /// This return list will be used to hold the randomly generated questions

            for (int i = 0; i < maxNumberOfQuestions; i++)
            {
                // Idea 1: Get the question at the random index in the list
                int myRandomNumber = _randy.Next(0, _questionList.Count);

                // Get the question from the whole list at the index
                // of the random number we just generated.
                // Add that question to the returnList.
                returnList.Add(_questionList[myRandomNumber]);
            }

            return returnList; // The temporary list we created
        }



    }
}
