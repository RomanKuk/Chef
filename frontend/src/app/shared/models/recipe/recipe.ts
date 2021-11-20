import { Time } from "@angular/common";
import { Component } from "../component/component";
import { Instruction } from "../instruction/instruction";
import { Review } from "../review/review";

export interface Recipe {
    id: number;
    name: string;
    description: string;
    cookingTime: Time;
    preparationTime: Time;
    recipeUrl: string;
    likeCount: number;
    defaultServingsCount: number;
    dislikeCount: number;
    summaryTime: Time;
    ingredientsCount: number;
    reviews: Review[];
    instructions: Instruction[];
    components: Component[];
}