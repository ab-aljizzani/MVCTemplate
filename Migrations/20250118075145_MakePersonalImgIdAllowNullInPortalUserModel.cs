using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakePersonalImgIdAllowNullInPortalUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_PortalUser_PersonalImg_PersonalImgId",
            //     table: "PortalUser");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalImgId",
                table: "PortalUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUser_PersonalImg_PersonalImgId",
                table: "PortalUser",
                column: "PersonalImgId",
                principalTable: "PersonalImg",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_PortalUser_PersonalImg_PersonalImgId",
            //     table: "PortalUser");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalImgId",
                table: "PortalUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUser_PersonalImg_PersonalImgId",
                table: "PortalUser",
                column: "PersonalImgId",
                principalTable: "PersonalImg",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
