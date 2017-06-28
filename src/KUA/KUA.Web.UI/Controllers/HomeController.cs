using KUA.LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace KUA.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string fileTitle)
        {
            KUA.Web.UI.Models.IndexViewModel model = new Models.IndexViewModel();

            try
            {
                HttpPostedFileBase file = Request.Files[0];
                byte[] binData = new byte[file.ContentLength];
                file.InputStream.Read(binData, 0, (int)file.ContentLength);

                string result = System.Text.Encoding.UTF8.GetString(binData);

                StringBuilder strOut = new StringBuilder(result);
                ChessBoardManager.Instance.ClearBoards();

                ChessBoardManager.Instance.LoadBoards(strOut);

                strOut = ChessBoardManager.Instance.FindKingInCheck();


                model.Result = strOut.ToString();

                
            }
            catch (Exception e)
            {
                ModelState.AddModelError("uploadError", e);
            }
            return View(model);

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
    }
}