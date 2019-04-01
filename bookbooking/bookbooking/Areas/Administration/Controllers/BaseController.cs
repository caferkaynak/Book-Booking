using System.Linq;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace bookbooking.Web.Areas.Administration.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        public ICategoryService categoryService { get { return HttpContext.RequestServices?.GetService<ICategoryService>(); } }
        public IUserService userService { get { return HttpContext.RequestServices?.GetService<IUserService>(); } }
        public ILibraryService libraryService { get { return HttpContext.RequestServices?.GetService<ILibraryService>(); } }
        public IRolesService rolesService { get { return HttpContext.RequestServices?.GetService<IRolesService>(); } }
        public ICardService cardService { get { return HttpContext.RequestServices?.GetService<ICardService>(); } }
        public SignInManager<User> singInManageR { get { return HttpContext.RequestServices?.GetService<SignInManager<User>>(); } }
        public UserManager<User> userManager { get { return HttpContext.RequestServices?.GetService<UserManager<User>>(); } }
        public IPasswordHasher<User> passwordHasher { get { return HttpContext.RequestServices?.GetService<IPasswordHasher<User>>(); } }
        public IPasswordValidator<User> passwordValidator { get { return HttpContext.RequestServices?.GetService<IPasswordValidator<User>>(); } }
        public RoleManager<IdentityRole> rolesManager { get { return HttpContext.RequestServices?.GetService<RoleManager<IdentityRole>>(); } }
        public BaseController()
        {

        }
        public void doldur()
        {
            TempData["Category"] = categoryService.CategoryList().Categories.ToList();
            TempData["Author"] = libraryService.BookList().Authors.ToList();
            if (User.Identity.IsAuthenticated == true)
            {
                TempData["UserPhone"] = userService.User(User.Identity.Name).Phone;
                TempData["UserName"] = userService.User(User.Identity.Name).Username;
                TempData["UserEmail"] = userService.User(User.Identity.Name).Email;
            }
        }
    }
}