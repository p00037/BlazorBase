using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBase.Infrastructure.Migrations
{
    public partial class CreateM_事業所 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_事業所",
                columns: table => new
                {
                    事業所番号 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    事業所名 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    事業所名カナ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    郵便番号 = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    住所 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    電話番号 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    定員規模 = table.Column<int>(type: "int", nullable: true),
                    就労継続A型減免有無 = table.Column<bool>(type: "bit", nullable: false),
                    登録日 = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_事業所", x => x.事業所番号);
                });

            migrationBuilder.CreateTable(
                name: "M_事業所明細",
                columns: table => new
                {
                    事業所番号 = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    連番 = table.Column<int>(type: "int", nullable: false),
                    施設名 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    種類コード = table.Column<bool>(type: "bit", nullable: false),
                    サービス提供単位番号 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    定員 = table.Column<int>(type: "int", nullable: true),
                    多機能型用件 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    単位数単価 = table.Column<decimal>(type: "decimal(4,2)", nullable: true),
                    種類区分 = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_事業所明細", x => new { x.事業所番号, x.連番 });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_事業所");

            migrationBuilder.DropTable(
                name: "M_事業所明細");
        }
    }
}
