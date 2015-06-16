using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ForumApplication.Models
{
    public class ForumSystem
    {
        private static ForumSystem forumSystem = null;
        public Dictionary<string, Forum> Forums { get; set; }
        public Dictionary<string, Forum> AdminsForums { get; set; }
        public Dictionary<string, Member> Members { get; set; }
        public Regex PassLimitation { get; set; }
        private long TimeToUpgrade { get; set; }
        private long MessagesToUpgrade { get; set; }
        private ForumSystemRepository repository;

        //Constructor
        private ForumSystem()
        {
            bool isProd = false;
            Logger log = new Logger();
            Members = new Dictionary<string, Member>();
            Forums = new Dictionary<string, Forum>();
            AdminsForums = new Dictionary<string, Forum>();
            Logger.logDebug(string.Format("A new forum system has been created"));
            var DailyTime = "00:00:00";
            var timeParts = DailyTime.Split(new char[1] { ';' });
        /*    using (var db = new ForumDBContext())
            {
                ForumSystemRepository repository = new ForumSystemRepository();
                Member member = new Member("username", "password", "email@email.com");
                repository.dbAddMember(member);
                repository.dbRemoveMember("member1");
            }*/
            //Member member = new Member("username", "password", "email@email.com");
            //Member member2 = new Member("username2", "password", "email2@email.com");
            //Member member3 = new Member("username3", "password", "email3@email.com");
            //Message message = new Message("Message1", "test", "userName1");
            //Message message2 = new Message("Message2", "test", "userName1");
            //List<string> admins = new List<string>();
            //admins.Add("username");
            //admins.Add("username2");
            //Forum forum = new Forum("Sports", admins);
            //repository = new ForumSystemRepository();
<<<<<<< HEAD
            ////testRepository = new ForumSystemRepository("TestForumDBContext");
            ////repository.dbAddMember(member,false);
            ////repository.dbAddMember(member2,false);
            ////repository.dbRemoveMember("username",isProd);
            ////repository.dbAddMessage(message, isProd);
            ////repository.dbAddMessage(message2,isProd);
            ////repository.dbRemoveMessage("message1", isProd);
            ////repository.dbAddForum(forum,false);
=======
            //testRepository = new ForumSystemRepository("TestForumDBContext");
            //repository.dbAddMember(member,false);
            //repository.dbAddMember(member2,false);
            //repository.dbRemoveMember("username",isProd);
            //repository.dbAddMessage(message, isProd);
            //repository.dbAddMessage(message2,isProd);
            //repository.dbRemoveMessage("message1", isProd);
            //repository.dbAddForum(forum,false);
>>>>>>> origin/master
            //repository.dbAddMember(member3, true);
            //repository.dbIsMemberExists("ggg");
        }


        //Methods
        public static ForumSystem initForumSystem()
        {
            if (forumSystem == null)
            {
                forumSystem = new ForumSystem();
                //hread checkMembers = new Thread(checkMembersForUpgrade);
                //checkMembers.Start();
                Guest superGuest = new Guest(); // check if its neccessary
            }
            return forumSystem;
        }


        //This method adds a forum to the main forum system
        public void createForum(Forum forum)
        {
            if (forum == null)
            {
                Logger.logError("Failed to add a new forum. Reason: forum is null");
            }
            else
            {
                Forums.Add(forum.Title, forum);
                AdminsForums.Add(forum.Title, new AdminForum(forum));
                Logger.logDebug(String.Format("A new forum has been added to forum system. ID: {0}, Title: {1}", forum.ID, forum.Title));
            }
        }

        public void checkMembersForUpgrade()
        {
            while (true)
            {
                double c = DateTime.Now.TimeOfDay.TotalHours;
                if ((int)c == 0)
                {
                    foreach (Member m in Members.Values)
                    {
                        if ((m.TimeLoggedIn > this.TimeToUpgrade) && (m.NumberOfMessages > this.MessagesToUpgrade))
                        {
                            m.upgrade();
                        }
                    }
                }
            }
        }

        //This method displays all the forums in the system
        public List<string> displayForums()
        {
            List<string> forums = new List<string>();
            foreach (string forumName in Forums.Keys)
            {
                forums.Add(forumName);
            }
            return forums;
        }

        public Member addMember(string username, string password, string email)
        {
            if ((String.IsNullOrEmpty(username)) || (String.IsNullOrEmpty(password)) || (String.IsNullOrEmpty(email)))
            {
                if (String.IsNullOrEmpty(username))
                {
                    Logger.logError("Filed to add a new member. Reason: username is null");
                }
                if (String.IsNullOrEmpty(password))
                {
                    Logger.logError("Filed to add a new member. Reason: password is null");
                }
                if (String.IsNullOrEmpty(email))
                {
                    Logger.logError("Filed to add a new member. Reason: email is null");
                }
                return null;
            }
            else
            {
                Member toAdd = new Member(username, password, email);
                if (Members.ContainsKey(username))
                {
                    Logger.logDebug(String.Format("A Member with the same user name alredy exist"));
                    return Members[username];
                }
                else
                {
                  //  repository.dbAddMember(toAdd);
                  //  Members.Add(toAdd.Username, toAdd);
                    Logger.logDebug(String.Format("A new member has been added. username: {0}, password: {1}, email: {2}", toAdd.Username, password, email));
                    return toAdd;
                }
            }
        }

        public bool isUsernameExists(string newUsername)
        {
            foreach (Member m in Members.Values)
            {
                if (m.Username.Equals(newUsername))
                    return true;
            }
            return false;
        }

        public Forum searchForum(string forumName)
        {
            //string forumID = getForumIdByName(forumName);
            if (Forums.ContainsKey(forumName))
            {
                return (Forums[forumName]);
            }
            else return null;
        }

        public Forum enterForum(Guest guest, string forumName)
        {
            if (Forums.ContainsKey(forumName))
            {
                Forum forumToEnter = Forums[forumName];
                if (forumToEnter == null)
                {
                    Logger.logError(String.Format("Failed to recieve forum {0}", forumName));
                    return null;
                }
                else
                {
                    return Forums[forumName];
                }
            }
            else
            {
                return null;
            }
        }

        public Forum enterForum(Member member, string forumName)
        {

            if (Forums.ContainsKey(forumName))
            {
                Forum forumToEnter = Forums[forumName];
                if (forumToEnter == null)
                {
                    Logger.logError(String.Format("Failed to recieve forum {0}", forumName));
                    return null;
                }
                else
                {
                    if (member.MyForums.Contains(forumToEnter.ID))
                    {
                        Logger.logDebug(String.Format("{0} enterd to forum {1} as Admin", member.Username, forumName));
                        return forumSystem.AdminsForums[forumName];
                    }
                    else
                    {
                        Logger.logDebug(String.Format("{0} enterd to forum {1} as guest", member.Username, forumName));
                        return forumToEnter;
                    }
                }
            }
            else return null;
        }
    }
}