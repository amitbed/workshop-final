using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumApplication.Models;

namespace ForumApplication.Controllers
{
    public class HomeController : Controller
    {
        ForumSystem fs;
        public ActionResult Index()
        {
            ViewBag.Message = "Our Forum Application";
            fs = ForumSystem.initForumSystem();
            return View();
        }
    }
}
