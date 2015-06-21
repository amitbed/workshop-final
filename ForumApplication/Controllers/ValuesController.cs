using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ForumApplication.Models;
namespace ForumApplication.Controllers
{
    public class ValuesController : ApiController
    {
        ForumSystem fs;
        // GET api/values
        public IEnumerable<string> Get()
        {
            fs = ForumSystem.initForumSystem();
            
            string[] s = new string[100];
            int i = 0;
            foreach (Member m in fs.Members.Values)
            {
                s[i] = "Username: " + m.Username + " Password: " + m.Password + " Email: " + m.Email;
                i=i+1;
            }
            return s;
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
