using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Viewtance.Teaching.Migrations.TeachingPermissionMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeachingPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingPermissionGrants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeachingPermissionGrants_Name_ProviderName_ProviderKey",
                table: "TeachingPermissionGrants",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeachingPermissionGrants");
        }
    }
}
