using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}