using Microsoft.AspNetCore.Identity;

namespace TeralinktecSmsApps.API.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.SuperUser))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperUser));
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string superUserEmail = "filbert.nicholas93@gmail.com";

                var superUser = await userManager.FindByEmailAsync(superUserEmail);
                if (superUser == null)
                {
                    var newSuperUser = new ApplicationUser()
                    {
                        UserName = superUserEmail,
                        Email = superUserEmail,
                        EmailConfirmed = true,
                        AdminApproval = true
                    };
                    await userManager.CreateAsync(newSuperUser, "P@ssw0rd.123");
                    await userManager.AddToRoleAsync(newSuperUser, UserRoles.SuperUser);
                }
            }
        }
    }
}
