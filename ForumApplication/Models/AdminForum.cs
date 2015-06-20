using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    public class AdminForum : Forum, IAdminManager
    {
        Forum parentforum;
        public int MaxModerators { get; set; }

        public AdminForum(Forum forum)
        {
            parentforum = forum;

        }

        public AdminForum()
        {
            // TODO: Complete member initialization
        }

        public void setProperties(int moderatorNumber)
        {
            foreach (SubForum s in parentforum.SubForums.Values)
            {
                s.MaxModerators = moderatorNumber;
            }
        }

        public void addSubForum(SubForum subForum, MemberSubForum memberSubForum, ModeratorSubForum moderatorSubForum)
        {
            if (subForum != null && memberSubForum != null && moderatorSubForum != null)
            {
                //MemberSubForum msf = new MemberSubForum(subForum.Title, subForum.Moderators, this.Title, subForum.MaxModerators);
                //SubForums.Add(subForum.Title, subForum);
                //MemberSubForums.Add(subForum.Title, msf);
                //ModeratorSubForums.Add(subForum.Title, new ModeratorSubForum(msf));

                base.SubForums.Add(subForum.Title ,subForum);
                base.MemberSubForums.Add(memberSubForum.Title, memberSubForum);
                base.ModeratorSubForums.Add(moderatorSubForum.Title, moderatorSubForum);
                Logger.logDebug(string.Format("The new sub forum: {0} has been created successfully with id {1}", subForum.Title, subForum.ID));
            }
            else
            {
                Logger.logError("Failed to add sub forum. Reason: sub forum is null");
            }

        }

       
        public void removeSubForum(string subForumName)
        {
            SubForum currSubForum = SubForums[subForumName];
            if (currSubForum != null)
            {
                currSubForum.delete();
                SubForums.Remove(subForumName);

            }
        }

        public void upgradeMember(string memberID)
        {
            //TODO: add implementation
        }

        public void downgradeMember(string memberID)
        {
            //TODO: add implementation
        }
    }
}
