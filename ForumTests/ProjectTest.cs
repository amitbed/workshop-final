using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ForumApplication.Models;

namespace ForumTests
{
    [TestClass]
    public class ProjectTest
    {
        private BridgeProject bridge = Driver.getBridge();
        protected ForumSystem system = ForumSystem.initForumSystem();
        List<Member> testMembers = new List<Member>();
        protected Member Sagi1;
        protected Member Amit1;
        protected Member Dean1;
        public virtual void SetUp()
        {
            setUpMembers();
            setUpForum();
        }

        private void setUpMembers()
        {
            Sagi1 = bridge.createMember("sagiav1", "maihayafa", "sagiav@post.bgu.ac.il");
            Amit1 = bridge.createMember("amitbed1", "ronahayafa", "amitbed@post.bgu.ac.il");
            Dean1 = bridge.createMember("abadie1", "liatush", "abadie.post@post.bgu.ac.il");
            testMembers.Add(Sagi1);
            testMembers.Add(Amit1);
            testMembers.Add(Dean1);
        }

        private void setUpForum()
        {
            List<string> adminDating = new List<string>();
            adminDating.Add(Sagi1.Username);
            List<string> adminFood = new List<string>();
            adminFood.Add(Amit1.Username);
            Forum Dating = bridge.createForum("Dating", adminDating);
            Forum Food = bridge.createForum("Food", adminFood);
        }

        public Forum createForum(string title, List<string> admins)
        {
            return bridge.createForum(title, admins);
        }

        public SubForum createSubForum(string title, List<string> moderators, string parent, int maxMod)
        {
            return bridge.createSubForum(title, moderators, parent, maxMod);
        }

        public Forum searchForum(string forumName)
        {
            return system.searchForum(forumName);
        }
        
        public SubForum setUpSubForum(string title, List<string> moderators, string parent, int maxModerators)
        {
            return bridge.createSubForum(title, moderators, parent, maxModerators);
        }
        
        public void Register(Guest g, string username, string password, string email)
        {
            bridge.register(g, username, password, email);
        }

        public void removeSubForum(string sfName, string forumName)
        {
            bridge.removeSubForum(sfName, forumName);
        }

        public string login(Guest g, string username, string password)
        {
            return bridge.login(g, username, password);
        }

        public bool isMemberExist(string username)
        {
            return system.isUsernameExists(username);
        }
        public Member CreateMember(string username, string password, string email)
        {
            return bridge.createMember(username, password, email);
        }

        public bool subForumInForum(List<SubForum> subForums, Forum forum)
        {
            bool ans = true;
            Dictionary<string, SubForum> listToCheck = forum.SubForums;
            foreach (SubForum sub in subForums)
            {
                if (!listToCheck.ContainsKey(sub.Title)) //Contains(sub))
                    ans = false;
            }

            return ans;
        }

        public bool IsSubForumExists(string subForumName, string forumName)
        {
            return IsSubForumExists(subForumName, forumName);
        }

        public bool isGuestRegistered(string guestName)
        {
            bool ans = false;
            foreach (Member m in system.Members.Values)
            {
                if (m.Username == guestName)
                {
                    ans = true;
                }
            }
            return ans;
        }

        public Member getMember(string memberUsername)
        {
            return bridge.getMember(memberUsername);
        }

        public string displayForum()
        {
            return bridge.displayForums();
        }

        public string displaySubforums(Member member, string forumName)
        {
            return bridge.displaySubforums(member,forumName);
        }

        public SubForum enterSubForum(Member member,string sfName, string fName)
        {
            return bridge.enterSubForum(member,sfName,fName);
        }

        public string displayThreads(Member member, string subForumName, string forumName)
        {
            return bridge.displayThreads(member, subForumName, forumName);
        }

        public void addSubForumToForumByAdmin(SubForum sf, string currForum, ModeratorSubForum currMods)
        {
            bridge.addSubForumToForumByAdmin(sf,currForum,currMods);
        }

        public string displayMessages(Member member, string ThreadName, string sfName, string fName)
        {
            return bridge.displayMessages(member, ThreadName,sfName,fName);
        }

        public void changeSettings(Member member, string username, string password, string email)
        {
            bridge.changeSettings(member,username, password, email);
        }

    }
}
