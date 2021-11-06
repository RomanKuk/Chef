using System;
using System.Collections.Generic;
using Chef.DAL.Context.EntityConfigurations;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chef.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            VolumeMetricSeedData(modelBuilder);
            IngredientCategorySeedData(modelBuilder);
            IngredientsSeedData(modelBuilder);
            RecipesSeedData(modelBuilder);
            InstructionsSeedData(modelBuilder);
        }

        private static void VolumeMetricSeedData(ModelBuilder modelBuilder)
        {
            int volumeMetricId = 1;

            var volumeMetricList = new List<VolumeMetric>
            {
                new() {Id = volumeMetricId++, Name = "tsp"},
                new() {Id = volumeMetricId++, Name = "tbsp"},
                new() {Id = volumeMetricId++, Name = "g"},
                new() {Id = volumeMetricId++, Name = "kg"},
                new() {Id = volumeMetricId++, Name = "l"},
                new() {Id = volumeMetricId++, Name = "ml"},
                new() {Id = volumeMetricId++, Name = "cup"},
                new() {Id = volumeMetricId++, Name = "sprigs"},
                new() {Id = volumeMetricId++, Name = "head"},
                new() {Id = volumeMetricId, Name = "glass"},
            };

            modelBuilder.Entity<VolumeMetric>().HasData(volumeMetricList);
        }

        private static void IngredientCategorySeedData(ModelBuilder modelBuilder)
        {
            int ingredientCategoryId = 1;

            var categories = new List<IngredientCategory>
            {
                new() {Id = ingredientCategoryId++, Name = "Bread and bakery"},
                new() {Id = ingredientCategoryId++, Name = "Dairy and eggs"},
                new() {Id = ingredientCategoryId++, Name = "Fruits and vegetables"},
                new() {Id = ingredientCategoryId++, Name = "Meats and seafood"},
                new() {Id = ingredientCategoryId++, Name = "Health and beauty"},
                new() {Id = ingredientCategoryId++, Name = "Snacks"},
                new() {Id = ingredientCategoryId++, Name = "Baking"},
                new() {Id = ingredientCategoryId++, Name = "Herbs and spices"},
                new() {Id = ingredientCategoryId++, Name = "Drinks"},
                new() {Id = ingredientCategoryId++, Name = "Condiments"},
                new() {Id = ingredientCategoryId++, Name = "Frozen"},
                new() {Id = ingredientCategoryId++, Name = "Pasta, rice and beans"},
                new() {Id = ingredientCategoryId, Name = "Other"},
            };

            modelBuilder.Entity<IngredientCategory>().HasData(categories);
        }

        private static void IngredientsSeedData(ModelBuilder modelBuilder)
        {
            int ingredientId = 1;

            var ingredients = new List<Ingredient>
            {
                new() {Id = ingredientId++, Name = "Bread", IngredientCategoryId = 1},
                new() {Id = ingredientId++, Name = "Crescent rolls", IngredientCategoryId = 1},

                new() {Id = ingredientId++, Name = "Butter", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Cheese", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Egg substitute", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Eggs", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Milk", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Yogurt", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Mozzarella cheese", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Parmesan cheese", IngredientCategoryId = 2},
                new() {Id = ingredientId++, Name = "Goat cheese", IngredientCategoryId = 2},

                new() {Id = ingredientId++, Name = "Avocado", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Banana", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Broccoli", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Carrot", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Celery", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Cucumber", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Eggplant", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Garlic", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Mushrooms", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Onions", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Potato", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Salad", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Tomato", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Cranberry", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Strawberry", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Cherry", IngredientCategoryId = 3},
                new() {Id = ingredientId++, Name = "Raspberry", IngredientCategoryId = 3},

                new() {Id = ingredientId++, Name = "Chicken", IngredientCategoryId = 4},
                new() {Id = ingredientId++, Name = "Chicken breast", IngredientCategoryId = 4},
                new() {Id = ingredientId++, Name = "Lamb", IngredientCategoryId = 4},
                new() {Id = ingredientId++, Name = "Rabbit", IngredientCategoryId = 4},
                new() {Id = ingredientId++, Name = "Ground beef", IngredientCategoryId = 4},
                new() {Id = ingredientId++, Name = "Bacon", IngredientCategoryId = 4},

                new() {Id = ingredientId++, Name = "Dark chocolate", IngredientCategoryId = 6},
                new() {Id = ingredientId++, Name = "Wafers", IngredientCategoryId = 6},

                new() {Id = ingredientId++, Name = "Sugar", IngredientCategoryId = 7},
                new() {Id = ingredientId++, Name = "Dark brown sugar", IngredientCategoryId = 7},
                new() {Id = ingredientId++, Name = "Flour", IngredientCategoryId = 7},
                new() {Id = ingredientId++, Name = "Sunflower seeds", IngredientCategoryId = 7},

                new() {Id = ingredientId++, Name = "Saffron", IngredientCategoryId = 8},
                new() {Id = ingredientId++, Name = "Sage dry", IngredientCategoryId = 8},
                new() {Id = ingredientId++, Name = "Pepper", IngredientCategoryId = 8},
                new() {Id = ingredientId++, Name = "Salt", IngredientCategoryId = 8},

                new() {Id = ingredientId++, Name = "Water", IngredientCategoryId = 9},

                new() {Id = ingredientId++, Name = "Spaghetti sauce", IngredientCategoryId = 10},
                new() {Id = ingredientId++, Name = "Mayonnaise", IngredientCategoryId = 10},
                new() {Id = ingredientId++, Name = "Olive oil", IngredientCategoryId = 10},

                new() {Id = ingredientId++, Name = "Spaghetti", IngredientCategoryId = 12},
                new() {Id = ingredientId, Name = "Basmati rice", IngredientCategoryId = 12},

            };

            modelBuilder.Entity<Ingredient>().HasData(ingredients);
        }

        private static void RecipesSeedData(ModelBuilder modelBuilder)
        {
            int recipeId = 1;

            var recipes = new List<Recipe>
            {
                new() {
                    Id = recipeId, 
                    Name = "Banana Pancakes", 
                    CreatedAt = DateTime.UtcNow, 
                    CookingTime = TimeSpan.FromMinutes(15), 
                    PreparationTime = TimeSpan.FromMinutes(5), 
                    LikeCount = 21, 
                    DislikeCount = 1, 
                    DefaultServingsCount = 2,
                    RecipeUrl = "https://www.runningwithspoons.com/wp-content/uploads/2020/05/Easy-Banana-Oat-Pancakes2-683x900.jpg"
                }
            };

            modelBuilder.Entity<Recipe>().HasData(recipes);
        }

        private static void InstructionsSeedData(ModelBuilder modelBuilder)
        {
            int instructionsId = 1;

            var instructions = new List<Instruction>
            {
                new()
                {
                    Id = instructionsId++, Description = "Blend the oats until they become a smooth flour texture. Set aside in a bowl", OrderNumber = 1, RecipeId = 1
                },
                new()
                {
                    Id = instructionsId++, Description = "Blend together bananas and milk", OrderNumber = 2, RecipeId = 1
                },
                new()
                {
                    Id = instructionsId++, Description = "Slowly add the oat flour and cinnamon to the bananas and milk. Blend until smooth", OrderNumber = 3, RecipeId = 1
                },
                new()
                {
                    Id = instructionsId++, Description = "On medium heat, pour mixture into a buttered pan. Once bubbles start to appear on one side, flip the pancakes", OrderNumber = 4, RecipeId = 1
                },
                new()
                {
                    Id = instructionsId, Description = "Add peanut butter, honey, syrup, chocolate chips, blueberries or whatever your heart desires!", OrderNumber = 5, RecipeId = 1
                }
            };

            modelBuilder.Entity<Instruction>().HasData(instructions);
        }
    }
}
