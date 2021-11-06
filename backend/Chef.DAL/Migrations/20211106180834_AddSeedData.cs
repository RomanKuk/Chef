using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chef.DAL.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IngredientCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bread and bakery" },
                    { 13, "Other" },
                    { 11, "Frozen" },
                    { 10, "Condiments" },
                    { 9, "Drinks" },
                    { 8, "Herbs and spices" },
                    { 12, "Pasta, rice and beans" },
                    { 6, "Snacks" },
                    { 5, "Health and beauty" },
                    { 4, "Meats and seafood" },
                    { 3, "Fruits and vegetables" },
                    { 2, "Dairy and eggs" },
                    { 7, "Baking" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CookingTime", "CreatedAt", "DefaultServingsCount", "Description", "DislikeCount", "LikeCount", "Name", "PreparationTime", "RecipeUrl", "UserId" },
                values: new object[] { 1, null, new TimeSpan(0, 0, 15, 0, 0), new DateTime(2021, 11, 6, 18, 8, 33, 909, DateTimeKind.Utc).AddTicks(3868), 2, null, 1, 21, "Banana Pancakes", new TimeSpan(0, 0, 5, 0, 0), "https://www.runningwithspoons.com/wp-content/uploads/2020/05/Easy-Banana-Oat-Pancakes2-683x900.jpg", null });

            migrationBuilder.InsertData(
                table: "VolumeMetrics",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "sprigs" },
                    { 7, "cup" },
                    { 6, "ml" },
                    { 5, "l" },
                    { 2, "tbsp" },
                    { 3, "g" },
                    { 1, "tsp" },
                    { 9, "head" },
                    { 4, "kg" },
                    { 10, "glass" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Bread" },
                    { 29, 4, "Chicken" },
                    { 30, 4, "Chicken breast" },
                    { 31, 4, "Lamb" },
                    { 32, 4, "Rabbit" },
                    { 33, 4, "Ground beef" },
                    { 34, 4, "Bacon" },
                    { 35, 6, "Dark chocolate" },
                    { 36, 6, "Wafers" },
                    { 37, 7, "Sugar" },
                    { 38, 7, "Dark brown sugar" },
                    { 27, 3, "Cherry" },
                    { 39, 7, "Flour" },
                    { 41, 8, "Saffron" },
                    { 42, 8, "Sage dry" },
                    { 43, 8, "Pepper" },
                    { 44, 8, "Salt" },
                    { 45, 9, "Water" },
                    { 46, 10, "Spaghetti sauce" },
                    { 47, 10, "Mayonnaise" },
                    { 48, 10, "Olive oil" },
                    { 49, 12, "Spaghetti" },
                    { 50, 12, "Basmati rice" },
                    { 40, 7, "Sunflower seeds" },
                    { 26, 3, "Strawberry" },
                    { 28, 3, "Raspberry" },
                    { 24, 3, "Tomato" },
                    { 2, 1, "Crescent rolls" },
                    { 3, 2, "Butter" },
                    { 4, 2, "Cheese" },
                    { 5, 2, "Egg substitute" },
                    { 6, 2, "Eggs" },
                    { 7, 2, "Milk" },
                    { 8, 2, "Yogurt" },
                    { 9, 2, "Mozzarella cheese" },
                    { 10, 2, "Parmesan cheese" },
                    { 25, 3, "Cranberry" },
                    { 12, 3, "Avocado" },
                    { 11, 2, "Goat cheese" },
                    { 14, 3, "Broccoli" },
                    { 15, 3, "Carrot" },
                    { 16, 3, "Celery" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientCategoryId", "Name" },
                values: new object[,]
                {
                    { 17, 3, "Cucumber" },
                    { 18, 3, "Eggplant" },
                    { 19, 3, "Garlic" },
                    { 20, 3, "Mushrooms" },
                    { 21, 3, "Onions" },
                    { 22, 3, "Potato" },
                    { 23, 3, "Salad" },
                    { 13, 3, "Banana" }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "Id", "Description", "OrderNumber", "RecipeId" },
                values: new object[,]
                {
                    { 4, "On medium heat, pour mixture into a buttered pan. Once bubbles start to appear on one side, flip the pancakes", 4, 1 },
                    { 1, "Blend the oats until they become a smooth flour texture. Set aside in a bowl", 1, 1 },
                    { 2, "Blend together bananas and milk", 2, 1 },
                    { 3, "Slowly add the oat flour and cinnamon to the bananas and milk. Blend until smooth", 3, 1 },
                    { 5, "Add peanut butter, honey, syrup, chocolate chips, blueberries or whatever your heart desires!", 5, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VolumeMetrics",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IngredientCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
