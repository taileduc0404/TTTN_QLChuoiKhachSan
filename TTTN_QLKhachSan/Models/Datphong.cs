namespace TTTN_QLKhachSan.Models
{
    public class Datphong
    {
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int PhongId { get; set; }
        public int LoaiPhongId { get; set; }
        public DateTime NgayDen { get; set; }
        public DateTime NgayDi { get; set; }
        public int SoLuongNguoi { get; set; }
        public decimal GiaPhong { get; set; }
        public string? TrangThaiDatPhong { get; set; }
        public virtual Khachhang? KhachHangIdNavigation { get; set; }
        public virtual Phong? PhongIdNavigation { get; set; }
        public virtual Loaiphong? LoaiPhongIdIdNavigation { get; set; }

    }
}
