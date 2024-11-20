using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddForinKeyToUserSurveyAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyAnswer_SurveyQuestionId",
                table: "UserSurveyAnswer",
                column: "SurveyQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyAnswer_SurveyQuestion_SurveyQuestionId",
                table: "UserSurveyAnswer",
                column: "SurveyQuestionId",
                principalTable: "SurveyQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyAnswer_SurveyQuestion_SurveyQuestionId",
                table: "UserSurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserSurveyAnswer_SurveyQuestionId",
                table: "UserSurveyAnswer");
        }
    }
}
