using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDualContextTest.Migrations
{
    /// <inheritdoc />
    public partial class ann_dar_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "ann_dar_product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SellerId",
                table: "ann_dar_product",
                newName: "IX_ann_dar_product_SellerId");

            migrationBuilder.AddColumn<Guid>(
                name: "SellerId1",
                table: "ann_dar_product",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ann_dar_product",
                table: "ann_dar_product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ann_dar_product_SellerId1",
                table: "ann_dar_product",
                column: "SellerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ann_dar_product_Sellers_SellerId",
                table: "ann_dar_product",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ann_dar_product_Sellers_SellerId1",
                table: "ann_dar_product",
                column: "SellerId1",
                principalTable: "Sellers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ann_dar_product_Sellers_SellerId",
                table: "ann_dar_product");

            migrationBuilder.DropForeignKey(
                name: "FK_ann_dar_product_Sellers_SellerId1",
                table: "ann_dar_product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ann_dar_product",
                table: "ann_dar_product");

            migrationBuilder.DropIndex(
                name: "IX_ann_dar_product_SellerId1",
                table: "ann_dar_product");

            migrationBuilder.DropColumn(
                name: "SellerId1",
                table: "ann_dar_product");

            migrationBuilder.RenameTable(
                name: "ann_dar_product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_ann_dar_product_SellerId",
                table: "Products",
                newName: "IX_Products_SellerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sellers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }
    }
}
