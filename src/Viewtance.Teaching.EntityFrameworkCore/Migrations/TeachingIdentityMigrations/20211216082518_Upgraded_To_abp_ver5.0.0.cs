using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viewtance.Teaching.Migrations.TeachingIdentityMigrations
{
    public partial class Upgraded_To_abp_ver500 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TeachingUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TeachingUsers");
        }
    }
}
