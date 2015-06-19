using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    public class Thread
    {
        //Overload Constructor
        public Thread(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                Logger.logError("Failed to create a new thread. Reason: title is empty");
            }
            else
            {
                this.ID = IdGen.generateThreadId();
                this.Title = title;
                this.Messages = new Dictionary<string, Message>();
                Logger.logDebug(String.Format("A new thread has been created. ID: {0}, title: {1}", this.ID, this.Title));
            }
        }

        //Member Variables
        public string ID { get; set; }
        public string Title { get; set; }
        public Dictionary<string, Message> Messages { get; set; }

        //Method
        public string displayMessages()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Message message in Messages.Values)
            {
                sb.Append(message.displayMessage());
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public bool removeMessage(string memberID, string messageID)
        {
            if ((String.IsNullOrEmpty(memberID)) || (String.IsNullOrEmpty(messageID)))
            {
                if ((String.IsNullOrEmpty(memberID)))
                {
                    Logger.logError("Failed to remove a message. Reason: member id is empty");
                }
                if ((String.IsNullOrEmpty(messageID)))
                {
                    Logger.logError("Failed to remove a message. Reason: message id is empty");
                }
                return false;
            }
            else
            {
                foreach (Message m in Messages.Values)
                {
                    if ((m.Equals(messageID)) && (m.UserName.Equals(messageID)))
                    {
                        this.Messages.Remove(m.Title);
                        Logger.logDebug(String.Format("Message has been removed. ID:{0}", m.ID));
                        return true;
                    }
                }
                Logger.logError("Failed to remove a message. Reason: message id not found");
                return false;
            }
        }

        public void delete()
        {
            this.Title = null;
            this.Messages = null;
            Logger.logDebug(String.Format("Thread {0} has been deleted", this.ID));
            this.ID = null;
        }

    }
}
