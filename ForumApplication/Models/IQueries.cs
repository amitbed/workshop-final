using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ForumApplication.Models
{
    interface IQueries
    {
        //Forums
        //Dictionary<string, Forum> dbGetForums();
        //void dbAddForum(Forum forum);
        //void dbRemoveForum(string forumID);
        //bool searchForum(forumName);

        //Sub forums
        //Dictionary<string, SubForum> dbGetSubForum();
        //void dbAddSubForum(SubForum subForum);
        //void dbRemoveSubForum(string subForumID);
        //bool searchSubForum(subForumName);

        //Threads
        //Dictionary<string, Thread> dbGetThreads();
        //void dbAddThread(Thread thread);
        //void dbRemoveThread(string ThreadID); 
        //bool searchThread(ThreadName);

        //Messages
        //Dictionary<string, Message> dbGetMessages();
        void dbAddMessage(Message message);
        void dbRemoveMessage(string messageID);
        //bool searchMessage(topic,date,username);

        //Members
        //Dictionary<string, Member> dbGetMembers();              //This query retrieves all members from the DB
        void dbAddMember(Member member);                        //This query adds a new member to the DB
        void dbRemoveMember(string MemberID);                   //This query removes a member from the DB
        bool dbIsMemberExists(string username);                 //returns true is username exists in DB
    }
}
