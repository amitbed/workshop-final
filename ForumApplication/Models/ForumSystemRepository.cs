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
        //public void dbAddSubForum(SubForum subForum, ForumSubforumIntermediate intermediate, bool isProd)
        //{
        //    using (var dbContext = new ForumDBContext())
        //    {
        //        if (!isProd)
        //        {
        //            dbContext.ChangeDatabaseTo("TestForumDBContext");
        //        }
        //        dbContext.SubForums.Add(subForum);
        //        dbContext.forumsToSubForums.Add(intermediate);
        //        dbContext.SaveChanges();
        //    }
        //}

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

        public void cacheMembers(Dictionary<string, Member> dictionary, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var query = from m in dbContext.Members
                            select m;
                foreach (var m in query)
                {
                    dictionary.Add(m.Username, m);
                }
            }
        }
        public void cacheForums(Dictionary<string, Forum> dictionary, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var query = from f in dbContext.Forums
                            select f;
                foreach (var f in query)
                {
                    dictionary.Add(f.ID, f);
                    //cacheSubForums(f.SubForums,f,isProd);
                }
            }
        }
        public void cacheSubForums(Dictionary<string, SubForum> dictionary, string subForumID, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var query = from sf in dbContext.SubForums
                            select sf;
                foreach (var sf in query)
                {
                    dictionary.Add(sf.ID, sf);
                    cacheThreads(sf.Threads, isProd);
                }
            }
        }
        public void cacheThreads(Dictionary<string, Thread> dictionary, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var query = from t in dbContext.Threads
                            select t;
                foreach (var t in query)
                {
                    dictionary.Add(t.ID, t);
                }
            }
        }
        public void cacheMessages(Dictionary<string, Message> dictionary, bool isProd)
        {
            using (var dbContext = new ForumDBContext())
            {
                if (!isProd)
                {
                    dbContext.ChangeDatabaseTo("TestForumDBContext");
                }
                var query = from m in dbContext.Messages
                            select m;
                foreach (var m in query)
                {
                    dictionary.Add(m.ID, m);
                }
            }
        }
    }
}