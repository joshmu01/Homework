using System.Linq;
using System.Web.Mvc;
using TheLearningCenter.Models;
using TheLearningCenter.Repositories;

namespace TheLearningCenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repository;

        public HomeController(Repository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult AllClasses()
        {
            return View(_repository.GetClassList());
        }

        [Authorize]
        public ActionResult MyClasses()
        {
            UserModel currentUser = _repository.GetUser((string)Session["UserName"]);
            return View(currentUser.UserClasses.AsEnumerable());
        }

        [Authorize]
        public ActionResult RegisterClasses()
        {
            return View(_repository.GetClassList());
        }

        [HttpPost]
        public ActionResult RegisterClasses(ClassModel selectedClass)
        {
            UserModel currentUser = _repository.GetUser((string)Session["UserName"]);
            if (currentUser.UserClasses.Contains(selectedClass))
            {
                ModelState.AddModelError("", "You're already enrolled in this class.");
                return View(_repository.GetClassList());
            }

            if (currentUser.UserId == null || selectedClass.ClassId == null)
            {
                ModelState.AddModelError("", "A database error occurred while registering this class. Please try again.");
                return View(_repository.GetClassList());
            }

            if (!_repository.AddUserClass(currentUser, selectedClass))
            {
                ModelState.AddModelError("", "A database error occurred while registering this class. Please try again.");
                return View(_repository.GetClassList());
            }
            return Redirect("MyClasses");
        }
    }
}