using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class addAppointmentDayToAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentDay",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "AppointmentDay",
                table: "Appointment");
        }
    }
}
