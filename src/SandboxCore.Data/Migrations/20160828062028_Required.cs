using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SandboxCore.Data.Migrations
{
    public partial class Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProjectCategoryProductCategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCategoryProductCategoryId",
                table: "Products",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                maxLength: 1000,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProjectCategoryProductCategoryId",
                table: "Products",
                column: "ProjectCategoryProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProjectCategoryProductCategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectCategoryProductCategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProjectCategoryProductCategoryId",
                table: "Products",
                column: "ProjectCategoryProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
