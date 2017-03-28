using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizLibraryHost;

namespace MyQuizGameWebApp.Controllers
{

    // Lokesh : below two annotations added for authorization
    [RequireHttps]
    [Authorize]

    public class QuizManagerController : Controller
    {
        // declare the variable _quizrepo - just declare so that when a value is passed on to it
        // the value is the same type as the declaration
        // declare it as static so that the same variable is accessed by multiple users
        // otherwise it will create mutiple copies/instances of the variable
        // in the empty controller invoked by the MVC
        //check if _quizrepo is empty i.e. null means whether it has not been
        // created as an instance of the 
        //& then create it as an instance of the EF repository

        private static IQuestionRepository _quizRepo;
        public QuizManagerController()
        {
            if (_quizRepo == null)
            {
                _quizRepo = new QuestionRepositoryEf();
                //_quizRepo.LoadSampleQuestions();
            }
        }

        // create a Controller with a parameter to be used by the Unit test
        public QuizManagerController(IQuestionRepository newRepo)
        {
            _quizRepo = newRepo;
        }

        // Next step is to populate the CRUDs
        // These methods on the CRUDs are apped to GET, POST i.e. HTTP calls 
        // & return a view as a shtml file
        //View() is a method in the Controller class
        // QuizManager Controller is a instance of the Controller class 
        // PAss on to the view method the Result returned fromm the relevant method 
        // of the repository instance _quizRepo


        // GET: QuizManager
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_quizRepo.GetQuestions());
        }

        // GET: QuizManager/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // GET: QuizManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizManager/Create
        [HttpPost]
        public ActionResult Create(Question newQuestion)
        {
            try
            {
                // TODO: Logic inserted below
                _quizRepo.AddQuestion(newQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: QuizManager/Edit/5
        // follows the GET to post the form
        [HttpPost]
        public ActionResult Edit(int id, Question editQuestion, FormCollection collection)
        {
            try
            {
                // TODO: Logic updated below
                _quizRepo.UpdateQuestion(editQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: QuizManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuestion(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
