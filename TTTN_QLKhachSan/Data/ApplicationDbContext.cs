using Microsoft.EntityFrameworkCore;
using TTTN_QLKhachSan.Models;

namespace TTTN_QLKhachSan.Data
{
	public class ApplicationDbContext : DbContext
	{

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Baocao>? Baocaos { get; set; }
		public DbSet<Chinhanh>? Chinhanhs { get; set; }
		//public DbSet<Chuoikhachsan>? Chuoikhachsans { get; set; }
		//public DbSet<Danhgia>? Danhgias { get; set; }
		//public DbSet<Datphong>? Datphongs { get; set; }
		public DbSet<Dichvu>? Dichvus { get; set; }
		public DbSet<Khachhang>? Khachhanga { get; set; }
		public DbSet<Loaiphong>? Loaiphongs { get; set; }
		public DbSet<Nhanvien>? Nhanviens { get; set; }
		public DbSet<Phong>? Phongs { get; set; }
		public DbSet<Thietbi>? Thietbis { get; set; }
	}
}
