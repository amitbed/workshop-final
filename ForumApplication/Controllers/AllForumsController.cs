using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ForumApplication.Controllers
{
    public class AllForumsController : Controller
    {

        public ActionResult ShowAllForums()
        {
            return View();
        }

    }
}
