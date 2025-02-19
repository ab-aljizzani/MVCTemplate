using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class NationalIdColumnToAuditsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserSurveyList_SurveyTypeId",
                table: "UserSurveyList",
                column: "SurveyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyList_SurveyType_SurveyTypeId",
                table: "UserSurveyList",
                column: "SurveyTypeId",
                principalTable: "SurveyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyList_SurveyType_SurveyTypeId",
                table: "UserSurveyList");

            migrationBuilder.DropIndex(
                name: "IX_UserSurveyList_SurveyTypeId",
                table: "UserSurveyList");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Audits");
        }
    }
}
