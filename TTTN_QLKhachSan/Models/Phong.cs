namespace TTTN_QLKhachSan.Models
{
    public class Phong
    {
        public int Id {  get; set; }
        public int LoaiPhongId { get; set; }
        public string? MoTa {  get; set; }
        public string? TinhTrangPhong {  get; set; }
        public decimal GiaPhong {  get; set; }
        public string? DienTich {  get; set; }
        public int SoGiuong {  get; set; }
        public string? HinhAnh {  get; set; }
        public virtual Loaiphong? LoaiPhongIdIdNavigation { get; set; }
    }
}
