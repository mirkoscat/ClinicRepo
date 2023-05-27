using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class carttableadjust : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Carts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_PictureId",
                table: "Carts",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Image_PictureId",
                table: "Carts",
                column: "PictureId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Image_PictureId",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Carts_PictureId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Carts");
        }
    }
}
