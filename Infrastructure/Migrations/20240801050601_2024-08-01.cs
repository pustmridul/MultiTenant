using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _20240801 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanFeature_Feature_FeatureId",
                table: "PlanFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanFeature_Plan_PlanId",
                table: "PlanFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Plan_PlanId",
                table: "Pricing");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanFeature_Feature_FeatureId",
                table: "PlanFeature",
                column: "FeatureId",
                principalTable: "Feature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanFeature_Plan_PlanId",
                table: "PlanFeature",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Plan_PlanId",
                table: "Pricing",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanFeature_Feature_FeatureId",
                table: "PlanFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanFeature_Plan_PlanId",
                table: "PlanFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricing_Plan_PlanId",
                table: "Pricing");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanFeature_Feature_FeatureId",
                table: "PlanFeature",
                column: "FeatureId",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanFeature_Plan_PlanId",
                table: "PlanFeature",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricing_Plan_PlanId",
                table: "Pricing",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
