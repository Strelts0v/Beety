using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DatabaseMigrations.Migrations
{
    public partial class UpdateRoleAndFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Redactors");

            migrationBuilder.RenameColumn(
                name: "BossName",
                table: "Organizations",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Redactors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Redactors");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organizations",
                newName: "BossName");

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Redactors",
                nullable: false,
                defaultValue: 0);
        }
    }
}
