using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCreateDateAndPortalUserIdToSickAndPerscriptionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateDate",
                table: "SickLeave",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateDate",
                table: "Perscription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PortalUserId",
                table: "Perscription",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "SickLeave");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Perscription");

            migrationBuilder.DropColumn(
                name: "PortalUserId",
                table: "Perscription");
        }
    }
}
