using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.User;
using bookbooking.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bookbooking.Service
{
    public interface IRolesService
    {
        Task<ServiceResult> AddRole(IdentityRole ıdentityRole);
        Task<IdentityRole> UpdateListRole(string id);
        Task<ServiceResult> DeleteRole(string id);
        Task<ServiceResult> UpdateRole(IdentityRole model);
    }
    public class RolesService : IRolesService
    {
        private RoleManager<IdentityRole> roleManager;
        ServiceResult serviceResult = new ServiceResult();
        public RolesService(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
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
    }
}
