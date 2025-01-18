using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakePersonalImgIdRequiredInPersonAndPortalUserModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Person_PersonalImg_PersonalImgId",
            //     table: "Person");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_PortalUser_PersonalImg_PersonalImgId",
            //     table: "PortalUser");

            // migrationBuilder.AlterColumn<int>(
            //     name: "PersonalImgId",
            //     table: "PortalUser",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0,
            //     oldClrType: typeof(int),
            //     oldType: "int",
            //     oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalImgId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonalImg_PersonalImgId",
                table: "Person",
                column: "PersonalImgId",
                principalTable: "PersonalImg",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_PortalUser_PersonalImg_PersonalImgId",
            //     table: "PortalUser",
            //     column: "PersonalImgId",
            //     principalTable: "PersonalImg",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Person_PersonalImg_PersonalImgId",
            //     table: "Person");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_PortalUser_PersonalImg_PersonalImgId",
            //     table: "PortalUser");

            // migrationBuilder.AlterColumn<int>(
            //     name: "PersonalImgId",
            //     table: "PortalUser",
            //     type: "int",
            //     nullable: true,
            //     oldClrType: typeof(int),
            //     oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalImgId",
                table: "Person",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonalImg_PersonalImgId",
                table: "Person",
                column: "PersonalImgId",
                principalTable: "PersonalImg",
                principalColumn: "Id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_PortalUser_PersonalImg_PersonalImgId",
            //     table: "PortalUser",
            //     column: "PersonalImgId",
            //     principalTable: "PersonalImg",
            //     principalColumn: "Id");
        }
    }
}
