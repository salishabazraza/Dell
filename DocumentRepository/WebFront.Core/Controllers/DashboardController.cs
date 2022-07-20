using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebFront.Core.Helper;

namespace WebFront.Core.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IConfiguration _config;
        private readonly RestService rest;

        public DashboardController(IConfiguration config)
        {
            _config = config;
            this.rest = new RestService(_config);
        }
        public IActionResult Index()
        {
            List<LoginApiModel> li = new List<LoginApiModel>();
            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            string noticification= HttpContext.Session.GetComplexData<string>("noticifcation");
            if (noticification!="")
            {
                ViewBag.Alert = noticification;
                HttpContext.Session.SetComplexData("noticifcation", "");
            }
            

            return View();
        }
    }
}
