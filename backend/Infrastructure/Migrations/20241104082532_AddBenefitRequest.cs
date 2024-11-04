using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDV_Benefits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBenefitRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppliedWhen = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    StatusChangedWhen = table.Column<DateOnly>(type: "date", nullable: false),
                    BenefitId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitRequests_Benefits_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Benefits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitRequests_BenefitId",
                table: "BenefitRequests",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitRequests_EmployeeId",
                table: "BenefitRequests",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitRequests");
        }
    }
}
