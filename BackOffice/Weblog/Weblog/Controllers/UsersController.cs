using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weblog.Controllers
{
    public class UsersController
    {
        public UsersController()
        {

        }
        public string Index()
        {
            return "list of users";
        }

        [Route("{id}")]
        public string Detail(string id)
        {
            return $"user detail: {id}";
        }


        [HttpPost]
        public string Store()
        {
            return "add new user";
        }

        [HttpPost]
        [Route("{id}")]
        public string Update(string id)
        {
            return $"update user {id}";
        }


        [HttpDelete]
        [Route("{id}")]
        public string Delete(string id)
        {
            return $"delete user {id}";
        }
    }
}
