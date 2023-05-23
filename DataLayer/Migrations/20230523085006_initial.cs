using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Typology = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoatColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasMicrochip = table.Column<bool>(type: "bit", nullable: true),
                    MicrochipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamTypology = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TreatmentDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescriptionBeforeVisit = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicAnimal_Animals_Id",
                        column: x => x.Id,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RecoveryStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecoveryEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsInHospital = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MunicipalAnimal_Animals_Id",
                        column: x => x.Id,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MunicipalVisit_ClinicVisits_Id",
                        column: x => x.Id,
                        principalTable: "ClinicVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClinicAnimalClinicVisit",
                columns: table => new
                {
                    ClinicAnimalsId = table.Column<int>(type: "int", nullable: false),
                    ClinicVisitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicAnimalClinicVisit", x => new { x.ClinicAnimalsId, x.ClinicVisitsId });
                    table.ForeignKey(
                        name: "FK_ClinicAnimalClinicVisit_ClinicAnimal_ClinicAnimalsId",
                        column: x => x.ClinicAnimalsId,
                        principalTable: "ClinicAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicAnimalClinicVisit_ClinicVisits_ClinicVisitsId",
                        column: x => x.ClinicVisitsId,
                        principalTable: "ClinicVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MunicipalAnimalMunicipalVisit",
                columns: table => new
                {
                    MunicipalAnimalsId = table.Column<int>(type: "int", nullable: false),
                    MunicipalVisitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MunicipalAnimalMunicipalVisit", x => new { x.MunicipalAnimalsId, x.MunicipalVisitsId });
                    table.ForeignKey(
                        name: "FK_MunicipalAnimalMunicipalVisit_MunicipalAnimal_MunicipalAnimalsId",
                        column: x => x.MunicipalAnimalsId,
                        principalTable: "MunicipalAnimal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MunicipalAnimalMunicipalVisit_MunicipalVisit_MunicipalVisitsId",
                        column: x => x.MunicipalVisitsId,
                        principalTable: "MunicipalVisit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicAnimalClinicVisit_ClinicVisitsId",
                table: "ClinicAnimalClinicVisit",
                column: "ClinicVisitsId");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalAnimalMunicipalVisit_MunicipalVisitsId",
                table: "MunicipalAnimalMunicipalVisit",
                column: "MunicipalVisitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicAnimalClinicVisit");

            migrationBuilder.DropTable(
                name: "MunicipalAnimalMunicipalVisit");

            migrationBuilder.DropTable(
                name: "ClinicAnimal");

            migrationBuilder.DropTable(
                name: "MunicipalAnimal");

            migrationBuilder.DropTable(
                name: "MunicipalVisit");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "ClinicVisits");
        }
    }
}
