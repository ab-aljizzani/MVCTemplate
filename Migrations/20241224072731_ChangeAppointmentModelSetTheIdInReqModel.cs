using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppointmentModelSetTheIdInReqModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Request_AppointmentId",
                table: "Request",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Appointment_AppointmentId",
                table: "Request",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Appointment_AppointmentId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_AppointmentId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Request");
        }
    }
}
