using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyQuizGameWebApp.Controllers
{
    public class HomeController : Controller

    // Lokesh : This home Controller is the default controller called from the
    // routeconfig.cs table as
    // defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
    // Upon startup it populates a route table which is in memory
    // Any annotations such as those directly to a method are also shifted to a route table


    // Lokesh : This controller has a view already created in the template in the Home folder

    // Lokesh : Create the Api Controller after this with a method and a route to execute the game
    // create a Json ethod in it

    // After that go to the home controller view 
    // Go to that view and insert any Buttons or Script Scrc for Event Handling.
    // The Scripts go into the Scripts folder 

    {

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}