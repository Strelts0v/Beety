using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DatabaseMigrations.Migrations
{
    public partial class AddSomeColumnsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChiefName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerAccountNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonalCount",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceSegment",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Roles",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BossName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PayerAccountNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonalCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ServiceSegment",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Roles");
        }
    }
}
