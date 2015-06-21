using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace ForumApplication.Models
{
   public class Guest : User, IGuestManager 
    {
        private ForumSystem forumSystem = ForumSystem.initForumSystem();
        public string Username = "guest";
        public string register(string username, string password, string email)
        {
            //approveEmail()
            Member added= forumSystem.addMember(username, password, email);
            return added.Username;
        }

        private bool validateUsername(string username)
        {
           return forumSystem.isUsernameExists(username);
        }

        private bool validateEmail(string email)
        {
            return email.Contains("@");   
        }
        
        private bool approveEmail()
        {
            MailMessage meassage = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            meassage.From = new MailAddress("forumworkshop152@gmail.com");
            meassage.Subject = "Approve this mail in order to register the forum";
            meassage.Body = "please reply this mail with any content in order to complete the registration";
            server.Port = 587;
            server.Credentials = new System.Net.NetworkCredential("forumworkshop152", "nofarifatdeanamitsagi");
            server.EnableSsl = true;
            server.Send(meassage);
            return true;
        }

        public string login(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                Logger.logError("one of the arguments is empty or null");
                return null;
            }
            else
            {
                ForumSystem forumSystem = ForumSystem.initForumSystem();
                if (forumSystem.Members.ContainsKey(username))
                {
                    Member member = forumSystem.Members[username];
                    if (String.Equals(username, member.Username) && String.Equals(password, member.Password))
                    {
                        Logger.logDebug(String.Format("Member: usernamer:{1} has logged in", member.Username));
                        return username;
                    }
                    else
                    {
                        Logger.logDebug(String.Format("Username: {0}, password{1} failed to log in. Reason: member not found", username, password));
                        return null;
                    }
                }
                else return null;
            }
        }
    }
}
