using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumApplication.Models;

namespace ForumApplication.Controllers
{
    public class AllForumsController : Controller
    {

        public ActionResult ShowAllForums(string s)
        {
            return View(s);
        }

    }
}
