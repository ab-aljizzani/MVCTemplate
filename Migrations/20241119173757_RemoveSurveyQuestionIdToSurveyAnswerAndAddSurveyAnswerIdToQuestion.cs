using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSurveyQuestionIdToSurveyAnswerAndAddSurveyAnswerIdToQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyAnswer_SurveyQuestion_SurveyQuestionId",
                table: "SurveyAnswer");

            migrationBuilder.DropIndex(
                name: "IX_SurveyAnswer_SurveyQuestionId",
                table: "SurveyAnswer");

            migrationBuilder.DropColumn(
                name: "SurveyQuestionId",
                table: "SurveyAnswer");

            migrationBuilder.AddColumn<int>(
                name: "SurveyAnswerId",
                table: "SurveyQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_SurveyAnswerId",
                table: "SurveyQuestion",
                column: "SurveyAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswer_SurveyAnswerId",
                table: "SurveyQuestion",
                column: "SurveyAnswerId",
                principalTable: "SurveyAnswer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestion_SurveyAnswer_SurveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestion_SurveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.DropColumn(
                name: "SurveyAnswerId",
                table: "SurveyQuestion");

            migrationBuilder.AddColumn<int>(
                name: "SurveyQuestionId",
                table: "SurveyAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_SurveyQuestionId",
                table: "SurveyAnswer",
                column: "SurveyQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyAnswer_SurveyQuestion_SurveyQuestionId",
                table: "SurveyAnswer",
                column: "SurveyQuestionId",
                principalTable: "SurveyQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
