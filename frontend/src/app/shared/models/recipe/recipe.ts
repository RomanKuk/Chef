import { Time } from "@angular/common";

export interface Recipe {
    id: number;
    name: string;
    description: string;
    cookingTime: Time;
    preparationTime: Time;
    recipeUrl: string;
    likeCount: number;
    dislikeCount: number;
    summaryTime: Time;
    ingredientsCount: number;
}