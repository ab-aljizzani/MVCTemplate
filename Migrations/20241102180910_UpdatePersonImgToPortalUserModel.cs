using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonImgToPortalUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonImgId",
                table: "PortalUser",
                newName: "PersonalImgId");


        }

        /// <inheritdoc />
    }
}
