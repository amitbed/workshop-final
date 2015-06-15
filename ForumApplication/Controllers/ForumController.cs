using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.Controllers
{
    public class ForumController : Controller
    {
        public ActionResult ShowAllThreads()
        {
            return View();
        }

    }
}
