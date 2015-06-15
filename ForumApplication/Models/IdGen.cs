using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    class IdGen
    {
        private static long member=0;
        private static long forum=0;
        private static long thread=0;
        private static long subForum = 0;
        private static long message = 0;

        public IdGen()
        {

        }

        public static string generateMessageId()
        {
            IdGen.message++;
            Logger.logDebug(String.Format("New message id has been generated: {0}", IdGen.message));
            return ("message" + IdGen.message);
        }

        public static string generateMemberId(){
            IdGen.member++;
            Logger.logDebug(String.Format("New member id has been generated: {0}", IdGen.member));
            return ("member" + IdGen.member);
        }

        public static string generateForumId()
        {
            IdGen.forum++;
            Logger.logDebug(String.Format("New forum id has been generated: {0}", IdGen.forum));
            return ("forum" + IdGen.forum);
        }

        public static string generateThreadId()
        {
            IdGen.thread++;
            Logger.logDebug(String.Format("New thread id has been generated: {0}", IdGen.thread));
            return ("thread" + IdGen.thread);
        }

        public static string generateSubForumId()
        {
            IdGen.subForum++;
            Logger.logDebug(String.Format("New sub forum id has been generated: {0}", IdGen.subForum));
            return ("subforum" + IdGen.subForum);
        }
    }
}
