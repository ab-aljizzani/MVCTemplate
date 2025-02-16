using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class SickLeaveIdToAppointModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Appointment_SickLeave_SickLeaveId",
            //     table: "Appointment");
            migrationBuilder.AddColumn<int>(
                name: "SickLeaveId",
                table: "Appointment",
                type: "int",
                nullable: true,
                defaultValue: 0);

            // migrationBuilder.AlterColumn<int>(
            //     name: "SickLeaveId",
            //     table: "Appointment",
            //     type: "int",
            //     nullable: true,
            //     oldClrType: typeof(int),
            //     oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_SickLeave_SickLeaveId",
                table: "Appointment",
                column: "SickLeaveId",
                principalTable: "SickLeave",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Appointment_SickLeave_SickLeaveId",
            //     table: "Appointment");

            // migrationBuilder.AlterColumn<int>(
            //     name: "SickLeaveId",
            //     table: "Appointment",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0,
            //     oldClrType: typeof(int),
            //     oldType: "int",
            //     oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_SickLeave_SickLeaveId",
                table: "Appointment",
                column: "SickLeaveId",
                principalTable: "SickLeave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
