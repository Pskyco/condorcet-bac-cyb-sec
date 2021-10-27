using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddPerformerPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PerformerPersonId",
                table: "PcrTests",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date()"),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    PcrTestId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_PcrTests_PcrTestId",
                        column: x => x.PcrTestId,
                        principalTable: "PcrTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("d5a14f59-90ea-48a7-b781-6971e505d250"), "Ludwig", "Lebrun" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { new Guid("e52b7f76-c61e-4f24-8f44-edb381e3df50"), "Hicham", "Erradi" });

            migrationBuilder.CreateIndex(
                name: "IX_PcrTests_PerformerPersonId",
                table: "PcrTests",
                column: "PerformerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_PcrTestId",
                table: "Observations",
                column: "PcrTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PcrTests_Persons_PerformerPersonId",
                table: "PcrTests",
                column: "PerformerPersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcrTests_Persons_PerformerPersonId",
                table: "PcrTests");

            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_PcrTests_PerformerPersonId",
                table: "PcrTests");

            migrationBuilder.DropColumn(
                name: "PerformerPersonId",
                table: "PcrTests");
        }
    }
}
