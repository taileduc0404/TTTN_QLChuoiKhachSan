using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTTN_QLKhachSan.Data;
using TTTN_QLKhachSan.Models;
using TTTN_QLKhachSan.ViewModels;

namespace TTTN_QLKhachSan.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LoaiPhongController : Controller
	{
		private readonly ApplicationDbContext _context;

		public LoaiPhongController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			//var loaiPhongs = await _context.Loaiphongs!
			//    .Select(x => new LoaiPhongVM
			//    {
			//        Id = x.Id,
			//        TenLoaiPhong = x.TenLoaiPhong,
			//        MoTa = x.MoTa,
			//        GiaPhong = x.GiaPhong,
			//        SoLuongPhong = x.SoLuongPhong,
			//    }).ToListAsync();
			//return View(loaiPhongs);
			var loaiPhongs = await _context.Loaiphongs!
				.Select(x => new LoaiPhongVM
				{
					Id = x.Id,
					TenLoaiPhong = x.TenLoaiPhong,
					MoTa = x.MoTa,
					GiaPhong = x.GiaPhong,
					SoLuongPhong = x.SoLuongPhong,
				}).ToListAsync();

			var viewModel = new LoaiPhongCommonVM
			{
				LoaiPhongs = loaiPhongs,
				CreateLoaiPhongVM = new CreateLoaiPhongVM()
			};

			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> CreateLoaiPhong(LoaiPhongCommonVM vm)
		{
			if (ModelState.IsValid)
			{
				var loaiPhong = new Loaiphong
				{
					TenLoaiPhong = vm.CreateLoaiPhongVM!.TenLoaiPhong!,
					MoTa = vm.CreateLoaiPhongVM!.MoTa != null ? vm.CreateLoaiPhongVM!.MoTa : "",
					GiaPhong = vm.CreateLoaiPhongVM!.GiaPhong,
					SoLuongPhong = vm.CreateLoaiPhongVM!.SoLuongPhong,
				};


				await _context.Loaiphongs!.AddAsync(loaiPhong);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });

			}
			return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> DeleteLoaiPhong(int id)
		{
			var loaiPhong = await _context.Loaiphongs!.FindAsync(id);
			if (loaiPhong is null)
			{
				return NotFound();
			}
			_context.Loaiphongs.Remove(loaiPhong);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> UpdateLoaiPhong(int id, LoaiPhongCommonVM vm)
		{
			if (ModelState.IsValid)
			{
				var loaiPhong = await _context.Loaiphongs!.FindAsync(vm.UpdateLoaiPhongVM!.Id);
				try
				{
					if (loaiPhong is null)
					{
						return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });
					}

					loaiPhong.TenLoaiPhong = vm.UpdateLoaiPhongVM!.TenLoaiPhong;
					loaiPhong.MoTa = vm.UpdateLoaiPhongVM.MoTa;
					loaiPhong.GiaPhong = vm.UpdateLoaiPhongVM.GiaPhong;
					loaiPhong.SoLuongPhong = vm.UpdateLoaiPhongVM.SoLuongPhong;
					_context.Update(loaiPhong);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (loaiPhong is null)
					{
						return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });
			}
			return RedirectToAction("Index", "LoaiPhong", new { Areas = "Admin" });
		}
	}
}
