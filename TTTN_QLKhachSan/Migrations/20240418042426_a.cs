using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTTN_QLKhachSan.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_baocaos",
                table: "baocaos");

            migrationBuilder.RenameTable(
                name: "baocaos",
                newName: "Baocaos");

            migrationBuilder.AlterColumn<string>(
                name: "LoaiBaoCao",
                table: "Baocaos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baocaos",
                table: "Baocaos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Baocaos",
                table: "Baocaos");

            migrationBuilder.RenameTable(
                name: "Baocaos",
                newName: "baocaos");

            migrationBuilder.AlterColumn<string>(
                name: "LoaiBaoCao",
                table: "baocaos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_baocaos",
                table: "baocaos",
                column: "Id");
        }
    }
}
