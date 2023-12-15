using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiloradMarkovic_DeltaDrive_Delta.Migrations
{
    /// <inheritdoc />
    public partial class ModifyHistoryPreviewEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "History",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "History",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsArrived",
                table: "History",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "History");

            migrationBuilder.DropColumn(
                name: "IsArrived",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "History",
                newName: "DateTime");
        }
    }
}
