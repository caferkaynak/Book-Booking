using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
namespace bookbooking.Data
{
    public class SeedData
    {
        public SeedData(RoleManager<IdentityRole> _roleManager)
        {

        }
        public async static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            var roleadminresult = await roleManager.FindByNameAsync("Admin");
            var roleuserresult = await roleManager.FindByNameAsync("User");
            if (roleadminresult == null)
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (roleuserresult == null)
                await roleManager.CreateAsync(new IdentityRole("User"));
        }
    }
}
