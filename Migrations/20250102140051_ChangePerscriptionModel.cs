using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangePerscriptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerscriptionId",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Perscription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Perscription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Perscription");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Perscription");

            migrationBuilder.AddColumn<int>(
                name: "PerscriptionId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
