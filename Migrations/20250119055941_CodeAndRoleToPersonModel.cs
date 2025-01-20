using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class CodeAndRoleToPersonModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Person",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Person_RoleId",
                table: "Person",
                column: "RoleId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Person_Role_RoleId",
            //     table: "Person",
            //     column: "RoleId",
            //     principalTable: "Role",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Person_Role_RoleId",
            //     table: "Person");

            // migrationBuilder.DropIndex(
            //     name: "IX_Person_RoleId",
            //     table: "Person");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Person");

            // migrationBuilder.DropColumn(
            //     name: "RoleId",
            //     table: "Person");
        }
    }
}
