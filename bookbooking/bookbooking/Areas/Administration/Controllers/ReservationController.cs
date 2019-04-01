using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bookbooking.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReservationController : BaseController<ReservationController>
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}