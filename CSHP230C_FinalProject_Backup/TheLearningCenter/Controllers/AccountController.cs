using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheLearningCenter.Models;
using TheLearningCenter.Repositories;

namespace TheLearningCenter.Controllers
{
    public class AccountController : Controller
    {
        private readonly Repository _repository;

        public AccountController(Repository repository)
        {
            _repository = repository;
        }

        public ActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewUser(NewUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (_repository.UserNameExists(model.Name))
            {
                ModelState.AddModelError("Name", "That user name is already in use. Please create a different one.");
                return View();
            }

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "This password doesn't match. Please confirm your password.");
                return View();
            }
            if (!_repository.AddUser(_repository.CreateUserModel(model)))
            {
                ModelState.AddModelError("", "A database error occurred while creating your new account. Please try again.");
                return View();
            }
            return Redirect("LogIn");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!_repository.UserExists(model.Name, model.Password))
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View();
            }
            Session["UserName"] = model.Name;
            FormsAuthentication.SetAuthCookie(model.Name, false);
            return Redirect(returnUrl ?? "~/");
        }

        public ActionResult LogOut()
        {
            Session["UserName"] = null;
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }
    }
}