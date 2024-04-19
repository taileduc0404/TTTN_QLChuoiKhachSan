namespace TTTN_QLKhachSan.Models
{
    public class Danhgia
    {
        public int Id { get; set; }
        public int KhachHangId { get; set; }
        public int PhongId { get; set; }
        public int LoaiPhongId { get; set; }
        public int DiemDanhGia { get; set; }
        public string? BinhLuan { get; set; }
        public virtual Khachhang? KhachHangIdNagivation { get; set; }
        public virtual Phong? PhongIdNagivation { get; set; }
        public virtual Loaiphong? LoaiPhongIdNagivation { get; set; }
    }
}
