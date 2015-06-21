using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
namespace unitTestingDevelopers
{
    [TestClass]
    public class ForumUT
    {
        ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();
        [TestMethod]
        public void checkMember1()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Assert.IsTrue(system.Members.ContainsKey("ifateli"));
        }
    }
}
