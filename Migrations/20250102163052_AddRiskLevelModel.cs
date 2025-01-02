using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRiskLevelModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiskLevel",
                table: "Appointment");

            migrationBuilder.AddColumn<int>(
                name: "RiskLevelId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RiskLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Risk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskLevel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_RiskLevelId",
                table: "Appointment",
                column: "RiskLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_RiskLevel_RiskLevelId",
                table: "Appointment",
                column: "RiskLevelId",
                principalTable: "RiskLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_RiskLevel_RiskLevelId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "RiskLevel");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_RiskLevelId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "RiskLevelId",
                table: "Appointment");

            migrationBuilder.AddColumn<string>(
                name: "RiskLevel",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
