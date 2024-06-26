﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTTN_QLKhachSan.Data;

#nullable disable

namespace TTTN_QLKhachSan.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Baocao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("DoanhThu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LoaiBaoCao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LuongKhachHang")
                        .HasColumnType("int");

                    b.Property<float>("TiLeDatPhong")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Baocaos");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Chinhanh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Diachi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sdt")
                        .HasColumnType("int");

                    b.Property<string>("Tenchinhanh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Chinhanhs");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Dichvu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("GiaDichVu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDichVu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dichvus");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Khachhang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoVaTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiKhachHang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuocTich")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Khachhanga");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Loaiphong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("GiaPhong")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuongPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiPhong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Loaiphongs");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Nhanvien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ChucVu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hoten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nhanviens");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Phong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DienTich")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("GiaPhong")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiPhongId")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoGiuong")
                        .HasColumnType("int");

                    b.Property<string>("TinhTrangPhong")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoaiPhongId");

                    b.ToTable("Phongs");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Thietbi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenThietBi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhTrang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Thietbis");
                });

            modelBuilder.Entity("TTTN_QLKhachSan.Models.Phong", b =>
                {
                    b.HasOne("TTTN_QLKhachSan.Models.Loaiphong", "LoaiPhongIdIdNavigation")
                        .WithMany()
                        .HasForeignKey("LoaiPhongId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiPhongIdIdNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
