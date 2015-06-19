using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    public class Forum
    {
        #region variables
        public string ID { get; set; }
        public string Title { get; set; }
        public Dictionary<string, SubForum> SubForums { get; set; }
        public Dictionary<string, MemberSubForum> MemberSubForums { get; set; }
        public Dictionary<string, ModeratorSubForum> ModeratorSubForums { get; set; }
        public List<string> Admins { get; set; }

        #endregion

        #region Ctor
        public Forum() { }
        public Forum(string title, List<string> admins)
        {
            this.ID = IdGen.generateForumId();
            this.SubForums = new Dictionary<string, SubForum>();
            this.Title = title;
            this.Admins = admins;
            if ((admins == null) || (String.IsNullOrEmpty(title)))
            {
                if ((String.IsNullOrEmpty(title)) && (!(admins == null)))
                {
                    Logger.logError(string.Format("Failed to create a new forum. Reason: title is empty"));
                }
                if ((!String.IsNullOrEmpty(title)) && (admins == null))
                {
                    Logger.logError(string.Format("Failed to create a new forum. Reason: admins is null"));
                }
            }
            else
            {
                Logger.logDebug(string.Format("The new forum: {0} has been created successfully with id {1}", title, ID));
            }
        }
        #endregion

        #region Methods

        //create subforum and assign to the cuurent forum
        public SubForum createSubForum(string title, List<string> moderators, string parent, int maxModerators)
        {
            SubForum sf = new SubForum(title, moderators, parent, maxModerators);
            SubForums.Add(title, sf);
            return sf;
        }

        //This method displays a forum's sub forums
        public string displaySubforums()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string subForumTitle in SubForums.Keys)
            {
                sb.Append(subForumTitle);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        //This method adds a sub-forum to the current forum


        public SubForum SearchSubForum(string sfName)
        {
            if (SubForums.ContainsKey(sfName))
            {
                return SubForums[sfName];
            }
            else return null;
        }

        public SubForum enterSubForum(string subForumName, User user)
        {
            ForumSystem forumSystem = ForumSystem.initForumSystem();
            SubForum subForumToEnter = null;
            if (SubForums.ContainsKey(subForumName))
            {
                subForumToEnter = this.SubForums[subForumName];
                if (subForumToEnter == null)
                {
                    Logger.logError(String.Format("Failed to recieve sub forum {0}", subForumName));
                    return null;
                }
                else
                {
                    if (user.GetType().Name.Equals("Member"))
                    {
                        Member newUser = (Member)user;
                        if (subForumToEnter.Moderators.Contains(newUser.Username))
                        {
                            Logger.logDebug(String.Format("{0} enterd to sub forum {1} as moderator", this.ID, subForumName));
                            return ModeratorSubForums[subForumName];
                        }
                        else
                        {
                            Logger.logDebug(String.Format("{0} enterd to sub forum {1} as member", this.ID, subForumName));
                            return MemberSubForums[subForumName];
                        }
                    }
                    else
                    {
                        Logger.logDebug(String.Format("{0} enterd to sub forum {1} as guest", this.ID, subForumName));
                        return subForumToEnter;
                    }
                }
            }
            return null;
        }
    }
        #endregion
}
