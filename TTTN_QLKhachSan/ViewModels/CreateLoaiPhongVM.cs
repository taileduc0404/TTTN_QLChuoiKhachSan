using System.ComponentModel.DataAnnotations;

namespace TTTN_QLKhachSan.ViewModels
{
    public class CreateLoaiPhongVM
    {

        public string? TenLoaiPhong { get; set; }
        public string? MoTa { get; set; }
        public decimal GiaPhong { get; set; }
        public int SoLuongPhong { get; set; }
    }
}
