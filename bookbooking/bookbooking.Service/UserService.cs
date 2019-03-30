using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.User;
using bookbooking.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public interface IUserService
    {
        UserView User(string username);
        Task<ServiceResult> AddUser(UserView model);
        Task<ServiceResult> Login(LoginUserView model);
        void LogOut();
    }
    public class UserService : IUserService
    {
        private UserManager<User> userManager;
        private SignInManager<User> singInManager;
        private IPasswordValidator<User> passwordValidator;
        private IPasswordHasher<User> passwordHasher;
        private RoleManager<IdentityRole> roleManager;
        User user = new User();
        ServiceResult serviceResult = new ServiceResult();
        public UserService(SignInManager<User> _singInManageR, UserManager<User> _userManager, IPasswordHasher<User> _passwordHasher,
            IPasswordValidator<User> _passwordValidator, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            singInManager = _singInManageR;
            passwordHasher = _passwordHasher;
            passwordValidator = _passwordValidator;
            roleManager = _roleManager;
        }
        public UserView User(string username)
        {
            UserView userView = new UserView();
            var item = userManager.Users.Where(w => w.UserName == username).FirstOrDefault();
            userView.Id = item.Id;
            userView.Username = item.UserName;
            userView.Email = item.Email;
            userView.Phone = item.PhoneNumber;
            return userView;
        }
        public async Task<ServiceResult> AddUser(UserView model)
        {
            user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
            user.PhoneNumber = model.Phone;
            user.UserName = model.Username;
            user.Email = model.Email;
            var passValid = await passwordValidator.ValidateAsync(userManager, user, user.PasswordHash);
            if (passValid.Succeeded)
            {
                var result = await userManager.CreateAsync(user);
                  await userManager.AddToRoleAsync(user, "User");
                if (result.Succeeded)
                    serviceResult.Sonuc = true;
                else
                    serviceResult.Sonuc = false;
            }
            return serviceResult;
        }
        public async Task<ServiceResult> Login(LoginUserView model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await singInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                    serviceResult.Sonuc = true;
                else
                    serviceResult.Sonuc = false;
            }
            return serviceResult;
        }
        public void LogOut()
        {
            singInManager.SignOutAsync();
        }
    }
}
