
namespace TTTN_QLKhachSan.ViewModels
{
    public class CreatePhongVM
    {
        public int IdLoaiPhong { get; set; }
        public string? MoTa { get; set; }
        public string? TinhTrangPhong { get; set; }
        public decimal GiaPhong { get; set; }
        public string? DienTich { get; set; }
        public int SoGiuong { get; set; }
        public IFormFile? HinhAnh { get; set; }
    }
}
