using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class IsPladgeApprovedCulomnToUserSurveyListModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPledgeApproved",
                table: "UserSurveyList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Request_SurveyTypeId",
                table: "Request",
                column: "SurveyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_SurveyType_SurveyTypeId",
                table: "Request",
                column: "SurveyTypeId",
                principalTable: "SurveyType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_SurveyType_SurveyTypeId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SurveyTypeId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "IsPledgeApproved",
                table: "UserSurveyList");
        }
    }
}
