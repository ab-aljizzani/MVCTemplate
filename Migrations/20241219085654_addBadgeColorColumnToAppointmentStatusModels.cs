using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class addBadgeColorColumnToAppointmentStatusModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BadgeColor",
                table: "AppointmentStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeColor",
                table: "AppointmentStatus");
        }
    }
}
