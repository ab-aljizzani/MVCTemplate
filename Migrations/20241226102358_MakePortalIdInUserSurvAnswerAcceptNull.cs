using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakePortalIdInUserSurvAnswerAcceptNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyAnswer_PortalUser_PortalUserId",
                table: "UserSurveyAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "PortalUserId",
                table: "UserSurveyAnswer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyAnswer_PortalUser_PortalUserId",
                table: "UserSurveyAnswer",
                column: "PortalUserId",
                principalTable: "PortalUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSurveyAnswer_PortalUser_PortalUserId",
                table: "UserSurveyAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "PortalUserId",
                table: "UserSurveyAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSurveyAnswer_PortalUser_PortalUserId",
                table: "UserSurveyAnswer",
                column: "PortalUserId",
                principalTable: "PortalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
