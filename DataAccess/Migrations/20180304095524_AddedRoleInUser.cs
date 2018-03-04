using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccess.Migrations
{
    public partial class AddedRoleInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into dbo.Roles (RoleName) values ('Admin')");
            migrationBuilder.Sql("Insert into dbo.Roles (RoleName) values ('User')");
            migrationBuilder.Sql("Insert into dbo.Roles (RoleName) values ('Organization')");
            migrationBuilder.Sql("Insert into dbo.Roles (RoleName) values ('Master')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from dbo.Roles where RoleName = 'Admin'");
            migrationBuilder.Sql("delete from dbo.Roles where RoleName = 'User'");
            migrationBuilder.Sql("delete from dbo.Roles where RoleName = 'Organization'");
            migrationBuilder.Sql("delete from dbo.Roles where RoleName = 'Master'");
        }
    }
}
