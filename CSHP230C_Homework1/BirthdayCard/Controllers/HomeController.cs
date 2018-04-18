using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirthdayCard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CardForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CardForm(Models.CardDetails cardDetails)
        {
            if (ModelState.IsValid)
            {
                return View("CardSent", cardDetails);
            }
            else
            {
                return View();
            }
        }

    }
}