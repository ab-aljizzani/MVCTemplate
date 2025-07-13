using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class DropSurveyTypeIdFromAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Appointment_SurveyType_SurveyTypeId",
            //     table: "Appointment");


            // migrationBuilder.DropColumn(
            //     name: "SurveyTypeId",
            //     table: "Appointment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<int>(
            //     name: "SurveyTypeId",
            //     table: "Appointment",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Appointment_SurveyType_SurveyTypeId",
            //     table: "Appointment",
            //     column: "SurveyTypeId",
            //     principalTable: "SurveyType",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
