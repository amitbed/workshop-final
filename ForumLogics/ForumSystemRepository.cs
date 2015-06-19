using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ForumSystem;

namespace ForumSystem
{
    public class ForumSystemRepository :IQueries
    {
        /*public void dbRetrieveLastID()
        {
            if
            var context = new ForumDBContext();
            
        }*/


        //Forums
        public List<Forum> getForums()
        {
            ForumDBContext fdbc = new ForumDBContext();
            return fdbc.Forums.ToList();
        }

        //Messages
        //public List<Message> dbGetMessages()
        //{
        //var context = new ForumDBContext();
        //var query = from message in context.Messages select message;
        //var messages = query.ToList();
        //return members;
        //}

        public void dbAddMessage(Message message)
        {
            var context = new ForumDBContext();
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public void dbRemoveMessage(string messageID)
        {
            var context = new ForumDBContext();
            var message = (from m in context.Messages
                           where m.ID == messageID
                           select m).FirstOrDefault();
            context.Messages.Remove(message);
            context.SaveChanges();
        }

        //Members
        public List<Member> dbGetMembers()
        {
            var context = new ForumDBContext();
            var query = from member in context.Members select member;
            var members = query.ToList();
            return members;
        }

        public void dbAddMember(Member member)
        {
            var context = new ForumDBContext();
            context.Members.Add(member);
            context.SaveChanges();
        }

        public void dbRemoveMember(string memberID)
        {
            var context = new ForumDBContext();
            var member = (from m in context.Members
                          where m.ID == memberID
                          select m).FirstOrDefault();
            context.Members.Remove(member);
            context.SaveChanges();
        }
    }
}