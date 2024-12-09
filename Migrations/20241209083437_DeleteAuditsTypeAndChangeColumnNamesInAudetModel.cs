using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAuditsTypeAndChangeColumnNamesInAudetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditType");

            migrationBuilder.DropColumn(
                name: "AuditTypeId",
                table: "Audits");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "Audits",
                newName: "HttpRequest");

            migrationBuilder.AddColumn<string>(
                name: "EndPoint",
                table: "Audits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPoint",
                table: "Audits");

            migrationBuilder.RenameColumn(
                name: "HttpRequest",
                table: "Audits",
                newName: "ServiceName");

            migrationBuilder.AddColumn<int>(
                name: "AuditTypeId",
                table: "Audits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuditType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditType", x => x.Id);
                });
        }
    }
}
