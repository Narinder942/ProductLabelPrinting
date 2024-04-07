using ProductLabelPrinting.Models.Models;
using ProductLabelPrinting.Models.UIModel;
using ProductLabelPrinting.Repository.Abstract;
using ProductLabelPrinting.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ProductLabelPrinting.Web.Controllers
{
    public class AccountController : Controller
    {

        private IAccountRepository _account { get; set; }

        public AccountController(IAccountRepository account)
        {
            _account = account;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var myOjectLoginUIModel = new LoginUIModel();

            return View(myOjectLoginUIModel);
        }



        [HttpPost]
        public ActionResult Login(LoginUIModel myOjectLoginUIModel)
        {
            if (ModelState.IsValid)
            {
                var myObjectResponse = _account.CheckUser(myOjectLoginUIModel.UserName, myOjectLoginUIModel.Password);

                if (myObjectResponse.Status == true)
                {
                    Session[SessionHelper.UserDetail] = myObjectResponse.Response as EmployeeModel;

                    return RedirectToAction("Dashboard");
                }
                else
                {
                    TempData["NotificationMessage"] = "Swal.fire({ title: 'Login',  text: '" + myObjectResponse.Message + "',  icon: 'warning'});";
                }
            }

            return View(myOjectLoginUIModel);
        }

        [HttpGet]
        [CustomAuthenticationFilter]
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            Session.Abandon();
            
            return RedirectToAction("Login");
        }

    }
}