using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class pictureextoncart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PictureId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Carts",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Carts",
                type: "int",
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
    }
}
