using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class EditViewForSurveyAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswer_surveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestion_surveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.DropColumn(
                name: "surveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_SurveyAnswerTypeId",
                table: "SurveyQuestion",
                column: "SurveyAnswerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswerType_SurveyAnswerTypeId",
                table: "SurveyQuestion",
                column: "SurveyAnswerTypeId",
                principalTable: "SurveyAnswerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswerType_SurveyAnswerTypeId",
                table: "SurveyQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestion_SurveyAnswerTypeId",
                table: "SurveyQuestion");

            migrationBuilder.AddColumn<int>(
                name: "surveyAnswerId",
                table: "SurveyQuestion",
                type: "int",
                nullable: true);

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
        }
    }
}
