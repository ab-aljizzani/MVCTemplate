using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonModelToSickleav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "SickLeave",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SickLeave_PersonId",
                table: "SickLeave",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SickLeave_Person_PersonId",
                table: "SickLeave",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SickLeave_Person_PersonId",
                table: "SickLeave");

            migrationBuilder.DropIndex(
                name: "IX_SickLeave_PersonId",
                table: "SickLeave");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "SickLeave");
        }
    }
}
