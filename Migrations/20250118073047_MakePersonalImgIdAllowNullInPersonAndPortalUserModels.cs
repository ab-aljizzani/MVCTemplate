using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakePersonalImgIdAllowNullInPersonAndPortalUserModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Appointment_AppointmentId",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Request",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyTypeId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment",
                column: "SurveyTypeId",
                principalTable: "SurveyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Appointment_AppointmentId",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Request",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyTypeId",
                table: "Appointment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment",
                column: "SurveyTypeId",
                principalTable: "SurveyType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Appointment_AppointmentId",
                table: "Request",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");
        }
    }
}
