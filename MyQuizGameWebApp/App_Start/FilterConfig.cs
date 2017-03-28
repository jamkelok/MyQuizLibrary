using System.Web;
using System.Web.Mvc;

namespace MyQuizGameWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Lokesh : the two enries below set the overall attributes for Login
            // these are overidden by the allow anonymous annotations at method level
            // for example see the Home Controller where allow anonymous is used for the Index() method 

            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
