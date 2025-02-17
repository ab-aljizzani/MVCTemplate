using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentIdToSickLeaveModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_SickLeave_SickLeaveId",
                table: "Appointment");

            // migrationBuilder.DropIndex(
            //     name: "IX_Appointment_SickLeaveId",
            //     table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SickLeaveId",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "SickLeave",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "SickLeave");

            migrationBuilder.AddColumn<int>(
                name: "SickLeaveId",
                table: "Appointment",
                type: "int",
                nullable: true);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Appointment_SickLeaveId",
            //     table: "Appointment",
            //     column: "SickLeaveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_SickLeave_SickLeaveId",
                table: "Appointment",
                column: "SickLeaveId",
                principalTable: "SickLeave",
                principalColumn: "Id");
        }
    }
}
