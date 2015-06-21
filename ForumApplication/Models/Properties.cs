using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumApplication.Models
{
    public class Properties
    {
        int PasswordNumOfChar;
        int maxModerators;
        List<char> charsForPassword;

        public Properties(int PasswordNumOfChar, int maxModerators, List<char> charsForPassword)
        {
            this.PasswordNumOfChar = PasswordNumOfChar;
            this.maxModerators = maxModerators;
            this.charsForPassword = charsForPassword;
        }
    }
}