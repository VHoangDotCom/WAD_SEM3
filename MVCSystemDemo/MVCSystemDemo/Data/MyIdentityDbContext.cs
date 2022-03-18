using Microsoft.AspNet.Identity.EntityFramework;
using MVCSystemDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSystemDemo.Data
{
    public class MyIdentityDbContext : IdentityDbContext<Models.Account>
    {
        public MyIdentityDbContext() : base("MyIdentityDbContext")
        {

        }
        public IdentityDbContext<Account> Accounts { get; set; }
    }
}