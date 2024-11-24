using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDV_Benefits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFormUrlToBenefit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormUrl",
                table: "Benefits",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormUrl",
                table: "Benefits");
        }
    }
}
