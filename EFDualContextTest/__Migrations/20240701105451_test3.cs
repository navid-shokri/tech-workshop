using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDualContextTest.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Persons_PersonId",
                table: "Histories");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Histories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Persons_PersonId",
                table: "Histories",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Persons_PersonId",
                table: "Histories");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "Histories",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Persons_PersonId",
                table: "Histories",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
