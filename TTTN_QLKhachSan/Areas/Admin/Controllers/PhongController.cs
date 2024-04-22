using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TTTN_QLKhachSan.Data;
using TTTN_QLKhachSan.Models;
using TTTN_QLKhachSan.ViewModels;

namespace TTTN_QLKhachSan.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class PhongController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhongController(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var loaiPhongs = _context.Loaiphongs!.ToList(); // Lấy danh sách tất cả các loại phòng

            ViewBag.LoaiPhongs = new SelectList(loaiPhongs, "Id", "TenLoaiPhong"); // Gán danh sách loại phòng vào ViewBag để sử dụng trong view

            var phongs = _context.Phongs!
                .Include(x => x.LoaiPhongIdIdNavigation)
                .Select(x => new PhongVM
                {
                    Id = x.Id,
                    TenLoaiPhong = x.LoaiPhongIdIdNavigation!.TenLoaiPhong,
                    MoTa = x.MoTa,
                    TinhTrangPhong = x.TinhTrangPhong,
                    GiaPhong = x.GiaPhong,
                    DienTich = x.DienTich,
                    SoGiuong = x.SoGiuong,
                    HinhAnh = x.HinhAnh
                }).ToList();

			var viewModel = new PhongCommonVM
			{
				PhongVM = phongs,
			};

			return View(viewModel);
        }

        [HttpPost]
        public IActionResult GetGiaMoTa(int loaiPhongId)
        {
            var loaiPhong = _context.Loaiphongs!.FirstOrDefault(lp => lp.Id == loaiPhongId);
            if (loaiPhong != null)
            {
                return Json(new { giaPhong = loaiPhong.GiaPhong, moTa = loaiPhong.MoTa });
            }
            return Json(null);
        }


		[HttpPost]
		public IActionResult CreatePhong(PhongCommonVM vm, IFormFile hinhAnh)
		{
			if (ModelState.IsValid)
			{
				// Tạo một đối tượng Phong từ dữ liệu trong biểu mẫu
				var phong = new Phong
				{
					//LoaiPhongId = vm.CreatePhongVM.,
					// Chú ý: Cần cung cấp Id của loại phòng, không phải tên
					MoTa = vm.CreatePhongVM!.MoTa,
					TinhTrangPhong = vm.CreatePhongVM.TinhTrangPhong,
					GiaPhong = vm.CreatePhongVM.GiaPhong,
					DienTich = vm.CreatePhongVM.DienTich,
					SoGiuong = vm.CreatePhongVM.SoGiuong
				};

				// Upload hình ảnh và lưu tên file vào đối tượng phòng
				if (hinhAnh != null && hinhAnh.Length > 0)
				{
					phong.HinhAnh = UploadImage(hinhAnh);
				}

				// Lưu đối tượng phòng vào cơ sở dữ liệu
				_context.Phongs!.Add(phong);
				_context.SaveChanges();

				// Chuyển hướng đến trang Index hoặc trang khác tùy theo yêu cầu của ứng dụng
				return RedirectToAction("Index");
			}

			// Nếu dữ liệu không hợp lệ, trả về trang hiện tại với thông báo lỗi
			return View(vm);
		}


		public string UploadImage(IFormFile file)
        {
            string uniqueFileName = "";
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "thumbnails");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
