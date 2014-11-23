
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace LoginManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LoginManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LoginManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LoginManager.Models.ApplicationDbContext context)
        {

            AddUserAndRole(context);
            context.Contacts.AddOrUpdate(p => p.Name,
       new Contact
       {
           Name = "Rajith Asanka",
           Address = "1234 Main St",
           City = "Dehiwala",
           Email = "pgrasanka@gmail.com",
       },
        new Contact
        {
            Name = "Amila Prasad",
            Address = "5678 1st Ave W",
            City = "Gampaha",
            Email = "amila@example.com",
        },
        new Contact
        {
            Name = "Naween Fonseka",
            Address = "9012 State st",
            City = "Mountlavinia",
            Email = "naween@example.com",
        },
        new Contact
        {
            Name = "Chirath kumarasiri",
            Address = "3456 Maple St",
            City = "Polgasowita",
            Email = "chirath@example.com",
        },
        new Contact
        {
            Name = "Numesh Dilusha",
            Address = "7890 2nd Ave E",
            City = "Tangalle",
            Email = "numesh@example.com",
        }
        );
        }

        bool AddUserAndRole(LoginManager.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "pgrasanka@gmail.com",
            };
            ir = um.Create(user, "#123abcD");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }
    }
}
