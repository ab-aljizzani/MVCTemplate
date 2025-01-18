using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeSurveyTypeIdAllowNullInAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment");

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
        }
    }
}
