using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem
{
    interface IGuestManager
    {
        string register(string username, string password, string email);
        string login(string username, string password);
    }
}
