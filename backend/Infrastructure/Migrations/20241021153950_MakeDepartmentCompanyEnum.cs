using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UDV_Benefits.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeDepartmentCompanyEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Company_CompanyId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Department_DepartmentId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CompanyId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Workers");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "Workers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Workers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Workers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "Workers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Workers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CompanyId",
                table: "Workers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Company_CompanyId",
                table: "Workers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Department_DepartmentId",
                table: "Workers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
