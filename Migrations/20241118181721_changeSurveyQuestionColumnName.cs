using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class changeSurveyQuestionColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurveyAnswerId",
                table: "SurveyQuestion",
                newName: "SurveyAnswerTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurveyAnswerTypeId",
                table: "SurveyQuestion",
                newName: "SurveyAnswerId");
        }
    }
}
