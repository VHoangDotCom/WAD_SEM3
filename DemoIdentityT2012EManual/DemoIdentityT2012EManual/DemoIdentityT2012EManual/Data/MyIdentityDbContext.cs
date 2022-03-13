using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoIdentityT2012EManual.Data
{
    public class MyIdentityDbContext: IdentityDbContext<Models.Account>
    {
        public MyIdentityDbContext() : base("ConnectionString")
        {

        }
    }
}