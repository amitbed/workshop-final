using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    interface IAdminManager
    {
        void setProperties(int moderatorNumber);
        void addSubForum(SubForum subForum, MemberSubForum memberSubForum, ModeratorSubForum moderatorSubForum);
        void removeSubForum(string subForumName);
        void upgradeMember(string memberID);
        void downgradeMember(string memberID);


    }
}
