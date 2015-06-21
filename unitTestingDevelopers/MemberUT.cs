using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumSystem;
namespace unitTestingDevelopers
{
    [TestClass]
    public class MemberUT
    {
        ForumSystem.ForumSystem system = ForumSystem.ForumSystem.initForumSystem();
        [TestMethod]
        public void checkMember1()
        {
            Member CheckingMember = system.addMember("ifateli","gilAd","ifateli@bgu.ac.il");
            Assert.IsTrue(system.Members.ContainsKey("ifateli"));
        }

        [TestMethod]
        public void checkMember2()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Assert.IsTrue(system.Members.ContainsValue(CheckingMember));
        }

        [TestMethod]
        public void checkMember3()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Assert.IsFalse(system.Members.ContainsKey("checking"));  
        }

        [TestMethod]
        public void checkMember4()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            Member BadChecking = new Member("aaa", "bbb", "ccc");
            Assert.IsFalse(system.Members.ContainsValue(BadChecking));
        }

        [TestMethod]
        public void checkMemberTypeRegular()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            bool ans= CheckingMember.MemberType ==(int) Types.Regular;
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void checkMemberTypeSilver()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            CheckingMember.upgrade();
            bool ans = CheckingMember.MemberType == (int)Types.Silver;
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void checkMemberTypeGold()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            CheckingMember.upgrade();
            CheckingMember.upgrade();
            bool ans = CheckingMember.MemberType == (int)Types.Gold;
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void checkMemberPassword()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            bool ans = CheckingMember.changePassword("Neta");
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void checkMemberBadPassword()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            bool ans = CheckingMember.changePassword("gilAd");
            Assert.IsFalse(ans);
        }

        [TestMethod]
        public void checkMemberCapsLockPassword()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            bool ans = CheckingMember.changePassword("IFAT");
            Assert.IsTrue(ans);
        }

        [TestMethod]
        public void checkMemberNonCapsLockPassword()
        {
            Member CheckingMember = system.addMember("ifateli", "gilAd", "ifateli@bgu.ac.il");
            bool ans = CheckingMember.changePassword("gilad");
            Assert.IsTrue(ans);
        }
    }
}
