using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyHard.Data.Migrations
{
    public partial class ChnagedRelationSubjectPackageConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PackageConfigurations_SubjectId",
                table: "PackageConfigurations");

            migrationBuilder.CreateIndex(
                name: "IX_PackageConfigurations_SubjectId",
                table: "PackageConfigurations",
                column: "SubjectId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PackageConfigurations_SubjectId",
                table: "PackageConfigurations");

            migrationBuilder.CreateIndex(
                name: "IX_PackageConfigurations_SubjectId",
                table: "PackageConfigurations",
                column: "SubjectId");
        }
    }
}
