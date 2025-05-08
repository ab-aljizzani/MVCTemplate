using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditOldDataCulomnToAuditModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDoctorReview",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "IsSurveyInserted",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "SurveyScore",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "AuditOldData",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditOldData",
                table: "Audits");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentDoctorReview",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSurveyInserted",
                table: "Appointment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SurveyScore",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
