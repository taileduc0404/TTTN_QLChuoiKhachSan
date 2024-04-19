using Microsoft.AspNetCore.Mvc;

namespace TTTN_QLKhachSan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
