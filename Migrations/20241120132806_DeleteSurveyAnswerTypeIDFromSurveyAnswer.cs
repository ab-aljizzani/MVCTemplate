using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSurveyAnswerTypeIDFromSurveyAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyAnswerTypeId",
                table: "SurveyQuestion");

            migrationBuilder.RenameColumn(
                name: "SurveyAnswerTypeId",
                table: "SurveyAnswer",
                newName: "SurveyQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurveyQuestionId",
                table: "SurveyAnswer",
                newName: "SurveyAnswerTypeId");

            migrationBuilder.AddColumn<int>(
                name: "SurveyAnswerTypeId",
                table: "SurveyQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
