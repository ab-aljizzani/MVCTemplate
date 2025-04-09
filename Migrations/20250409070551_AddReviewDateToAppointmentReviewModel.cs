using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewDateToAppointmentReviewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReviewDate",
                table: "AppointmentReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentReview_PortalUserId",
                table: "AppointmentReview",
                column: "PortalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentReview_PortalUser_PortalUserId",
                table: "AppointmentReview",
                column: "PortalUserId",
                principalTable: "PortalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentReview_PortalUser_PortalUserId",
                table: "AppointmentReview");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentReview_PortalUserId",
                table: "AppointmentReview");

            migrationBuilder.DropColumn(
                name: "ReviewDate",
                table: "AppointmentReview");
        }
    }
}
