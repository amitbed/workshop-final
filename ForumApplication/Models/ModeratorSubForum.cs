using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    public class ModeratorSubForum : MemberSubForum, IModeratorManager
    {
        List<string> moderators;
        public ModeratorSubForum(string title, List<string> moderators, string parent, int maxModerators)
            : base(title, moderators, parent, maxModerators)
        {
            this.moderators = moderators;
        }

        public void removeThread(string threadName)
        {
            Thread currThread = Threads[threadName];
            if (currThread != null)
            {
                currThread.delete();
                Threads.Remove(threadName);
            }
        }

    }
}
