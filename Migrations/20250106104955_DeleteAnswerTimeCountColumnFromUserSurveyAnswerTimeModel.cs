using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAnswerTimeCountColumnFromUserSurveyAnswerTimeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerTimeCount",
                table: "UserSurveyAnswerTimes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswerTimeCount",
                table: "UserSurveyAnswerTimes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
