using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using ForumApplication.Models;

namespace ForumApplication.Controllers
{
    public class CreateForumController : Controller
    {
        public ActionResult CreateForum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewForum()
        {
            string title = Request["Forumtitle"].ToString();
            string admin = Request["Forumtitle"].ToString();
            List<string> admins = new List<string>();
            admins.Add(admin);
            ForumSystem fs = ForumSystem.initForumSystem();
            Forum newForum = new Forum(title, admins);
            fs.createForum(newForum);
            return View();
        }

    }
}
