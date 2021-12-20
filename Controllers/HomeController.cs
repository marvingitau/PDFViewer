using ASPPdfViewer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace ASPPdfViewer.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyFiles db  = new MyFiles();
        public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
                base.OnActionExecuting(filterContext);
            }
        }

        [AllowCrossSiteJson]
        public ActionResult Index()
        {
            string pdfUrl = "//pupool.ke/uploads/5_1638012066.pdf";
            string pdfUrl2 = db.Files.Single(e => e.ID == 6).DocName;
            ViewData["src"] = pdfUrl + "#embedded=true&toolbar=0&navpanes=0";
            ViewBag.File = pdfUrl2;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Upload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Upload1(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"),Path.GetFileName(file.FileName));
                    //List<FilesUpload> aux = new List<FilesUpload>
                    //{
                    //    new FilesUpload
                    //    {
                    //        DocName=path
                    //    }
                    //};

                    file.SaveAs(path);


                    db.Files.Add(
                         new FilesUpload
                         {
                             DocName = Path.GetFileName(file.FileName)
                         });

                    db.SaveChanges();


                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View("Upload");
        }

    }
}