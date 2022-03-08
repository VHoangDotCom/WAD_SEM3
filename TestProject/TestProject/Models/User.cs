using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class User:IdentityUser
    {
        public string Cmt { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
    }
}