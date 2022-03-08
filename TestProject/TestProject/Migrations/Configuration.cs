namespace TestProject.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TestProject.Models.ApplicationDbContext";
        }

        protected override void Seed(TestProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<IdentityRole> users = new List<IdentityRole>
            {
            new IdentityRole{Id = "0" , Name="Admin"},
            new IdentityRole{Id = "1",Name="Employee"},
            new IdentityRole{Id="2",Name="User"},
            
            };

            users.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
        }
    }
}
