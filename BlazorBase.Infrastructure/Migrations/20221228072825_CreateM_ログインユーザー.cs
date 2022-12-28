using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBase.Infrastructure.Migrations
{
    public partial class CreateM_ログインユーザー : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_ログインユーザー",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_ログインユーザー", x => x.UserName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_ログインユーザー");
        }
    }
}
