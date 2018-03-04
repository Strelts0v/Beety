using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccess.Migrations
{
    public partial class AddedRoleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleType",
                table: "Roles",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.Sql("Update dbo.Roles set RoleType = '0' where RoleName = 'Admin'");
            migrationBuilder.Sql("Update dbo.Roles set RoleType = '1' where RoleName = 'User'");
            migrationBuilder.Sql("Update dbo.Roles set RoleType = '2' where RoleName = 'Organization'");
            migrationBuilder.Sql("Update dbo.Roles set RoleType = '3' where RoleName = 'Master'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "Roles");
        }
    }
}
