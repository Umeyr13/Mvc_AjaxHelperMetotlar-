using Mvc_A_Metotları.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_AjaxHelperMetotları.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> list = new List<string>() { "Teknoloji", "Sağlık", "Giyim", "Gıda" };
            Session["Liste"] = list;
            return View();
        }

        public PartialViewResult VeriYukle() 
        {
            List<string> veriler = (List<string>)Session["Liste"];
            System.Threading.Thread.Sleep(1200);
            return PartialView("_PartialPageVeriler",veriler);
        }
        public MvcHtmlString VeriSil(int id)
        {
            List<string> veriler = (List<string>)Session["Liste"];
            veriler.RemoveAt(id);
            Session["Liste"] = veriler;//Veriyi silince yeni verileri sesiona verdik. Yoksa eski silinmemiş veriler kalırdı.
            return MvcHtmlString.Empty;
        }

        public ActionResult Index2()
        {
            List<Kisi> kisiler = new List<Kisi>();
            if (Session["kisiler"] != null)
            {
                kisiler = (List<Kisi>)Session["kisiler"];

            }
            ViewBag.kisiler = kisiler;
            return View();
        }
        [HttpPost]
        public PartialViewResult Index2(Kisi kisi) 
            {
                List<Kisi> kisiler = new List<Kisi>();
            if (Session["kisiler"]!=null)
            {
                kisiler = (List<Kisi>)Session["kisiler"];

            }

            else
            {
               kisiler = new List<Kisi>();
            }
                kisi.Id = Guid.NewGuid();
                kisiler.Add(kisi);

                Session["kisiler"] = kisiler;
                return PartialView("_PartialPageKisiler",kisi);

        }  

        public ActionResult Test()
        {
            return View();
        }
    }
}