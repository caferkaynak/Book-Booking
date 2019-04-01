using System.Threading.Tasks;
using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.Role;
using bookbooking.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Admin")]
    public class RolesController : BaseController<RolesController>
    {
        ServiceResult serviceResult = new ServiceResult();
        public IActionResult Index()
        {
            return View(rolesManager.Roles);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(IdentityRole ıdentityRole)
        {
            if (ModelState.IsValid)
            {
                serviceResult = await rolesService.AddRole(ıdentityRole);
                if (serviceResult.Sonuc == true)
                {
                    ModelState.AddModelError("Succeeced", "Başarılı");
                }
            }
            return View();
        }
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole ıdentityRole = new IdentityRole();
            ıdentityRole = await rolesService.UpdateListRole(id);
            return View(ıdentityRole);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole ıdentityRole)
        {
            if (ModelState.IsValid)
            {
                serviceResult = await rolesService.UpdateRole(ıdentityRole);
                ModelState.AddModelError("Succeeced", serviceResult.Message);
                return View(ıdentityRole);
            }
            return View(ıdentityRole);
        }
        public async Task<IActionResult> Delete(string id)
        {
            serviceResult = await rolesService.DeleteRole(id);
            if (serviceResult.Sonuc == true)
                ModelState.AddModelError("Succeeced", "Başarılı");
            else
                ModelState.AddModelError("Succeeced", "Admin veya User'ı silemezsiniz");
            return RedirectToAction("Index", "Roles");
        }
        public async Task<IActionResult> UpdateUserRole(string id)
        {
            UserRoleView userRoleView = new UserRoleView();
            userRoleView = await rolesService.UpdateUserRoleList(id);
            return View(userRoleView);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(UserRoleView userRoleView)
        {
            if (ModelState.IsValid)
            {
               serviceResult = await rolesService.UpdateUserRole(userRoleView); 
            }
            ModelState.AddModelError("Hata", "Seçim yapılmadı");
            userRoleView = await rolesService.UpdateUserRoleList(userRoleView.IdentityRole.Id);
            return View(userRoleView);
        }
    }
}