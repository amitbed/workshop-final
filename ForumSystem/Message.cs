using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    public class Message
    {
        //Variables
        public string ID { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public List<Message> Replies { get; set; }

        //Overload Contructor
        public Message(string title, string content, string userName)
        {
            if ((String.IsNullOrEmpty(content)) || (String.IsNullOrEmpty(userName)))
            {
                if (String.IsNullOrEmpty(content))
                {
                    Logger.logError("Failed to create a new message. Reason: content is empty");
                }

                if (String.IsNullOrEmpty(userName))
                {
                    Logger.logError("Failed to create a new message. Reason: ID is empty");
                }
            }
            else
            {
                this.ID = IdGen.generateMessageId();
                this.Title = title;
                this.Content = content;
                this.Date = DateTime.Now;
                this.UserName = userName;
                this.Replies = new List<Message>();
            }
        }

        //Methods

        //This method displays the message
        public string displayMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Message Id: " + this.ID);
            sb.Append("Message Date: " + Date);
            sb.Append("Message Content: " + Content);
            sb.AppendLine();
            return sb.ToString();
        }

        public void postReply(Message reply, string replierID)
        {

            if (reply != null)
            {
                Replies.Add(reply);
                Logger.logDebug(string.Format("The new reply: {0} has been created successfully with id {1}", reply.Title, reply.ID));
            }
            else
            {
                Logger.logError("Failed to add reply. Reason: reply is null");
            }
        }

        public void delete()
        {
            this.ID = null;
            this.Title = null;
            this.Content = null;
            this.UserName = null;
            this.Replies = null;

        }
    }
}
