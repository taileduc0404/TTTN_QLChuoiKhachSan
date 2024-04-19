using TTTN_QLKhachSan.Models;

namespace TTTN_QLKhachSan.ViewModels
{
	public class PhongVM
	{
		public int Id { get; set; }
		public string? TenLoaiPhong { get; set; }
		public decimal GiaPhong { get; set; }
		public int SoGiuong { get; set; }
		public string? MoTa { get; set; }

		public virtual Loaiphong? LoaiPhongIdIdNavigation { get; set; }
	}
}
