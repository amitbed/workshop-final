using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ForumApplication.Models
{
    public static class ConnectionStringExtension
    {
        public static void ChangeDatabaseTo(this DbContext db, string newDatabaseName)
        {
            var conStr = db.Database.Connection.ConnectionString;
            var pattern = "Initial Catalog *= *([^;]*) *";
            var newConStr = Regex.Replace(conStr, pattern, m =>
            {
                return m.Groups.Count == 2
                    ? string.Format("Initial Catalog={0}", newDatabaseName)
                    : m.ToString();
            });
            db.Database.Connection.ConnectionString = newConStr;
        }
    }
}