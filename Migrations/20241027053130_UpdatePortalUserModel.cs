using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePortalUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserExpires",
                table: "PortalUser",
                newName: "PasswordExpires");

            migrationBuilder.RenameColumn(
                name: "CreatedUser",
                table: "PortalUser",
                newName: "LastLogin");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PortalUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "PortalUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "PortalUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PortalUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PortalUser");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "PortalUser");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "PortalUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PortalUser");

            migrationBuilder.RenameColumn(
                name: "PasswordExpires",
                table: "PortalUser",
                newName: "UserExpires");

            migrationBuilder.RenameColumn(
                name: "LastLogin",
                table: "PortalUser",
                newName: "CreatedUser");
        }
    }
}
