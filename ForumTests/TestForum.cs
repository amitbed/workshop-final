using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumApplication.Models;
using System.Collections.Generic;


namespace ForumTests
{
    [TestClass]
    public class TestForum : ProjectTest
    {
        private Forum Dating, Food;
        private Member Sagi, Amit, Dean;
        

        public override void SetUp()
        {
            base.SetUp();
            setUpForum();
        }

        private void setUpForum()
        {
            Dating = searchForum("Dating");
            Food = searchForum("Food");
            Sagi = getMember("sagiav1");
            Amit = getMember("amitbed1");
            Dean = getMember("abadie1");

        }

        //UC1 - init Forum
        [TestMethod]
        public void initForumTest()
        {
            SetUp();
            Assert.IsNotNull(system);
            Assert.IsNotNull(Dating);
            Assert.IsNotNull(Food);
            Assert.IsNotNull(Sagi);
            Assert.IsNotNull(Amit);
            Assert.IsNotNull(Dean);
            Assert.IsTrue(isGuestRegistered("sagiav1"));
            Assert.IsTrue(isGuestRegistered("amitbed1"));
            Assert.IsTrue(isGuestRegistered("abadie1"));
        }

        //UC2 - Create Forum
        [TestMethod]
        public void isSystemDuplicatedTest()
        {
            Assert.AreEqual<int>(2, system.Forums.Count);
        }

        [TestMethod]
        public void addForumTest()
        {
            int prevNumOfForums = system.Forums.Count;
            List<string> adminSport = new List<string>();
            adminSport.Add("abadie");
            Forum Sport = createForum("Sport", adminSport);
            int newNumOfForums = system.Forums.Count;
            Assert.IsNotNull(Sport);
            Assert.AreEqual<int>(newNumOfForums, prevNumOfForums + 1);
        }
        //UC3 - setProperties
        //UC4 - enter forum
        //UC5 - register
        //UC6 - login / logout
        [TestMethod]
        public void registerAndLoginTest()
        {
            Guest Nofar = new Guest();
            Register(Nofar, "benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
            Assert.IsTrue(isGuestRegistered("benshnof"));
            //Assert.IsFalse(isGuestRegistered("nofar"));
            //make a new is false test: write method IsNotRegisterd
            string forumList = login(Nofar, "benshnof", "matanShoham");
            Assert.IsNotNull(forumList);
            Assert.IsTrue(isMemberExist("benshnof"));
        }

        [TestMethod]
        public void loginFalseTest()
        {
      
            Guest Ifat = new Guest();
            login(Ifat, "ifateli", "bla");
            Assert.IsFalse(isMemberExist("ifateli"));
        }
        
        //UC7 - Create SubForum
        [TestMethod]
        public void AddAndDisplayNewSubForumTest()
        {
            List<string> moderators = new List<string>();
            moderators.Add("sagiav");
            List<SubForum> FoodSubs = new List<SubForum>();
            SubForum PassoverRecepies = createSubForum("PassoverRecepies", moderators, "Food",3);
            SubForum ChosherRecepies = createSubForum("ChosherRecepies", moderators, "Food",3);
            Food.SubForums.Add("PassoverRecepies", PassoverRecepies);
            Food.SubForums.Add("ChosherRecepies", ChosherRecepies);
            FoodSubs.Add(PassoverRecepies);
            FoodSubs.Add(ChosherRecepies);
            Assert.IsTrue(subForumInForum(FoodSubs, system.searchForum("Food")));
            string listOfSubForum = displaySubforums(Dean, "Food");
            Assert.IsTrue(listOfSubForum.Contains("PassoverRecepies"));
        }

        //[TestMethod]
        //public void CheckSubForumExistsInForumTest()
        //{
        //    List<string> moderators = new List<string>();
        //    moderators.Add("sagiav");
        //    List<SubForum> FoodSubs = new List<SubForum>();
        //    //  SubForum PassoverRecepies = createSubForum("PassoverRecepies", moderators, "Food", 3);
        //    //  SubForum ChosherRecepies = createSubForum("ChosherRecepies", moderators, "Food", 3);
        //    FoodSubs.Add(PassoverRecepies);
        //    FoodSubs.Add(ChosherRecepies);
        //    Assert.IsTrue(subForumInForum(FoodSubs, system.searchForum("Food")));
        //}

        [TestMethod]
        public void AddNewSubForumWithWrongForumNameTest()
        {
            List<string> moderators = new List<string>();
            moderators.Add(base.Sagi1.Username);
            List<SubForum> FoodSubs = new List<SubForum>();
            //      SubForum PassoverRecepies = setUpSubForum("PassoverRecepies", moderators, "Ochel");
            //     FoodSubs.Add(PassoverRecepies);
            Forum f = system.searchForum("Food");
            Assert.IsFalse(subForumInForum(FoodSubs, f));
        }

        [TestMethod]
        public void SubForumAddedOnlyToNeededForumTest()
        {
            List<string> moderators = new List<string>();
            moderators.Add("sagiav");
            List<SubForum> FoodSubs = new List<SubForum>();
            SubForum PassoverRecepies = setUpSubForum("PassoverRecepies", moderators, "Food",3);
            FoodSubs.Add(PassoverRecepies);
            Forum f = system.searchForum("Dating");
            Assert.IsFalse(subForumInForum(FoodSubs, f));
        }

        //[TestMethod]
        //public void nonAdminAddSubForumTest()
        //{
        //    Guest NofarGuest = new Guest();
        //    Register(NofarGuest, "benshnof", "matanShoham", "benshnof@post.bgu.ac.il");
        //    Member Nofar = getMember("benshnof");
        //    Forum currForum = system.enterForum(Nofar, "Food");
        //    AdminForum tempAdminType = new AdminForum();
        //    Assert.IsNotInstanceOfType(Nofar, tempAdminType.GetType());
 
        //    List<string> moderators = new List<string>();
        //    moderators.Add(Nofar.Username);
        //    SubForum ShavuotRecepies = setUpSubForum("ShavuotRecepies", moderators, "Food",3);
        //    tempAdminType.addSubForum(ShavuotRecepies);
        //    Assert.IsFalse(IsSubForumExists("ShavuotRecepies", "Food"));
        //}

        //UC8- view sub forums list
        //UC14- delete message
        [TestMethod]
        public void deleteMessageFormTheOwnerOfTheMessage()
        {
            Member a = new Member("sdf", "cvxcv", "dsf@dff.com");
            Message m = new Message("title", "content", "sdf");
            //continue
        }

        [TestMethod]
        public void addAndDisplayForumTest()
        {
            List<string> admins = new List<string>();
            admins.Add("abadie");
            admins.Add("amitbed");
            Forum Sport = createForum("Dancing", admins);
            Assert.IsNotNull(Sport);
            string listOfForums = displayForum();
            Assert.IsTrue(listOfForums.Contains("Dancing"));
        }

      
    }


}
        //public void addMemberToSystemCheckName(Member member)
        //{
        //    Member IfatMember = CreateMember("ifateli", "gilAd", "ifateli@post.bgu.ac.il");
        //    Assert.IsTrue(String.Equals(IfatMember.Username,"ifateli"));
        //}

        // public void addMemberToSystemCheckPassword(Member member)
        //{
        //    Member IfatMember = CreateMember("ifateli", "gilAd", "ifateli@post.bgu.ac.il");
        //    Assert.IsTrue(String.Equals(IfatMember.Password,"gilAd"));
        //}