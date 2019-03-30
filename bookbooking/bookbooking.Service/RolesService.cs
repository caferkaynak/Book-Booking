using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.Role;
using bookbooking.Common.ViewModels.User;
using bookbooking.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public interface IRolesService
    {
        Task<ServiceResult> AddRole(IdentityRole ıdentityRole);
        Task<IdentityRole> UpdateListRole(string id);
        Task<ServiceResult> DeleteRole(string id);
        Task<ServiceResult> UpdateRole(IdentityRole model);
        Task<UserRoleView> UpdateUserRoleList(string id);
        Task<ServiceResult> UpdateUserRole(UserRoleView model);
    }
    public class RolesService : IRolesService
    {
        private RoleManager<IdentityRole> roleManager;
        ServiceResult serviceResult = new ServiceResult();
        private UserManager<User> userManager;
        public RolesService(RoleManager<IdentityRole> _roleManager, UserManager<User> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }
        public async Task<ServiceResult> AddRole(IdentityRole model)
        {
            ServiceResult serviceResult = new ServiceResult();
            var result = await roleManager.CreateAsync(new IdentityRole(model.Name));
            if (result.Succeeded)
                serviceResult.Sonuc = true;
            return serviceResult;
        }
        public async Task<IdentityRole> UpdateListRole(string id)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole = await roleManager.FindByIdAsync(id);
            return identityRole;
        }
        public async Task<ServiceResult> UpdateRole(IdentityRole model)
        {
            ServiceResult serviceResult = new ServiceResult();
            IdentityRole role = await roleManager.FindByIdAsync(model.Id);
            if (role.Name == "Admin" || role.Name == "User")
            {
                serviceResult.Sonuc = false;
                serviceResult.Message = "Admin veya User'ı Değiştiremezsin";
            }
            else
            {
                role.Name = model.Name;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    serviceResult.Sonuc = true;
                    serviceResult.Message = "Başarılı";
                }
                else
                {
                    serviceResult.Sonuc = false;
                    serviceResult.Message = "Başarısız";
                }
            }
            return serviceResult;
        }
        public async Task<ServiceResult> DeleteRole(string id)
        {
            ServiceResult serviceResult = new ServiceResult();
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role.Name == "Admin" || role.Name == "User")
                serviceResult.Sonuc = false;
            else
            {
                var result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    serviceResult.Sonuc = true;
            }
            return serviceResult;
        }
        public async Task<UserRoleView> UpdateUserRoleList(string id)
        {
            UserRoleView userRoleView = new UserRoleView();
            List<UserView> member = new List<UserView>();
            List<UserView> noMember = new List<UserView>();
            var rol = await roleManager.FindByIdAsync(id);
            foreach (var user in userManager.Users)
            {
                var result = await userManager.IsInRoleAsync(user, rol.Name);
                if (result == true)
                {
                    member.Add(new UserView()
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Email = user.Email,
                        Phone = user.PhoneNumber
                    });
                }
                else
                {
                    noMember.Add(new UserView()
                    {
                        Id = user.Id,
                        Username = user.UserName,
                        Email = user.Email,
                        Phone = user.PhoneNumber
                    });
                }
            }
            userRoleView.Member = member;
            userRoleView.NoMember = noMember;
            userRoleView.ıdentityRoles = roleManager.Roles;
            userRoleView.IdentityRole = rol;
            return userRoleView;
        }
        public async Task<ServiceResult> UpdateUserRole(UserRoleView model)
        {
            if (model.IdsToAdd != null)
            {
                foreach (var userId in model.IdsToAdd)
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await userManager.AddToRoleAsync(user, model.IdentityRole.Name);
                        if (!result.Succeeded)
                        {
                            serviceResult.Message = "Eklendi";
                        }
                    }
                }
            }
            if (model.IdsToDelete != null)
            {
                foreach (var userId in model.IdsToDelete)
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await userManager.RemoveFromRoleAsync(user, model.IdentityRole.Name);
                        if (!result.Succeeded)
                        {
                            serviceResult.Message = "Eklendi";
                        }
                    }
                }
            }
            return serviceResult;
        }
    }
}
