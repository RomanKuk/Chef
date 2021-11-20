import { Category } from "../category/category";
import { Ingredient } from "../ingredient/ingredient";
import { VolumeMetric } from "../volume-metric/volume-metric";

export interface ComponentIngredient {
    id: number;
    category: Category;
    ingredient: Ingredient;
    quantity: number;
    description: string;
    volumeMetric: VolumeMetric;
}