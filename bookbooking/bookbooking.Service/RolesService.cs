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
    }
    public class RolesService:IRolesService
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
            {
                serviceResult.Sonuc = true;   
            }
            return serviceResult;
        }
    }
}
