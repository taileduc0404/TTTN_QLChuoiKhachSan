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
					LoaiPhongId = x.LoaiPhongId,
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
		public async Task<IActionResult> CreatePhong(PhongCommonVM vm, IFormFile hinhAnh)
		{
			var phong = new Phong
			{
				LoaiPhongId = vm.CreatePhongVM!.IdLoaiPhong,
				MoTa = vm.CreatePhongVM!.MoTa,
				TinhTrangPhong = vm.CreatePhongVM.TinhTrangPhong,
				GiaPhong = vm.CreatePhongVM.GiaPhong,
				DienTich = vm.CreatePhongVM.DienTich,
				SoGiuong = vm.CreatePhongVM.SoGiuong
			};

			if (vm.CreatePhongVM.HinhAnh != null && vm.CreatePhongVM.HinhAnh.Length > 0)
			{
				phong.HinhAnh = UploadImage(vm.CreatePhongVM.HinhAnh);
			}

			await _context.Phongs!.AddAsync(phong);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index", "Phong", new { Areas = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> DeletePhong(int id)
		{
			var phong = await _context.Phongs!.FindAsync(id);
			if (phong is null)
			{
				return NotFound();
			}
			_context.Phongs.Remove(phong);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Phong", new { Areas = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePhong(PhongCommonVM vm)
		{
			if (ModelState.IsValid)
			{
				var phong = await _context.Phongs!.FindAsync(vm.UpdatePhongVM!.Id);
				try
				{
					if (phong is null)
					{
						return RedirectToAction("Index", "Phong", new { Areas = "Admin" });
					}

					//loaiPhong.TenLoaiPhong = vm.UpdateLoaiPhongVM!.TenLoaiPhong;
					//loaiPhong.MoTa = vm.UpdateLoaiPhongVM.MoTa;
					//loaiPhong.GiaPhong = vm.UpdateLoaiPhongVM.GiaPhong;
					//loaiPhong.SoLuongPhong = vm.UpdateLoaiPhongVM.SoLuongPhong;
					_context.Update(phong);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (phong is null)
					{
						return RedirectToAction("Index", "Phong", new { Areas = "Admin" });
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index", "Phong", new { Areas = "Admin" });
			}
			return RedirectToAction("Index", "Phong", new { Areas = "Admin" });
		}

		public string UploadImage(IFormFile file)
		{
			string uniqueFileName = "";
			var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "hinhanh/phong/");
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
