using System.Web.Mvc;

namespace TheLearningCenter.Controllers
{
    public class SharedController : Controller
    {
        public PartialViewResult DisplayUserName()
        {
            return new PartialViewResult();
        }
    }
}