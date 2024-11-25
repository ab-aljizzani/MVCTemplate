using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class changeUserIdNameInUserSurveyAnswerToPortalUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSurveyAnswer",
                newName: "PortalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyAnswer_PersonId",
                table: "UserSurveyAnswer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyAnswer_PortalUserId",
                table: "UserSurveyAnswer",
                column: "PortalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyAnswer_Person_PersonId",
                table: "UserSurveyAnswer",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyAnswer_PortalUser_PortalUserId",
                table: "UserSurveyAnswer",
                column: "PortalUserId",
                principalTable: "PortalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyAnswer_Person_PersonId",
                table: "UserSurveyAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyAnswer_PortalUser_PortalUserId",
                table: "UserSurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserSurveyAnswer_PersonId",
                table: "UserSurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserSurveyAnswer_PortalUserId",
                table: "UserSurveyAnswer");

            migrationBuilder.RenameColumn(
                name: "PortalUserId",
                table: "UserSurveyAnswer",
                newName: "UserId");
        }
    }
}
