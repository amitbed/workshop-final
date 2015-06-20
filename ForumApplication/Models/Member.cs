﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Models
{
    public class Member : User, IMemeberManager
    {
        [Key]
        public string Username { get; set; }
        public string Email { get; set; }
        private bool isActive;

        public List<string> MyFriends { get; set; }
        public List<string> MyThreads { get; set; }
        public List<string> MySubForums { get; set; }
        public List<string> MyForums { get; set; }

        public long TimeLoggedIn { get; set; }
        public long NumberOfMessages { get; set; }
        public int MemberType { get; set; }
        public int NumOfPublishedMessages { get; set; }
        
        public string Password { get; set; }
        public List<string> oldPasswords { get; set; }
        public Dictionary<string, string> PasswordQuestion { get; set; }

        public Member() { }

        public Member(string username, string password, string emailAddress)
        {
            if ((String.IsNullOrEmpty(username)) || (String.IsNullOrEmpty(password)) || (String.IsNullOrEmpty(emailAddress)))
            {
                if (String.IsNullOrEmpty(username))
                {
                    Logger.logError("Failed to create a new member. Reason: username is empty");
                }
                if (String.IsNullOrEmpty(password))
                {
                    Logger.logError("Failed to create a new member. Reason: password is empty");
                }
                if (String.IsNullOrEmpty(emailAddress))
                {
                    Logger.logError("Failed to create a new member. Reason: email is empty");
                }

            }
            else
            {
                this.Username = username;
                this.Password = password;
                this.Email = emailAddress;
                this.TimeLoggedIn = 0;
                this.isActive = true;
                this.MyForums = new List<string>();
                this.MySubForums = new List<string>();
                this.MyThreads = new List<string>();
                this.MyFriends = new List<string>();
                this.MemberType = (int)Types.Regular;
                this.NumOfPublishedMessages = 0;
                this.oldPasswords = new List<string>();
                this.PasswordQuestion = new Dictionary<string, string>();
                Logger.logDebug(String.Format("A new user has been created. username: {0}, password: {1}, email: {2}", Username, Password, emailAddress));
            }
        }

        

        public void upgrade()
        {
            if (this.MemberType == (int)Types.Regular)
            {
                this.MemberType = (int)Types.Silver;
            }

            else
            {
                if (this.MemberType == (int)Types.Silver)
                {
                    this.MemberType = (int)Types.Gold;
                }
            }
        }

        public void logout()
        {
            this.isActive = false;
            this.TimeLoggedIn += DateTime.Now.Millisecond;
        }

        public bool changePassword(string newPasword)
        {
            bool ans = false;
            this.oldPasswords.Add(this.Password);
            if (!oldPasswords.Contains(newPasword))
            {
                ans = true;
                this.Password = newPasword;
                Logger.logDebug(String.Format("the password for {0} has been changed to: {1}", Username, newPasword));
                return ans;
            }
            else
            {
                Logger.logError(String.Format("the password: {0} has already been used", newPasword));
                return ans;
            }
        }

        public void changeSettings(string nusername, string npassword, string nemail)
        {
            if (nusername != null){
                // Need to add check that this user name is not already exists in DB
                this.Username = nusername;
                Logger.logDebug(String.Format("the username for {0} has been changed to: {1}", Username));
            }
            if (npassword != null)
            {
                changePassword(npassword);
            }
            if (nemail != null)
            {
                this.Email = nemail;
                Logger.logDebug(String.Format("the email for {0} has been changed to: {1}", Email));

            }
        }
    }
}