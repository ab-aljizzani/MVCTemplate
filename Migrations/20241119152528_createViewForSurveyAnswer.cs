using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class createViewForSurveyAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "surveyAnswerId",
                table: "SurveyQuestion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyAnswer_SurveyAnswerId",
                table: "UserSurveyAnswer",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_surveyAnswerId",
                table: "SurveyQuestion",
                column: "surveyAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswer_surveyAnswerId",
                table: "SurveyQuestion",
                column: "surveyAnswerId",
                principalTable: "SurveyAnswer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyAnswer_SurveyAnswer_SurveyAnswerId",
                table: "UserSurveyAnswer",
                column: "SurveyAnswerId",
                principalTable: "SurveyAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswer_surveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyAnswer_SurveyAnswer_SurveyAnswerId",
                table: "UserSurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_UserSurveyAnswer_SurveyAnswerId",
                table: "UserSurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestion_surveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.DropColumn(
                name: "surveyAnswerId",
                table: "SurveyQuestion");
        }
    }
}
