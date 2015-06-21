using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApplication.Models;

namespace ForumTests
{
    interface BridgeProject
    {
        //Forum methods
        string displaySubforums(Member member, string forumName);
        SubForum enterSubForum(Member member, string sfName, string fName);
        SubForum createSubForum(string title, List<string> moderators, string parent, int maxMod);

        //ForumSystem methods
        Forum createForum(string title, List<string> admins);
        Member createMember(string username, string password, string email);
        Member getMember(string userName);
        string displayForums();

        //SubForum methods
        string displayThreads(Member member, string subForumName, string forumName);

        //Member mathods
        void changeSettings(Member member, string username, string password, string email);

        //Admin methods
        void removeSubForum(string sfName, string forumName);
        void addSubForumToForumByAdmin(SubForum sf,string currForum, ModeratorSubForum currMods);


        //Thread methods
        string displayMessages(Member member, string ThreadName, string sfName, string fName);

        //Message methods

        //Guest methods
        void register(Guest g, string username, string password, string email);
        string login(Guest g, string username, string password);

        //Debug methods
        bool IsSubForumExists(string subForumName, string forumName);


    }
}