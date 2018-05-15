using System.Web.Mvc;
using MySchool.Entities.ViewModels;
using MySchool.Utilities;

namespace MySchool.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The is the main home page for the website.
        /// It contains links to the following pages:
        /// AllClasses, MyClasses, and Register Classes.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This page displays information about
        /// the website creator. It contains no links.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// This page displays contact information for
        /// the website business. It contains no links.
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// This page displays a list of classes being offered
        /// at the Learning Center. It contains no links.
        /// </summary>
        /// <returns></returns>
        public ActionResult AllClasses()
        {
            return View(HomeManager.DisplayAllClasses());
        }

        /// <summary>
        /// This page displays a list of classes that the user
        /// is currently registered to attend. It contains no links.
        /// If no authentication exists, the user is redirected
        /// to the LogIn page.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult MyClasses()
        {
            return View(HomeManager.DisplayMyClasses((string)Session["UserName"]));
        }

        /// <summary>
        /// This page displays a list of classes being offered
        /// at the Learning Center. It allows for the user to select
        /// a class and add it to their list of registered classes.
        /// It contains a submit button, and no links. If no authentication
        /// exists, the user is redirected to the LogIn page.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult RegisterClasses()
        {
            return View(HomeManager.DisplayAllClasses());
        }

        /// <summary>
        /// Upon clicking the submit button, the information for the
        /// selected class is passed to the Home Manager to be verified
        /// and potentially added to the user's list of registered classes.
        /// If successful, the user is redirected to the MyClasses page.
        /// </summary>
        /// <param name="selectedClass"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegisterClasses(ListClassesViewModel selectedClass)
        {
            if (HomeManager.AddNewClass((string)Session["UserName"], selectedClass))
            {
                return Redirect("MyClasses");
            }
            return View(HomeManager.DisplayAllClasses());
        }
    }
}