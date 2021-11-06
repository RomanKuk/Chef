using Microsoft.EntityFrameworkCore.Migrations;

namespace Chef.DAL.Migrations
{
    public partial class FixIngredientRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_VolumeMetrics_VolumeMetricId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeCategories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_VolumeMetricId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "VolumeMetricId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RecipeUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolumeMetricId",
                table: "ProductListIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolumeMetricId",
                table: "ComponentIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductListIngredients_VolumeMetricId",
                table: "ProductListIngredients",
                column: "VolumeMetricId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentIngredients_VolumeMetricId",
                table: "ComponentIngredients",
                column: "VolumeMetricId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentIngredients_VolumeMetrics_VolumeMetricId",
                table: "ComponentIngredients",
                column: "VolumeMetricId",
                principalTable: "VolumeMetrics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductListIngredients_VolumeMetrics_VolumeMetricId",
                table: "ProductListIngredients",
                column: "VolumeMetricId",
                principalTable: "VolumeMetrics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeCategories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "RecipeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentIngredients_VolumeMetrics_VolumeMetricId",
                table: "ComponentIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductListIngredients_VolumeMetrics_VolumeMetricId",
                table: "ProductListIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeCategories_CategoryId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_ProductListIngredients_VolumeMetricId",
                table: "ProductListIngredients");

            migrationBuilder.DropIndex(
                name: "IX_ComponentIngredients_VolumeMetricId",
                table: "ComponentIngredients");

            migrationBuilder.DropColumn(
                name: "RecipeUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "VolumeMetricId",
                table: "ProductListIngredients");

            migrationBuilder.DropColumn(
                name: "VolumeMetricId",
                table: "ComponentIngredients");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VolumeMetricId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_VolumeMetricId",
                table: "Ingredients",
                column: "VolumeMetricId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_VolumeMetrics_VolumeMetricId",
                table: "Ingredients",
                column: "VolumeMetricId",
                principalTable: "VolumeMetrics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeCategories_CategoryId",
                table: "Recipes",
                column: "CategoryId",
                principalTable: "RecipeCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
