using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class SubForum
    {
        #region variables
        public string ID { get; set; }
        public string Title { get; set; }
        public Dictionary<string, Thread> Threads { get; set; }
        public List<string> Moderators { get; set; }
        public int MaxModerators { get; set; }
        private List<Member> members;

        #endregion

        public SubForum() { }
        //Overload Constructor
        public SubForum(string title, List<string> moderators, string parent, int maxModerators)
        {
            if ((String.IsNullOrEmpty(title)) || (String.IsNullOrEmpty(parent)) || (moderators == null))
            {
                if (String.IsNullOrEmpty(title))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: title is empty");
                } 

                if (String.IsNullOrEmpty(parent))
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: parent is empty");
                }
                if (moderators == null)
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: moderators is null");
                }
            }
            else
            {
                if (moderators.Count <= maxModerators)
                {
                    this.ID = IdGen.generateSubForumId();
                    this.Threads = new Dictionary<string, Thread>();
                    this.Title = title;
                    this.MaxModerators = maxModerators + (getParentForum(parent)).Admins.Count;
                    this.Moderators = moderators;
                    Moderators.Concat((getParentForum(parent)).Admins);
                    this.members = new List<Member>();
                    Logger.logDebug(String.Format("A new sub-forum has been created. ID: {0}, title: {1}", this.ID, this.Title));
                }
                else
                {
                    Logger.logError("Failed to create a new sub-forum. Reason: too many moderators");
                }
            }
        }


        //Methods

        public Forum getParentForum(string parentName)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            return forumSystem.Forums[parentName];
        }

        //This method displays a sub-forum's threads
        public string displayThreads()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string threadID in Threads.Keys)
            {
                sb.Append(threadID + ". " + Threads[threadID].Title);
                sb.AppendLine();
            }
            string ans = sb.ToString();
            Logger.logDebug(String.Format("displayThreads ", ans));
            return ans;
        }

        public Thread SearchThread(string threadName)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            Thread threadToFind = Threads[threadName];
            if (threadToFind == null)
            {
                Logger.logError(String.Format("Failed to recieve thread {0}", threadName));
                return null;
            }
            else
            {
                Logger.logDebug(String.Format("find thread {1} ", threadName));
                return threadToFind;
            }
        }

        public void delete()
        {
            this.Threads = new Dictionary<string, Thread>();
            this.Title = null;
            this.Moderators = null;
            this.members = new List<Member>();
            Logger.logDebug(String.Format("subForum: {0} has been deleted", this.ID));
            this.ID = null;
        }
    }
}
