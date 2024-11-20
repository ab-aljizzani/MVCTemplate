using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class ViewToRequestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Request",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_PersonId",
                table: "Request",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PortalUserId",
                table: "Request",
                column: "PortalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestStatusId",
                table: "Request",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Person_PersonId",
                table: "Request",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_PortalUser_PortalUserId",
                table: "Request",
                column: "PortalUserId",
                principalTable: "PortalUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusId",
                table: "Request",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Person_PersonId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_PortalUser_PortalUserId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_RequestStatus_RequestStatusId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_PersonId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_PortalUserId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_RequestStatusId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Request");
        }
    }
}
