using System.Threading.Tasks;
using bookbooking.Common.ViewModels;
using bookbooking.Common.ViewModels.User;
using bookbooking.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        ServiceResult serviceResult = new ServiceResult();
        private IRolesService rolesService;
        public RolesController(RoleManager<IdentityRole> _roleManager, IRolesService _rolesService)
        {
            roleManager = _roleManager;
            rolesService = _rolesService;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
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
                await rolesService.UpdateRole(ıdentityRole);
                if (serviceResult.Sonuc == true)
                    return RedirectToAction("Index", "Roles");
                ModelState.AddModelError("Succeeced", "Başarılı");
            }
            return View(ıdentityRole);
        }
        public async Task<IActionResult> Delete(string id)
        {
            serviceResult = await rolesService.DeleteRole(id);
            ModelState.AddModelError("Succeeced", serviceResult.Message);
            return RedirectToAction("Index", "Roles");
        }
    }
}