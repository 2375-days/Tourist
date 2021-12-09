using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tourist.API.Migrations
{
    public partial class SimpDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TouristRoute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DiscountPercent = table.Column<double>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DepartureTime = table.Column<DateTime>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Fees = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristRoute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TouristRoutePicture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    TouristRouteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristRoutePicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristRoutePicture_TouristRoute_TouristRouteId",
                        column: x => x.TouristRouteId,
                        principalTable: "TouristRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TouristRoute",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPercent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("ffcd70c5-a3a4-4afa-a4ad-c5fe720d9ec3"), new DateTime(2021, 12, 9, 7, 31, 27, 135, DateTimeKind.Utc).AddTicks(4233), null, "测试数据2", null, null, null, null, 0m, "测试数据", null });

            migrationBuilder.CreateIndex(
                name: "IX_TouristRoutePicture_TouristRouteId",
                table: "TouristRoutePicture",
                column: "TouristRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TouristRoutePicture");

            migrationBuilder.DropTable(
                name: "TouristRoute");
        }
    }
}
