using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDV_Benefits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFormUrlToDmsProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormUrl",
                table: "Benefits");

            migrationBuilder.AddColumn<string>(
                name: "DmsProgram",
                table: "EmployeeBenefits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FormRequired",
                table: "Benefits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DmsProgram",
                table: "BenefitRequests",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DmsProgram",
                table: "EmployeeBenefits");

            migrationBuilder.DropColumn(
                name: "FormRequired",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "DmsProgram",
                table: "BenefitRequests");

            migrationBuilder.AddColumn<string>(
                name: "FormUrl",
                table: "Benefits",
                type: "text",
                nullable: true);
        }
    }
}
