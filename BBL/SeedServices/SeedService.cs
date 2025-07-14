using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project1.Models;

namespace Project1.SeedServices
{
    public  class SeedService
    {
       
        public async static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>(); 
            var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>(); 
            var roleManager = scope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
            try
            {
                //ensuring whether database is created or not

                await context!.Database.EnsureCreatedAsync();

                // adding roles
                await AddRoleAsync(roleManager!, "Admin");
                await AddRoleAsync(roleManager!, "User");

                // 
                var AdminEmail = "admin@gmail.com";
                if (await userManager!.FindByEmailAsync(AdminEmail) == null)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = AdminEmail,
                        Email = AdminEmail,
                        NormalizedEmail = AdminEmail.ToUpper(),
                        NormalizedUserName = AdminEmail.ToUpper(),
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    var result = await userManager.CreateAsync(user);
                    if (!result.Succeeded)
                    {
                        throw new Exception("failed to create admin role");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        public static async Task AddRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
{
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        var role = new ApplicationRole
        {
            Name = roleName,
            NormalizedName = roleName.ToUpper()
        };

        var result = await roleManager.CreateAsync(role);
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to create role {roleName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}
    }
}
