import { Category } from "../category/category";

export interface Ingredient {
    id: number;
    name: string;
    ingredientCategory: Category
}