using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Transactions;

namespace Lisa.Kiwi.WebApi
{
    internal sealed class Configuration : DbMigrationsConfiguration<KiwiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KiwiContext context)
        {
#if !DEBUG
            //Truncates(context);
#endif
            //// Set up our accounts
            CreateRoles(context);
            CreateUsers(context);

            base.Seed(context);
        }

        private void CreateRoles(KiwiContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create our roles
            roleManager.Create(new IdentityRole("Administrator"));
            roleManager.Create(new IdentityRole("DashboardUser"));
            roleManager.Create(new IdentityRole("Anonymous"));
        }

        private void CreateUsers(KiwiContext context)
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            
           // Add a test "beveiliger" account (name=beveiliger pass=hello)

            var dashboardUser = userManager.FindByName("beveiliger");
            
            if (dashboardUser == null)
            {
                dashboardUser = new IdentityUser("beveiliger");
                userManager.Create(dashboardUser, "helloo");
                userManager.AddToRole(dashboardUser.Id, "DashboardUser");
            }
            else if (!userManager.IsInRole(dashboardUser.Id, "DashboardUser"))
            {
                userManager.AddToRole(dashboardUser.Id, "DashboardUser");
            }
            
            // Add a test "hoofdbeveiliger" account (name=hoofdbeveiliger pass=masterpass)

            var administrator = userManager.FindByName("HBD");

            if (administrator == null)
            {
                administrator = new IdentityUser("HBD");
                ThrowIfFailed(userManager.Create(administrator, "masterpass"));
                userManager.AddToRole(administrator.Id, "Administrator"); 
            }
            else if (!userManager.IsInRole(administrator.Id, "Administrator"))
            {
                userManager.AddToRole(administrator.Id, "Administrator"); 
            }
        }

        private void ThrowIfFailed(IdentityResult result)
        {
            if (result.Succeeded)
                return;

            var msg = result.Errors.Aggregate(
                "Failed to create user!",
                (current, error) => current + ("\n" + error));
            throw new Exception(msg);
        }


        private int Truncates(DbContext db, params string[] tables)
        {
            var target = new List<string>();
            var result = 0;

            if (tables == null || tables.Length == 0)
            {
                target = GetTableList(db);
            }
            else
            {
                target.AddRange(tables);
            }

            using (var scope = new TransactionScope())
            {
                foreach (var table in target)
                {
                    result += db.Database.ExecuteSqlCommand(String.Format("DELETE FROM  [{0}]", table));
                    db.Database.ExecuteSqlCommand(String.Format("DBCC CHECKIDENT ([{0}], RESEED, 0)", table));
                }

                scope.Complete();
            }

            return result;
        }

        private List<string> GetTableList(DbContext db)
        {
            return db.GetType().GetProperties()
                .Where(x => x.PropertyType.Name == "DbSet`1")
                .Select(x => x.Name).ToList();
        }
    }
}