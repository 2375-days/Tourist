using Microsoft.EntityFrameworkCore.Migrations;

namespace Tourist.API.Migrations
{
    public partial class ThirdDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristRoutePicture_TouristRoute_TouristRouteId",
                table: "TouristRoutePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoutePicture",
                table: "TouristRoutePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoute",
                table: "TouristRoute");

            migrationBuilder.RenameTable(
                name: "TouristRoutePicture",
                newName: "TouristRoutesPictures");

            migrationBuilder.RenameTable(
                name: "TouristRoute",
                newName: "TouristRoutes");

            migrationBuilder.RenameIndex(
                name: "IX_TouristRoutePicture_TouristRouteId",
                table: "TouristRoutesPictures",
                newName: "IX_TouristRoutesPictures_TouristRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoutesPictures",
                table: "TouristRoutesPictures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoutes",
                table: "TouristRoutes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristRoutesPictures_TouristRoutes_TouristRouteId",
                table: "TouristRoutesPictures",
                column: "TouristRouteId",
                principalTable: "TouristRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristRoutesPictures_TouristRoutes_TouristRouteId",
                table: "TouristRoutesPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoutesPictures",
                table: "TouristRoutesPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TouristRoutes",
                table: "TouristRoutes");

            migrationBuilder.RenameTable(
                name: "TouristRoutesPictures",
                newName: "TouristRoutePicture");

            migrationBuilder.RenameTable(
                name: "TouristRoutes",
                newName: "TouristRoute");

            migrationBuilder.RenameIndex(
                name: "IX_TouristRoutesPictures_TouristRouteId",
                table: "TouristRoutePicture",
                newName: "IX_TouristRoutePicture_TouristRouteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoutePicture",
                table: "TouristRoutePicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TouristRoute",
                table: "TouristRoute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristRoutePicture_TouristRoute_TouristRouteId",
                table: "TouristRoutePicture",
                column: "TouristRouteId",
                principalTable: "TouristRoute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
