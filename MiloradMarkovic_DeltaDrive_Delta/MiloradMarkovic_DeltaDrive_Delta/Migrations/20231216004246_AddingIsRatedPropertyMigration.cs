using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiloradMarkovic_DeltaDrive_Delta.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsRatedPropertyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRated",
                table: "History",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRated",
                table: "History");
        }
    }
}
