using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
namespace unitTestingDevelopers
{
    [TestClass]
    public class GuestUT
    {
        ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();
        [TestMethod]
        public void registerTest()
        {
            bool ans = false;
         
            Guest Nofar = new Guest();
            Nofar.register("benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            if (system.Members.ContainsKey("benshnof"))
            {
                ans = (system.Members["benshnof"] != null);
            }
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void loginTest()
        {
            Guest NofarGuest = new Guest();
            String nofarID = NofarGuest.register("benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            String forumList = NofarGuest.login("benshnof", "matanShoham");
            String realForumList = system.displayForums();
            Assert.IsTrue(String.Equals(forumList, realForumList));
        }

    }
}
