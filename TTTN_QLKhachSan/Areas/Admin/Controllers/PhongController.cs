using Microsoft.AspNetCore.Mvc;
using TTTN_QLKhachSan.Data;
using TTTN_QLKhachSan.ViewModels;

namespace TTTN_QLKhachSan.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PhongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhongController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var phongs = _context.Phongs!
                .Select(x => new PhongVM
                {
                    MoTa = x.MoTa,
                    GiaPhong = x.GiaPhong,
                    Id = x.Id,
                    SoGiuong = x.SoGiuong,
                    TenLoaiPhong = x.LoaiPhongIdIdNavigation.TenLoaiPhong,
                }).ToList();
            return View(phongs);
        }

        //public async Task<IActionResult> CreatePhong()
        //{

        //}

    }
}
