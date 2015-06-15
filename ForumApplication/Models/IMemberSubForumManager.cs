using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    interface IMemberSubForumManager
    {
        void createThread(Message msg, string threadToAddName);
        void addMessage(Message msg, string relatedThreadName);
        void addReply(Message msgReply, string ParentMsgTopic, string threadName);
        void fileComplaint(string moderatorUsername, string memberUsername);
        void removeMessage(string memberUsername, string threadName, string messageTopic);
        void editMessage(string memberUsername, string msgTopic, string msgContent, string threadName);
    }
}
