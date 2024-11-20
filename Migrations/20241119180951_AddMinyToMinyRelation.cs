using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMinyToMinyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "SurveyAnswerSurveyQuestion",
                columns: table => new
                {
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: false),
                    SurveyQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswerSurveyQuestion", x => new { x.SurveyAnswerId, x.SurveyQuestionId });
                    table.ForeignKey(
                        name: "FK_SurveyAnswerSurveyQuestion_SurveyAnswer_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyAnswerSurveyQuestion_SurveyQuestion_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswerSurveyQuestion_SurveyQuestionId",
                table: "SurveyAnswerSurveyQuestion",
                column: "SurveyQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyAnswerSurveyQuestion");

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
    }
}
