using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumApplication.Models;
using System.IO;

namespace ForumApplication.Controllers
{
    public class ShowAllSubForumsController : Controller
    {
        //
        // GET: /ShowAllThreads/

        public ActionResult ShowAllSubForums()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewForum()
        {
            return View();
        }

    }
}
