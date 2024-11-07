using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class changePersonDateOfBirthType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Department_EntityId",
                table: "Department");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Person",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DepartmentId",
                table: "Person",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonalImgId",
                table: "Person",
                column: "PersonalImgId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ZoneId",
                table: "Person",
                column: "ZoneId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_Person_DepartmentId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonalImgId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ZoneId",
                table: "Person");


            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Person",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
