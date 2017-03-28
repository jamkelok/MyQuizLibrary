using QuizLibraryHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyQuizGameWebApp.Controllers
{
    // Lokesh : below annotation added for authorization
    // the same annotation is also in MvC controller
    [Authorize]

    public class QuizQuestionController : ApiController
    {
        // Lokesh Note
        // This is a replica of the QuizManager Controller
        // declare the variable _quizrepo - just declare so that when a value is passed on to it
        // the value is the same type as the declaration
        // declare it as static so that the same variable is accessed by multiple users
        // otherwise it will create mutiple copies/instances of the variable
        // in the empty controller invoked by the MVC
        //check if _quizrepo is empty i.e. null means whether it has not been
        // created as an instance of the 
        //& then create it as an instance of the EF repository

        private static IQuestionRepository _quizRepo;
        public QuizQuestionController()
        {
            if (_quizRepo == null)
            {
                _quizRepo = new QuestionRepositoryEf();
                //_quizRepo.LoadSampleQuestions();
            }
        }

        // create a Controller with a parameter to be used by the Unit test
        public QuizQuestionController(IQuestionRepository newRepo)
        {
            _quizRepo = newRepo;
        }

        // Lokesh end Note

        // Lokesh note : Next step is to populate the CRUDs
        // These methods on the CRUDs are apped to GET, POST i.e. HTTP calls 
        // & return a view as a shtml file
        // the difference between this and the QuizManager Controller
        // is that we need to get questions
        // so now we need to get to the respository to 
        // create a method to get a random question
        // the methos should  thereafter be extended to the interface
        // then we call that method in the method below which is called through 
        // an http call



        // GET: api/QuizQuestion

        // Lokesh note : here we have to make sure 
        // that the DOM is created with only those values which a user can see
        //  correct answers are not pulled up
        // therefore a ViewModel class has been created called QuestionViewModel
        // this is a Data Transfer Object (DTO)

        // Lokesh note : This method is  added later on for the Webapi
        // at the time of creating the Quiz Question Controller in the EFRepository
        // it is actually for the Quiz controller i.e. the user coming from the Quiz controller
        // to access the Questions

        // we also need to call one of the above classes class to couple with the Get method
        // so that we can use the httppost method to actually call the database record by id
        // that is the getQuestionbyid Class

        // so we have 2 methods in the WebAPI controller - the QuizQuestion Controller
        // (1) GET method to select id (2) GETQUESTIOnBy ID to get the actual question
        // The first method returns teh QuestionViewModel
        // the second method contains the actual if-then validation & returns a value
        [AllowAnonymous]
        public QuestionViewModel Get()
        {
            return _quizRepo.GetQuestion();
        }

        // Lokesh note : Then we create an annotation to Route
        // any api calls on the insanswercorrect method directly to the method below
        // this can also be done on the routing at App_start
        // but doing it here inserts the entry in the in-memory
        // Routing table at start

        [Route("api/quizquestion/isanswercorrect")]
        [AllowAnonymous]

        [HttpGet]
        public AnswerResults IsAnswerCorrect(int questionId, int answerId)
        {
            var question = _quizRepo.GetQuestionById(questionId);
            AnswerResults results = new AnswerResults();
            var selectedAnswer = question.Answers.First(a => a.AnswerId == answerId);

            if (selectedAnswer != null)
            {
                results.IsCorrect = selectedAnswer.IsCorrect;
            }

            return results;
        }


        // GET: api/QuizQuestion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QuizQuestion
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuizQuestion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuizQuestion/5
        public void Delete(int id)
        {
        }
    }
}
