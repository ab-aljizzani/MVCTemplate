using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSurveyAnswerTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSurveyAnswerTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    SurveyTypeId = table.Column<int>(type: "int", nullable: false),
                    SurveyQuestionId = table.Column<int>(type: "int", nullable: false),
                    SurveyAnswerId = table.Column<int>(type: "int", nullable: false),
                    AnswerTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerTimeCount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSurveyAnswerTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSurveyAnswerTimes_SurveyAnswer_SurveyAnswerId",
                        column: x => x.SurveyAnswerId,
                        principalTable: "SurveyAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSurveyAnswerTimes_SurveyQuestion_SurveyQuestionId",
                        column: x => x.SurveyQuestionId,
                        principalTable: "SurveyQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyAnswerTimes_SurveyAnswerId",
                table: "UserSurveyAnswerTimes",
                column: "SurveyAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyAnswerTimes_SurveyQuestionId",
                table: "UserSurveyAnswerTimes",
                column: "SurveyQuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSurveyAnswerTimes");
        }
    }
}
