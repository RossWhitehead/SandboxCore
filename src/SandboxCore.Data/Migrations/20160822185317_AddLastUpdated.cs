using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SandboxCore.Data.Migrations
{
    public partial class AddLastUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Projects",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Products",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "WorkItems",
                nullable: false,
                defaultValueSql: "GetDate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "ProductCategories",
                nullable: false,
                defaultValueSql: "GetDate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "WorkItems",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "ProductCategories",
                nullable: false);
        }
    }
}
