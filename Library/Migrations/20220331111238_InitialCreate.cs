using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NationalityInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    County = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalityInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisaInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisaStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VisaEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SecondName = table.Column<string>(type: "text", nullable: false),
                    NationalityInfosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passports_NationalityInfos_NationalityInfosId",
                        column: x => x.NationalityInfosId,
                        principalTable: "NationalityInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "internationalPassportInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InternationalPassportFirstName = table.Column<string>(type: "text", nullable: false),
                    InternationalPassportLastName = table.Column<string>(type: "text", nullable: false),
                    DateStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassportInfoKey = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_internationalPassportInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_internationalPassportInfos_Passports_PassportInfoKey",
                        column: x => x.PassportInfoKey,
                        principalTable: "Passports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternationalPassportInfoVisaInfo",
                columns: table => new
                {
                    InternationalPassportId = table.Column<int>(type: "integer", nullable: false),
                    VisaInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternationalPassportInfoVisaInfo", x => new { x.VisaInfoId, x.InternationalPassportId });
                    table.ForeignKey(
                        name: "FK_InternationalPassportInfoVisaInfo_internationalPassportInfo~",
                        column: x => x.InternationalPassportId,
                        principalTable: "internationalPassportInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternationalPassportInfoVisaInfo_VisaInfos_VisaInfoId",
                        column: x => x.VisaInfoId,
                        principalTable: "VisaInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_internationalPassportInfos_PassportInfoKey",
                table: "internationalPassportInfos",
                column: "PassportInfoKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternationalPassportInfoVisaInfo_InternationalPassportId",
                table: "InternationalPassportInfoVisaInfo",
                column: "InternationalPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_NationalityInfosId",
                table: "Passports",
                column: "NationalityInfosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternationalPassportInfoVisaInfo");

            migrationBuilder.DropTable(
                name: "internationalPassportInfos");

            migrationBuilder.DropTable(
                name: "VisaInfos");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "NationalityInfos");
        }
    }
}
