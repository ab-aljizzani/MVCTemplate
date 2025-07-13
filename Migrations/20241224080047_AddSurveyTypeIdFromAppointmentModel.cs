using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyTypeIdFromAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "SurveyTypeId",
            //     table: "Appointment",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.CreateIndex(
            //     name: "IX_Appointment_SurveyTypeId",
            //     table: "Appointment",
            //     column: "SurveyTypeId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Appointment_SurveyType_SurveyTypeId",
            //     table: "Appointment",
            //     column: "SurveyTypeId",
            //     principalTable: "SurveyType",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Appointment_SurveyType_SurveyTypeId",
            //     table: "Appointment");

            // migrationBuilder.DropIndex(
            //     name: "IX_Appointment_SurveyTypeId",
            //     table: "Appointment");

            // migrationBuilder.DropColumn(
            //     name: "SurveyTypeId",
            //     table: "Appointment");
        }
    }
}
