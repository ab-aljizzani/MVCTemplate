using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class addIsInsertedColumnToAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApsentReason",
                table: "Appointment");

            migrationBuilder.AddColumn<bool>(
                name: "IsSurveyInserted",
                table: "Appointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SurveyTypeId",
                table: "Appointment",
                column: "SurveyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment",
                column: "SurveyTypeId",
                principalTable: "SurveyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_SurveyType_SurveyTypeId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_SurveyTypeId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "IsSurveyInserted",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "ApsentReason",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
