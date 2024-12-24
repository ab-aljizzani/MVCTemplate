using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPortalUserToAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortalUserId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PortalUserId",
                table: "Appointment",
                column: "PortalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_PortalUser_PortalUserId",
                table: "Appointment",
                column: "PortalUserId",
                principalTable: "PortalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_PortalUser_PortalUserId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_PortalUserId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "PortalUserId",
                table: "Appointment");
        }
    }
}
