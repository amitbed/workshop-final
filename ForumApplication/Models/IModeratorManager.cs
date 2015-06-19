using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    interface IModeratorManager
    {
        void removeThread(string threadName);
    }
}
