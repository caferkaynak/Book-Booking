using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.User;
using bookbooking.Data;
using bookbooking.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public interface IUserService
    {
        UserView ListUser(string username);
        Task<ServiceResult> AddUser(UserView model);
        Task<ServiceResult> Login(LoginUserView model);
        void LogOut();
    }
        public class UserService:IUserService
    {
        private UserManager<User> userManager;
        private SignInManager<User> singInManager;
        private IPasswordValidator<User> passwordValidator;
        private IPasswordHasher<User> passwordHasher;
        User user = new User();
        ServiceResult serviceResult = new ServiceResult();
        public UserService(SignInManager<User> _singInManageR, UserManager<User> _userManager, IPasswordHasher<User> _passwordHasher,
            IPasswordValidator<User> _passwordValidator)
        {
            userManager = _userManager;
            singInManager = _singInManageR;
            passwordHasher = _passwordHasher;
            passwordValidator = _passwordValidator;
        }
        public UserView ListUser(string username)
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
                if (result.Succeeded)
                    serviceResult.sonuc = true;
                else
                    serviceResult.sonuc = false;
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
                    serviceResult.sonuc = true;
                else
                    serviceResult.sonuc = false;
            }
            return serviceResult;
        }
        public void LogOut()
        {
            singInManager.SignOutAsync();
        }
    }
}
