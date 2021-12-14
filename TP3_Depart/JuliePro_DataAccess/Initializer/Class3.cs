﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JuliePro_DataAccess.Initializer
//{
//  public class YourDbContextSeedData
//  {
//    private YourDbContext _context;

//    public YourDbContextSeedData(YourDbContext context)
//    {
//      _context = context;
//    }

//    public async void SeedAdminUser()
//    {
//      var user = new ApplicationUser
//      {
//        UserName = "Email@email.com",
//        NormalizedUserName = "email@email.com",
//        Email = "Email@email.com",
//        NormalizedEmail = "email@email.com",
//        EmailConfirmed = true,
//        LockoutEnabled = false,
//        SecurityStamp = Guid.NewGuid().ToString()
//      };

//      var roleStore = new RoleStore<IdentityRole>(_context);

//      if (!_context.Roles.Any(r => r.Name == "admin"))
//      {
//        await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
//      }

//      if (!_context.Users.Any(u => u.UserName == user.UserName))
//      {
//        var password = new PasswordHasher<ApplicationUser>();
//        var hashed = password.HashPassword(user, "password");
//        user.PasswordHash = hashed;
//        var userStore = new UserStore<ApplicationUser>(_context);
//      }
//    }
