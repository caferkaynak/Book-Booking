using System.Linq;
using bookbooking.Common.ViewModels;
using bookbooking.Entity.Entities;
using bookbooking.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
namespace bookbooking.Web.Areas.Administration.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private SignInManager<User> _singInManageR;
        private UserManager<User> _userManager;
        private IPasswordHasher<User> _passwordHasher;
        private IPasswordValidator<User> _passwordValidator;
        private RoleManager<IdentityRole> _rolesManager;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private ILibraryService _libraryService;
        private IRolesService _rolesService;
        private ICardService _cardService;
        private ServiceResult _ServiceResult;

        public SignInManager<User> singInManageR => _singInManageR ?? (_singInManageR = HttpContext?.RequestServices.GetService<SignInManager<User>>());
        public UserManager<User> userManager => _userManager ?? (_userManager = HttpContext?.RequestServices.GetService<UserManager<User>>());
        public IPasswordHasher<User> passwordHasher => _passwordHasher ?? (_passwordHasher = HttpContext?.RequestServices.GetService<IPasswordHasher<User>>());
        public IPasswordValidator<User> passwordValidator => _passwordValidator ?? (_passwordValidator = HttpContext?.RequestServices.GetService<IPasswordValidator<User>>());
        public RoleManager<IdentityRole> rolesManager => _rolesManager ?? (_rolesManager = HttpContext?.RequestServices.GetService<RoleManager<IdentityRole>>());
        public ICategoryService categoryService => _categoryService ?? (_categoryService = HttpContext?.RequestServices.GetService<ICategoryService>());
        public IUserService userService => _userService ?? (_userService = HttpContext?.RequestServices.GetService<IUserService>());
        public ILibraryService libraryService => _libraryService ?? (_libraryService = HttpContext?.RequestServices.GetService<ILibraryService>());
        public IRolesService rolesService => _rolesService ?? (_rolesService = HttpContext?.RequestServices.GetService<IRolesService>());
        public ICardService cardService => _cardService ?? (_cardService = HttpContext?.RequestServices.GetService<ICardService>());
        public ServiceResult ServiceResult => _ServiceResult ?? (_ServiceResult = HttpContext?.RequestServices.GetService<ServiceResult>());
        public void StartTemp()
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