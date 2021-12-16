using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viewtance.Teaching.Migrations.TeachingMigrations
{
    public partial class Upgraded_To_abp_ver500 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeachingSettings_Name_ProviderName_ProviderKey",
                table: "TeachingSettings");

            migrationBuilder.DropIndex(
                name: "IX_TeachingFeatureValues_Name_ProviderName_ProviderKey",
                table: "TeachingFeatureValues");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSettings_Name_ProviderName_ProviderKey",
                table: "TeachingSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true,
                filter: "[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingFeatureValues_Name_ProviderName_ProviderKey",
                table: "TeachingFeatureValues",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true,
                filter: "[ProviderName] IS NOT NULL AND [ProviderKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeachingSettings_Name_ProviderName_ProviderKey",
                table: "TeachingSettings");

            migrationBuilder.DropIndex(
                name: "IX_TeachingFeatureValues_Name_ProviderName_ProviderKey",
                table: "TeachingFeatureValues");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSettings_Name_ProviderName_ProviderKey",
                table: "TeachingSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_TeachingFeatureValues_Name_ProviderName_ProviderKey",
                table: "TeachingFeatureValues",
                columns: new[] { "Name", "ProviderName", "ProviderKey" });
        }
    }
}
