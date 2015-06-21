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
        public ActionResult CreateForum(string id)
        {
            if (ForumApplication.Models.ForumSystem.superadmin.Equals(id))
                return View();
            else
                return View("../OnlySuperAdmin");
        }
    

        [HttpGet]
        [HttpPost]
        public ActionResult CreateNewForum(string id)
        {
            string title = Request["Forumtitle"].ToString();
            string admin = Request["adminUserName"].ToString();
            List<string> admins = new List<string>();
            admins.Add(admin);
            ForumSystem fs = ForumSystem.initForumSystem();
            Forum newForum = new Forum(title, admins);
            bool res = fs.createForum(newForum, id);
            if (res)
                return View();
            else
                return View("OnlySuperAdmin");

        }

    }
}
