using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebFront.Core.Helper;
using WebFront.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebFront.Core.Controllers
{
    public class LoginController : Controller
    {

        private readonly IConfiguration _config;
        private readonly RestService rest;

        public LoginController(IConfiguration config)
        {
            _config = config;
            this.rest = new RestService(_config);
        }
        public IActionResult Index()
        {
            string noticification = HttpContext.Session.GetComplexData<string>("noticifcation");
            if (noticification != "")
            {
                ViewBag.Alert = noticification;
                HttpContext.Session.SetComplexData("noticifcation", "");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var result = await rest.GetLoginApi(model);

            if (result.code == 200)
            {
                List<LoginApiModel> li = new List<LoginApiModel>();
                li.Add(new LoginApiModel
                {
                    firstName = result.data.firstName,
                    lastName = result.data.lastName,
                    token = result.data.token

                });
                HttpContext.Session.SetComplexData("loggerUser", li);
                // string valueFromSession = Session["foo"].ToString();
                li = new List<LoginApiModel>();
                li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");

                
                    HttpContext.Session.SetComplexData("noticifcation" ,CommonServices.ShowAlert(Alerts.Success, "Login Successfull"));
                


                return RedirectToAction("index", "dashboard");
            }
            else
            {
                Debug.WriteLine(@"[{1}]ERROR {0}", result.code + " " + result.description, "Login");
                
                return RedirectToAction("index", "login");
            }

        }
        public async Task<ActionResult> logout(LoginModel model)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();
            HttpContext.Session.SetComplexData("loggerUser", li);
            ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Login Successfull");
            HttpContext.Session.SetComplexData("noticifcation", CommonServices.ShowAlert(Alerts.Success, "Logout Successfull"));
            return RedirectToAction("Index", "Login");
        }



    }

}
