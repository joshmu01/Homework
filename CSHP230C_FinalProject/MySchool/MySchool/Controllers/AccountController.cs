using System.Web.Mvc;
using System.Web.Security;
using MySchool.Entities.ViewModels;
using MySchool.Utilities;

namespace MySchool.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// This page contains entry fields for User Name, Email, and
        /// Password, allowing for the user to create a new website 
        /// user account. It contains a Submit button and no links.
        /// </summary>
        /// <returns></returns>
        public ActionResult NewUser()
        {
            return View();
        }

        /// <summary>
        /// Upon clicking the submit button, the information for the
        /// new account is passed to the Account Manager to be verified
        /// and potentially added to the website's database.
        /// If successful, the user is redirected to the LogIn page.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult NewUser(NewOrUpdateProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!AccountManager.IsUserNameAvailable(model.Name))
                {
                    ModelState.AddModelError("Name",
                        "That user name is already in use. Please create a different one.");
                }
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword",
                        "This password doesn't match. Please confirm your password.");
                }
                if (AccountManager.AddNewUser(model))
                {
                    return Redirect("LogIn");
                }
            }
            return View();
        }

        /// <summary>
        /// This page contains entry fields for User Name and Password,
        /// allowing for the user to log into the website. It contains
        /// a Submit button and no links.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// Upon clicking the Login NavBar item, a Session is begun with the
        /// UserName as a value, and an Authentication cookie is created (signed-in).
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LogIn(LogInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid && AccountManager.IsUserValid(model.Name, model.Password))
            {
                Session["UserName"] = model.Name;
                FormsAuthentication.SetAuthCookie(model.Name, false);
                return Redirect(returnUrl ?? "~/");
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View();
        }

        /// <summary>
        /// Upon clicking the Logout NavBar item, the current Session
        /// is ended and the Authentication cookie is deleted (signed-out).
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }
    }
}