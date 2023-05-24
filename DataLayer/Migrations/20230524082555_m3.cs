using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerLastName",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "OwnerLastName",
                table: "ClinicAnimal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "ClinicAnimal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Animals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owner_OwnerId",
                table: "Animals",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owner_OwnerId",
                table: "Animals");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Animals_OwnerId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "OwnerLastName",
                table: "ClinicAnimal");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "ClinicAnimal");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "OwnerLastName",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
