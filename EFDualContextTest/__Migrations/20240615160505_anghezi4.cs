using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDualContextTest.Migrations
{
    /// <inheritdoc />
    public partial class anghezi4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Histories",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_PersonId",
                table: "Histories",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Persons_PersonId",
                table: "Histories",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Persons_PersonId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_PersonId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Histories");
        }
    }
}
