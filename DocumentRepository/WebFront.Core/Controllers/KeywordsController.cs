using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebFront.Core.Helper;
using WebFront.Core.Models;

namespace WebFront.Core.Controllers
{
    public class KeywordsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly RestService rest;


        public KeywordsController(IConfiguration config)
        {
            _config = config;
            this.rest = new RestService(_config);
        }
        public async Task<ActionResult> Index()
        {

            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            var result = await rest.GetKeywords(li[0].token);
            ViewBag.result = result;
            string noticification = HttpContext.Session.GetComplexData<string>("noticifcation");
            if (noticification != "")
            {
                ViewBag.Alert = noticification;
                HttpContext.Session.SetComplexData("noticifcation", "");
            }
            return View();
        }

        public async Task<ActionResult> Partial(string keywordId)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            var result = await rest.GetKeyword(li[0].token, keywordId);
            ViewBag.result = result;
            return View();
        }

        public async Task<ActionResult> Edit(KeywordCreateandUpdateModel model)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            if (model.keywordId == 0)
            {
                ViewBag.result = model;
                return View();
            }
            else
            {
                var result = await rest.GetKeyword(li[0].token, model.keywordId.ToString());
                model.title = result.data.keyword.title;
                model.keywordId = result.data.keyword.keywordId;
                ViewBag.result = model;
                return View();
            }

        }

        public async Task<ActionResult> Save(KeywordCreateandUpdateModel model)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            await rest.PostSaveAandUpdateKeyword(li[0].token, model);

            HttpContext.Session.SetComplexData("noticifcation", CommonServices.ShowAlert(Alerts.Success, "Successfull"));
            return RedirectToAction("index", "Keywords");

        }


        public async Task<ActionResult> Delete(string keywordId)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            await rest.DelKeyword(li[0].token, keywordId);

            HttpContext.Session.SetComplexData("noticifcation", CommonServices.ShowAlert(Alerts.Success, "Successfull"));
            return RedirectToAction("Index", "Keywords");
        }

    }
}
