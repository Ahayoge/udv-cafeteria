using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDV_Benefits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRejectionReasonForBenefitRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectionReason",
                table: "BenefitRequests",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectionReason",
                table: "BenefitRequests");
        }
    }
}
