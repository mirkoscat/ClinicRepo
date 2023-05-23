using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class owneronanimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerLastName",
                table: "ClinicAnimal");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "ClinicAnimal");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "ClinicAnimal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
