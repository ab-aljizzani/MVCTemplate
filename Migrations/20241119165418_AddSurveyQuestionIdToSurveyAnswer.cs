using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSurveyQuestionIdToSurveyAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
