using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.Models;

namespace ForumTests
{
    class BridgeProxy : BridgeProject
    {
        private BridgeProject real;

        public BridgeProxy()
        {
            this.real = null;
        }

        public BridgeProject setRealBridge(BridgeProject real)
        {
            this.real = real;
            return this.real;
        }

        public Forum createForum(string title, List<string> admins)
        {
            if (this.real != null)
            {
                return (real.createForum(title, admins));
            }
            return null;
        }

        public string login(Guest g, string username, string password)
        {
            if (this.real != null)
            {
                return real.login(g, username, password);
            }
            return null;
        }
        

        public Member createMember(string username, string password, string email)
        {
            if (this.real != null)
            {
                return real.createMember(username, password, email);
            }
            return null;
        }


        public void removeSubForum(string sfName, string forumName)
        {
            if (this.real != null)
            {
                real.removeSubForum(sfName, forumName);
            }
        }


        public void register(Guest g, string username, string password, string email)
        {
            if (this.real != null)
            {
                real.register(g, username, password, email);
            }
        }


        public bool IsSubForumExists(string subForumName, string forumName)
        {
            if (this.real != null)
            {
                return real.IsSubForumExists(subForumName, forumName);
            }
            else return false;
        }


        public void addMemberToSystem(Member member)
        {
            throw new NotImplementedException();
        }


        public Member getMember(string userName)
        {
            if (this.real != null)
            {
                return real.getMember(userName);
            }
            else return null;
        }

        public string displayForums()
        {
            if (this.real != null)
            {
                return real.displayForums();
            }
            else return String.Empty;
        }


        public SubForum createSubForum(string title, List<string> moderators, string parent, int maxMod)
        {
            if (this.real != null)
            {
                return real.createSubForum(title,moderators,parent,maxMod);
            }
            else return null;
        }

        public string displaySubforums(Member member, string forumName)
        {
            if (this.real != null)
            {
                return real.displaySubforums(member,forumName);
            }
            else return null;
        }


        public SubForum enterSubForum(Member member, string sfName, string fName)
        {
            if (this.real != null)
            {
                return real.enterSubForum(member, sfName,fName);
            }
            else return null;
        }

        public string displayThreads(Member member, string subForumName, string fName)
        {
            return real.displayThreads(member, subForumName, fName);
        }

        public void addSubForumToForumByAdmin(SubForum sf, string currForum, ModeratorSubForum currMods)
        {
            real.addSubForumToForumByAdmin(sf, currForum, currMods);
        }

        public string displayMessages(Member member, string threadName, string sfName, string fName)
        {
            return real.displayMessages(member, threadName, sfName, fName);
        }


        public void changeSettings(Member member, string username, string password, string email)
        {
            real.changeSettings(member, username, password, email);
        }
    }
}