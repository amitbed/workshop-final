using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ForumSystem
{
    public class ForumDBContext : DbContext
    {
        //This class interact with the DB behind the scenes
        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<SubForum> SubForums { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }

        public class Initializer : DropCreateDatabaseIfModelChanges<ForumDBContext>
        {
            protected override void Seed(ForumDBContext context)
            {
                //Group root = new Group() { Name = "~" };
                //context.Items.Add(root);

                //Group friends = new Group() { Name = "Friends" };
                //root.AddItem(friends);

                //Person ori = new Person()
                //{
                //    FirstName = "Ori",
                //    LastName = "Calvo"
                //};
                //root.AddItem(ori);
            }
        }
    }
}