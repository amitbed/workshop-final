using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ForumApplication.Models
{
    public class ForumSystemRepository //:IQueries
    {
        public ForumSystemRepository()
        {
            //var context = new ForumDBContext();
            //string username = "dean";
            //var context = new ForumDBContext();
            //var query = from mem in context.Members where mem.Username == username select mem;
            //var member = query.FirstOrDefault();
        }

        public ForumSystemRepository(string connectionString)
        {
            var db = new ForumDBContext();
            string username = "dean";
            // Uses it just before any other execution.
            db.ChangeDatabaseTo(connectionString);
            var query = from mem in db.Members where mem.Username == username select mem;
            var member = query.FirstOrDefault();
        }
        
        /*public void dbRetrieveLastID()
        {
            if
            var context = new ForumDBContext();
            
        }*/


        //Forums
        //public List<Forum> getForums()
        //{
        //    ForumDBContext fdbc = new ForumDBContext();
        //    return fdbc.Forums.ToList();
        //}

        //Messages
        //public List<Message> dbGetMessages()
        //{
        //var context = new ForumDBContext();
        //var query = from message in context.Messages select message;
        //var messages = query.ToList();
        //return members;
        //}

        public void dbAddMessage(Message message, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                dbContext.Messages.Add(message);
                dbContext.SaveChanges();
            }
        }

        public void dbRemoveMessage(string messageID, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var message = (from m in dbContext.Messages
                              where m.ID == messageID
                              select m).FirstOrDefault();
                dbContext.Messages.Remove(message);
                dbContext.SaveChanges();
            }
        }

        public bool dbIsMemberExists(string username)
        {
            var context = new ForumDBContext();
            var query = from mem in context.Members where mem.Username == username select mem;
            var member = query.FirstOrDefault();
            return (member != null);
        }

        public void dbAddMember(Member member, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                dbContext.Members.Add(member);
                dbContext.SaveChanges();
            }
        }

        public void dbRemoveMember(string username, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var member = (from m in dbContext.Members
                              where m.Username == username
                              select m).FirstOrDefault();
                dbContext.Members.Remove(member);
                dbContext.SaveChanges();
            }
        }

        //FIX
        public void dbAddForum(Forum forum, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                dbContext.Forums.Add(forum);
                dbContext.SaveChanges();
            }
        }

        //TO DO
        public void dbRemoveForum(string forumID, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var forum = (from f in dbContext.Forums
                              where f.ID == forumID
                              select f).FirstOrDefault();
                dbContext.Forums.Remove(forum);
                dbContext.SaveChanges();
            }
        }

        //FIX
        public void dbAddSubForum(SubForum subForum, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                dbContext.SubForums.Add(subForum);
                dbContext.SaveChanges();
            }
        }

        //TO DO
        public void dbRemoveSubForum(string subForumID, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var subForum = (from sf in dbContext.SubForums
                             where sf.ID == subForumID
                             select sf).FirstOrDefault();
                dbContext.SubForums.Remove(subForum);
                dbContext.SaveChanges();
            }
        }
    }
}