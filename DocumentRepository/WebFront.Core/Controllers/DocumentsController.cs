using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebFront.Core.Helper;

namespace WebFront.Core.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly RestService rest;

        public DocumentsController(IConfiguration config)
        {
            _config = config;
            this.rest = new RestService(_config);
        }
        public async Task<ActionResult> Index(int[] keywordId)
        {

            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }

            await NewMethod(keywordId, li);

            return View();
        }

       
        public async Task<ActionResult> Partial(string documentId)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            var result = await rest.GetDocument(li[0].token, documentId);
            ViewBag.result = result;

            return View();
        }

        public async Task<ActionResult> Edit(KeywordDocumentAPIModel model)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            if (model.documentId == 0)
            {
                return RedirectToAction("index", "documents");
            }
            else
            {
                var result = await rest.GetDocument(li[0].token, model.documentId.ToString());
                model.documentId = result.data.document.documentId;
                List<KeywordDocumentModel> li2 = new List<KeywordDocumentModel>();
                foreach (var item in result.data.keywords)
                {
                    li2.Add(new KeywordDocumentModel
                    {
                        documentKeywordId = result.data.document.documentId,
                        keywordId = item.keywordId,
                        title = item.title
                    });
                }
                model.keywordDocumentModel = li2;
                ViewBag.result = model;
                var Keywords = await rest.GetKeywords(li[0].token);
                ViewBag.Keywords = Keywords;
                return View();
            }

        }

        public async Task<ActionResult> Save(KeywordDocumentAPIModel model, int[]? keywordId)
        {
            List<LoginApiModel> li = new List<LoginApiModel>();

            li = HttpContext.Session.GetComplexData<List<LoginApiModel>>("loggerUser");
            if (li.Count == 0)
            {
                return RedirectToAction("index", "login");
            }
            List<KeywordDocumentModel> li2 = new List<KeywordDocumentModel>();
            if (keywordId != null)
            {
                foreach (var i in keywordId)
                {
                    li2.Add(new KeywordDocumentModel { keywordId = i, title = "-" });
                }
            }
            model.keywordDocumentModel = li2;

            await rest.PostSaveAandUpdateDocument(li[0].token, model);

            HttpContext.Session.SetComplexData("noticifcation", CommonServices.ShowAlert(Alerts.Success, "Successfull"));
            return RedirectToAction("index", "documents");

        }
        private async Task NewMethod(int[] keywordId, List<LoginApiModel> li)
        {
            ViewBag.keywordIdSearch = keywordId;
            var Keywords = await rest.GetKeywords(li[0].token);
            ViewBag.Keywords = Keywords;

            if (keywordId.Length > 0)
            {
                var result = await rest.GetDocumentsSearch(li[0].token, keywordId);
                APISystemReturnModel<ObservableCollection<DocumentAPIModel>> li2 =
                    new APISystemReturnModel<ObservableCollection<DocumentAPIModel>>();

                ObservableCollection<DocumentAPIModel> li3 = new ObservableCollection<DocumentAPIModel>();
                if (result.data != null)
                {
                    foreach (var item in result.data)
                    {
                        li3.Add(new DocumentAPIModel { document = item });
                    }
                }
                li2.data = li3;
                ViewBag.result = li2;
            }
            else
            {
                var result = await rest.GetDocuments(li[0].token);
                ViewBag.result = result;
            }
            string noticification = HttpContext.Session.GetComplexData<string>("noticifcation");
            if (noticification != "")
            {
                ViewBag.Alert = noticification;
                HttpContext.Session.SetComplexData("noticifcation", "");
            }
        }

    }
}
