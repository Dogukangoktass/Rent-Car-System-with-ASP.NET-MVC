using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RCP.UI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
    }
}