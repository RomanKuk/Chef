using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chef.DAL.Migrations
{
    public partial class AddRecipeComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentIngredients_RecipeComponent_RecipeComponentId",
                table: "ComponentIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeComponent_Recipes_RecipeId",
                table: "RecipeComponent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeComponent",
                table: "RecipeComponent");

            migrationBuilder.RenameTable(
                name: "RecipeComponent",
                newName: "RecipeComponents");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeComponent_RecipeId",
                table: "RecipeComponents",
                newName: "IX_RecipeComponents_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeComponents",
                table: "RecipeComponents",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 19, 14, 11, 26, 471, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentIngredients_RecipeComponents_RecipeComponentId",
                table: "ComponentIngredients",
                column: "RecipeComponentId",
                principalTable: "RecipeComponents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComponents_Recipes_RecipeId",
                table: "RecipeComponents",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentIngredients_RecipeComponents_RecipeComponentId",
                table: "ComponentIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeComponents_Recipes_RecipeId",
                table: "RecipeComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecipeComponents",
                table: "RecipeComponents");

            migrationBuilder.RenameTable(
                name: "RecipeComponents",
                newName: "RecipeComponent");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeComponents_RecipeId",
                table: "RecipeComponent",
                newName: "IX_RecipeComponent_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecipeComponent",
                table: "RecipeComponent",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 11, 6, 18, 8, 33, 909, DateTimeKind.Utc).AddTicks(3868));

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentIngredients_RecipeComponent_RecipeComponentId",
                table: "ComponentIngredients",
                column: "RecipeComponentId",
                principalTable: "RecipeComponent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeComponent_Recipes_RecipeId",
                table: "RecipeComponent",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
