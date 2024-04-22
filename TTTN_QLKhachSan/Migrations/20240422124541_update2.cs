using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTTN_QLKhachSan.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phongs_Loaiphongs_LoaiPhongIdIdNavigationId",
                table: "Phongs");

            migrationBuilder.DropIndex(
                name: "IX_Phongs_LoaiPhongIdIdNavigationId",
                table: "Phongs");

            migrationBuilder.DropColumn(
                name: "LoaiPhongIdIdNavigationId",
                table: "Phongs");

            migrationBuilder.AddColumn<int>(
                name: "LoaiPhongId",
                table: "Phongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_LoaiPhongId",
                table: "Phongs",
                column: "LoaiPhongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phongs_Loaiphongs_LoaiPhongId",
                table: "Phongs",
                column: "LoaiPhongId",
                principalTable: "Loaiphongs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phongs_Loaiphongs_LoaiPhongId",
                table: "Phongs");

            migrationBuilder.DropIndex(
                name: "IX_Phongs_LoaiPhongId",
                table: "Phongs");

            migrationBuilder.DropColumn(
                name: "LoaiPhongId",
                table: "Phongs");

            migrationBuilder.AddColumn<int>(
                name: "LoaiPhongIdIdNavigationId",
                table: "Phongs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phongs_LoaiPhongIdIdNavigationId",
                table: "Phongs",
                column: "LoaiPhongIdIdNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phongs_Loaiphongs_LoaiPhongIdIdNavigationId",
                table: "Phongs",
                column: "LoaiPhongIdIdNavigationId",
                principalTable: "Loaiphongs",
                principalColumn: "Id");
        }
    }
}
