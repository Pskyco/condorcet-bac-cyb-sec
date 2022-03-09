using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAudit.Migrations
{
    public partial class Audit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreationUserId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDateTime",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastUpdaterUserId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTrail");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreationUserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateTime",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastUpdaterUserId",
                table: "Persons");
        }
    }
}
