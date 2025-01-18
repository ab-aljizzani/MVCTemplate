using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class MakePersonalImgIdAllowNullInPersonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_PersonalImg_PersonalImgId",
                table: "Person");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_PersonalImg_PersonalImgId",
                table: "Person");

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
        }
    }
}
