using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiloradMarkovic_DeltaDrive_Delta.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsBookedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooked",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooked",
                table: "Vehicles");
        }
    }
}
